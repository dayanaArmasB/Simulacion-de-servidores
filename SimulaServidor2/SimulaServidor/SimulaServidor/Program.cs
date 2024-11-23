using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulaServidor {
    struct Cajero {
        public bool Activo;
		public int Tiempo_Restante;
    };

    class Program
    {
        static void Main(string[] args)
        {
            char runAgain = 'S';
            while (runAgain != 'N')
            {
                int sim_Time, trans_Time, num_Serv, arriv_Time;
                int i = 0, c_Time = 0; // Contadores
                int customers = 0, left, wait_Time = 0;
                Cola<int> bankQ = new Cola<int>();

                Console.WriteLine("\n------------------------------------------"
                                + "\n- Bienvenido a la Simulación de Banco -"
                                + "\n------------------------------------------");

                // Menú de entrada
                Console.WriteLine("\nIngrese los siguientes datos en minutos:\n");
                Console.Write("Tiempo total de la simulación (m): ");
                sim_Time = Convert.ToInt32(Console.ReadLine());
                Console.Write("Tiempo de atención del servidor (m): ");
                trans_Time = Convert.ToInt32(Console.ReadLine());
                Console.Write("Cantidad de servidores: ");
                num_Serv = Convert.ToInt32(Console.ReadLine());
                Console.Write("Tiempo entre llegada de clientes (m): ");
                arriv_Time = Convert.ToInt32(Console.ReadLine());

                Cajero[] tellArray = new Cajero[num_Serv];

                // Crear e inicializar cada cajero
                for (i = 0; i < num_Serv; i++)
                {
                    tellArray[i] = new Cajero { Activo = false, Tiempo_Restante = 0 };
                }

                Console.WriteLine("\nIniciando simulación...\n");

                while (c_Time < sim_Time)
                {
                    // Llegada de clientes
                    if (c_Time % arriv_Time == 0)
                    {
                        bankQ.Enqueue(customers); // Agregar cliente a la cola
                        customers++;
                        Console.WriteLine($"[{c_Time}m] Cliente {customers} llega y se une a la cola.");
                    }

                    // Asignar clientes a cajeros disponibles
                    for (i = 0; i < num_Serv; i++)
                    {
                        if (bankQ.GetSize() > 0 && !tellArray[i].Activo)
                        {
                            bankQ.Dequeue(); // Atender cliente
                            tellArray[i].Activo = true;
                            tellArray[i].Tiempo_Restante = trans_Time;
                            Console.WriteLine($"[{c_Time}m] Cajero {i + 1} empieza a atender un cliente.");
                        }
                    }

                    // Actualizar estado de los cajeros
                    for (i = 0; i < num_Serv; i++)
                    {
                        if (tellArray[i].Activo)
                        {
                            tellArray[i].Tiempo_Restante--;
                            if (tellArray[i].Tiempo_Restante <= 0)
                            {
                                tellArray[i].Activo = false; // Cajero disponible
                                Console.WriteLine($"[{c_Time + 1}m] Cajero {i + 1} termina de atender a un cliente.");
                            }
                        }
                    }

                    // Reporte por ciclo
                    left = bankQ.GetSize();
                    Console.WriteLine($"[{c_Time}m] Estado actual: En cola: {left} cliente(s)");
                    for (int j = 0; j < num_Serv; j++)
                    {
                        Console.WriteLine($" - Cajero {j + 1}: {(tellArray[j].Activo ? "Ocupado" : "Disponible")}");
                    }

                    wait_Time += left;
                    c_Time++;
                }

                // Reporte final
                Console.WriteLine("\n---------------\n- REPORTE FINAL -\n---------------\n");
                Console.WriteLine($"Clientes atendidos: {customers}");
                Console.WriteLine($"Tiempo total de espera acumulado (clientes esperando en cola): {wait_Time}m");
                Console.WriteLine($"Tiempo promedio de espera por cliente: {(customers > 0 ? ((float)wait_Time / customers).ToString("F2") : "0.00")}m");

                // Repetir simulación
                Console.Write("\n\n¿Ejecutar programa otra vez? (s/n): ");
                runAgain = char.ToUpper(Convert.ToChar(Console.ReadLine()));
                while (runAgain != 'S' && runAgain != 'N')
                {
                    Console.Write("Letra inválida. ¿Ejecutar programa otra vez? (s/n): ");
                    runAgain = char.ToUpper(Convert.ToChar(Console.ReadLine()));
                }
            }
        }
    }


}
