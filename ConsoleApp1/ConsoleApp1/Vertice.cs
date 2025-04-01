using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Vertice
    {
        private int name;
        private List<Vertice> vizinhanca;
        private List<Aresta> listaArestas;
        private int td;
        private int tt;
        private Vertice pai;

        public Vertice(int name)
        {
            this.name = name;
            vizinhanca = new List<Vertice>();
            listaArestas = new List<Aresta>();
        }

        public int Name() { return name; }
        public int Td() { return td; }
        public void Td(int td) { this.td = td; }
        public int Tt() {  return tt; }
        public void Tt(int tt) { this.tt = tt; }
        public Vertice Pai() { return pai; }
        public void Pai(Vertice pai) { this.pai=pai; }
        public void AdicionarAresta(Aresta aresta)
        {
            listaArestas.Add(aresta);
        }

        public List<Vertice> Vizinhanca()
        {
            return vizinhanca;    
        }
        public void AdicionarVizinho(Vertice v)
        {
            if (!vizinhanca.Contains(v))
            {
                vizinhanca.Add(v);
            }
        }

    }
}
