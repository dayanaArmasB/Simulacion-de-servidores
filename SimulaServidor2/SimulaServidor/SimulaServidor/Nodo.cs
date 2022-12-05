using System;
using System.Collections.Generic;
using System.Text;

namespace ColaListaEnlazada {
    class Nodo {
        public string Dato { get; set; }
        public Nodo Sig { get; set; }

        public Nodo() {
        }

        public Nodo(string dato) {
            this.Dato = dato;
            this.Sig = null;
        }
    }
}
