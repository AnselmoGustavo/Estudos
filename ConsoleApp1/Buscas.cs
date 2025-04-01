using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Buscas
    {
        public static int t;
        private GrafoNDirecionado grafo;
        private int raiz;
        public Buscas(GrafoNDirecionado grafo, Vertice raiz)
        {
            this.grafo = grafo; 
            this.raiz = raiz.Name();
        }

        public void BuscaProfundidadeNDirecionado()
        {
            t = 0;
            foreach (Vertice v in grafo.Vertices())
            {
                v.Td(0);
                v.Tt(0);
                v.Pai(null);
            }
            bool primeiraChamada = true;
            while (!VerificarTD(grafo))
            {
                if(primeiraChamada)
                {
                    Console.WriteLine("Iniciando DFS a partir da raiz:" + raiz);
                    ExecutarBuscaProfundidadeNDirecionado(grafo.RetornarVertice(raiz));
                    primeiraChamada = false;
                }
                else
                {
                    Vertice proximo = grafo.Vertices().FirstOrDefault(v=>v.Td()==0);
                    if(proximo!=null)
                    {
                        Console.WriteLine("Continuando DFS a partir do vértice não visitado:" + proximo.Name());
                        ExecutarBuscaProfundidadeNDirecionado(proximo);
                    }
                }
            }
            Console.WriteLine("Busca em profundidade concluída");
        }

        private void ExecutarBuscaProfundidadeNDirecionado(Vertice v)
        {
            t++; v.Td(t);   
            Console.WriteLine($"\nVisitando vértice {v.Name()} -> TD:{v.Td()}");
            foreach(Vertice w in v.Vizinhanca())
            {
                if (w.Td() == 0)
                {
                    Console.WriteLine($"Aresta árvore: {v.Name()} -> {w.Name()}");
                    grafo.VisitarAresta(v, w, 0); w.Pai(v);
                    Console.WriteLine("Pai de W: " + w.Pai().Name());
                    ExecutarBuscaProfundidadeNDirecionado(w);
                }
                else if (w.Tt()==0 && v.Pai()!=w)
                {
                    Console.WriteLine($"Aresta retorno: {v.Name()} -> {w.Name()}");
                    grafo.VisitarAresta(v, w, 1);
                }
            }
            t++; v.Tt(t);
            Console.WriteLine($"Finalizando vértice {v.Name()} -> TT: {v.Tt()}");
        }
        private bool VerificarTD(GrafoNDirecionado grafo)
        {
            bool verificado=false;

            foreach(Vertice v in grafo.Vertices())
            {
                if (v.Td() == 0)
                {
                    return verificado;
                }
            }
            return true;
        }
    }
}
