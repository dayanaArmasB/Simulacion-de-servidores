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

    class Program {
        static void Main(string[] args) {
			char runAgain='S';
			while (runAgain != 'N') {
				int sim_Time, trans_Time, num_Serv, arriv_Time;
				int i = 0, c_Time = 0; //Counters
				int customers = 0, left, wait_Time = 0;
				Cola bankQ = new Cola();

				Console.Write( "\n------------------------------------------"
					 + "\n- Bienvenido al la Simulacion de banco -"
					 + "\n------------------------------------------");

				//Menu information
				Console.Write( "\n\nIngrese los siguentes datos en minutos:\n");
				Console.Write( "\nTiempo de la simulación: " );
				sim_Time = Convert.ToInt32( Console.ReadLine()) ;
				Console.Write( "Tiempo de atención del servidor: ");
				trans_Time = Convert.ToInt32(Console.ReadLine( ));
				Console.Write( "Cantidad de servidores: ");
				num_Serv = Convert.ToInt32(Console.ReadLine( ));
				Console.Write( "Tiempo entre llegada de Clientes: ");
				arriv_Time = Convert.ToInt32(Console.ReadLine( ));

				Cajero[] tellArray = new Cajero[num_Serv];

				//Set all tellers to empty
				for (i = 0; i < num_Serv; i++) {
					tellArray[i].Activo = false;
					tellArray[i].Tiempo_Restante = 0;
				}

				while (c_Time < sim_Time) {

					if (c_Time % arriv_Time == 0) {
						bankQ.Enqueue();
						customers++;
					}

					
					for (i = 0; i < num_Serv; i++) {
						if (bankQ.GetSize() > 0) {
							if (tellArray[i].Activo == false) {
								bankQ.Dequeue();
								tellArray[i].Activo = true;
								tellArray[i].Tiempo_Restante = trans_Time;
							}
						}
					}
					


					for (i = 0; i < num_Serv; i++) {
						if (tellArray[i].Activo == true) {
							tellArray[i].Tiempo_Restante--;
						}
						if (tellArray[i].Tiempo_Restante == 0 && tellArray[i].Activo == true) {
							tellArray[i].Activo = false;
						}
					}

					left = bankQ.GetSize();
					Console.Write( $"\n{c_Time}-- en cola:{left} s1:{tellArray[0].Activo}  s2:{tellArray[1].Activo}  s3:{tellArray[2].Activo}");
					wait_Time += left;
					c_Time++;
				}

				Console.Write( "\n---------------"
					 + "\n- REPORTE -"
					 + "\n---------------\n");


				Console.Write( "Tiempo promedio de espera: ");

				Console.Write( "" +  ( (float) wait_Time / customers) );
				Console.WriteLine( wait_Time );

				Console.Write( "\n\nEjecutar programa otra vez? (s/n): ");
				runAgain =Convert.ToChar( Console.ReadLine( ));
				runAgain = char.ToUpper(runAgain);
				while (runAgain != 'S' && runAgain != 'N') {
					Console.Write("Letra inválida. Ejecutar programa otra vez? (s/n): ");
					runAgain = Convert.ToChar(Console.ReadLine());
					runAgain = char.ToUpper(runAgain);
				}
			}
		}
    }
}
