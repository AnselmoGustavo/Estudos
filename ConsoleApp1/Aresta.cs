using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Aresta
    {
        private Vertice saida;
        private Vertice entrada;
        /// <summary>
        /// Tipos podem ser 0-árvore, 1-retorno, 2-avanço, 3-cruzamento, 4-tio, 5-irmão, 6 -primo, 7-Laço
        /// </summary>
        private int tipo;

        public Aresta (Vertice saida, Vertice entrada)
        {
            this.saida = saida;
            this.entrada = entrada;
        }

        public void Tipo(int tipo) {  this.tipo = tipo; }
        public int Tipo() {return tipo;}
        public Vertice Saida() { return saida;}
        public Vertice Entrada() { return entrada;}
    }
}
