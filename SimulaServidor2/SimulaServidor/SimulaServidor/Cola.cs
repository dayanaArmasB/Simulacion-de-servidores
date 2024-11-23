using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElementType = System.Int64;

namespace SimulaServidor {

    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }
        public Node<T> Prev { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
            Prev = null;
        }
    }

    public class Cola<T>
    {
        private Node<T> first;
        private Node<T> last;
        private int size = 0;

        public Cola()
        {
            first = null;
            last = null;
        }

        // Añadir un elemento al final de la cola
        public void Enqueue(T item)
        {
            Node<T> newNode = new Node<T>(item);

            if (first == null)
            { // Si la cola está vacía
                first = newNode;
                last = newNode;
            }
            else
            { // Añadir al final
                last.Next = newNode;
                newNode.Prev = last;
                last = newNode;
            }
            size++;
        }

        // Eliminar un elemento del inicio de la cola
        public T Dequeue()
        {
            if (first == null)
            {
                throw new InvalidOperationException("La cola está vacía.");
            }

            T data = first.Data;
            first = first.Next;

            if (first == null)
            { // Si la cola quedó vacía
                last = null;
            }
            else
            {
                first.Prev = null;
            }
            size--;
            return data;
        }

        // Obtener el primer elemento de la cola
        public T Front()
        {
            if (first == null)
            {
                throw new InvalidOperationException("La cola está vacía.");
            }
            return first.Data;
        }

        // Obtener el tamaño de la cola
        public int GetSize()
        {
            return size;
        }

        // Verificar si la cola está vacía
        public bool IsEmpty()
        {
            return size == 0;
        }
    }
}
