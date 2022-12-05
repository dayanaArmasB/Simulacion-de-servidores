using System;
using System.Collections.Generic;
using System.Text;

namespace ColaListaEnlazada {
    class ColaLE {
        public Nodo Primero { get; set; }

        public ColaLE() {
            Primero = null;
        }

        public void AgregaInicio(string dato) {
            if (Primero == null) {
                Nodo nueVag = new Nodo(dato);

                Primero = nueVag;
            } else if (Primero.Sig == null) {
                Nodo nueVag = new Nodo(dato);

                Nodo priVag = Primero;
                nueVag.Sig = priVag;
                Primero = nueVag;
            } else {
                Nodo nueVag = new Nodo(dato);

                Nodo priVag = Primero;
                nueVag.Sig = priVag;
                Primero = nueVag;

            }
        }

        public void AgregaInicio2(string dato) {
            Nodo nueVag = new Nodo(dato);
            if (Primero != null) {
                nueVag.Sig = Primero;
            }
            Primero = nueVag;
        }


        public override string ToString() {
            string tren = "";
            Nodo tmp = Primero;
            while (tmp != null) {
                tren = tren + tmp.Dato + ", ";
                tmp = tmp.Sig;
            }
            return tren;
        }

        public void Enqueue(string dato) {
            if (Primero == null) {
                Nodo nueVag = new Nodo(dato);

                Primero = nueVag;
            } else if (Primero.Sig == null) {
                Nodo nueVag = new Nodo(dato);

                Nodo priVag = Primero;
                priVag.Sig = nueVag;
            } else {
                Nodo nueVag = new Nodo(dato);

                Nodo tmp = Primero;
                while (tmp.Sig != null) {
                    tmp = tmp.Sig;
                }
                tmp.Sig = nueVag;
            }
        }

        public string Dequeue() {
            if (Primero == null) {
                return "";
            } else if (Primero.Sig == null) {
                string valor = Primero.Dato;
                Primero = null;
                return valor;
            } else {
                Nodo priVag = Primero;
                string valor = priVag.Dato;
                Primero = priVag.Sig;
                priVag.Sig = null;
                return valor;
            }
        }

        public string Front() {
            if (Primero == null) {
                return "";
            } else {
                return Primero.Dato;
            } 
        }

        public bool Empty() {
            return (Primero == null);
        }
        public int Size() {
            //TODO: recorrer y contar nodos
            int cont = 0;
            Nodo tmp = Primero;
            while (tmp != null) {
                cont++;
                tmp = tmp.Sig;
            }
            return cont;
        }

        public string Get(int pos) {
            //TODO: recorrer y retormnar el valor del nodo cuya posicion se recibe
            int indice = -1;
            Nodo tmp = Primero;
            while (tmp != null) {
                indice++;
                if (indice == pos) {
                    return tmp.Dato;
                }
                tmp = tmp.Sig;
            }
            return "";
        }

        public void EliminaFinal() {
            if (Primero == null) {

            } else if (Primero.Sig == null) {
                Primero = null;
            } else {
                Nodo tmp = Primero;
                while (tmp.Sig.Sig != null) {
                    tmp = tmp.Sig;
                }
                tmp.Sig = null;
            }
        }
    }
}
