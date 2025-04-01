using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class GrafoNDirecionado
    {
        private List<Vertice> vertices;
        private List<Aresta> arestas;
        public GrafoNDirecionado()
        {
            vertices = new List<Vertice>();
            arestas = new List<Aresta>();
        }
        public List<Vertice> Vertices() { return vertices; }
        public List<Aresta> Arestas() { return arestas; }

        public void AdicionarVertice(Vertice v)
        {
            vertices.Add(v);
        }
        public void AdicionarAresta(Vertice v1, Vertice v2)
        {
            Aresta aresta = new Aresta(v1, v2);
            arestas.Add(aresta);
            v1.AdicionarVizinho(v2);
            v2.AdicionarVizinho(v1);
        }
        public void VisitarAresta(Vertice saida, Vertice entrada, int tipo)
        {
            Aresta aresta = AcharAresta(saida, entrada);

            aresta.Tipo(tipo);
        }
        private Aresta AcharAresta(Vertice saida, Vertice entrada)
        {
            foreach (Aresta aresta in arestas)
            {
                if((aresta.Saida()==saida && aresta.Entrada() == entrada) || (aresta.Saida()==entrada && aresta.Entrada() == saida))
                {
                    return aresta;
                }
            }
            return null;
        }
        public Vertice RetornarVertice(int name)
        {
            foreach (Vertice vertice in vertices)
            {
                if (name==vertice.Name())
                {
                    return vertice;
                }
            }
            return null;
        }
    }
}
