// See https://aka.ms/new-console-template for more information

using ConsoleApp1;

GrafoNDirecionado grafo = new GrafoNDirecionado();

Vertice v1 = new Vertice(0);
Vertice v2 = new Vertice(1);
Vertice v3 = new Vertice(2);
Vertice v4 = new Vertice(3);
Vertice v5 = new Vertice(4); 

grafo.AdicionarVertice(v1);
grafo.AdicionarVertice(v2);
grafo.AdicionarVertice(v3);
grafo.AdicionarVertice(v4);
grafo.AdicionarVertice(v5);

// Adiciona arestas (grafo não direcionado)
grafo.AdicionarAresta(v1, v2);
grafo.AdicionarAresta(v1, v3);
grafo.AdicionarAresta(v1, v5);
grafo.AdicionarAresta(v2, v3);
grafo.AdicionarAresta(v2, v4);
grafo.AdicionarAresta(v3, v4);
grafo.AdicionarAresta(v3, v5);

// Gera a matriz de adjacência e a imprime
int[,] matrizAdj = CriarMatrizAdjacencia(grafo);
Console.WriteLine("Matriz de Adjacência:");
ImprimirMatriz(matrizAdj);

//Gera a matriz de incidência e a imprime
int[,] matrizInc = CriarMatrizIncidencia(grafo);
Console.WriteLine("Matriz Incidência:");
ImprimirMatriz(matrizInc);

//Gera a lista de adjacência e a imprime:
Console.WriteLine("Lista de Adjacência");
ListaAdjacencia(grafo);

Buscas busca = new Buscas(grafo, v1);
busca.BuscaProfundidadeNDirecionado();
Console.ReadLine();

static int[,] CriarMatrizAdjacencia(GrafoNDirecionado grafo)
{
    int n=grafo.Vertices().Count;
    int[,] matriz=new int[n,n];

    foreach (Aresta aresta in grafo.Arestas())
    {
        int i = aresta.Saida().Name();
        int j = aresta.Entrada().Name();
        matriz[i, j] = 1;
        matriz[j,i] = 1;
    }
    return matriz;
}

static int [,] CriarMatrizIncidencia(GrafoNDirecionado grafo)
{
    int n = grafo.Vertices().Count;
    int m = grafo.Arestas().Count;
    int[,] matriz = new int[n, m];

    List<Aresta> arestas = grafo.Arestas();
    for(int coluna = 0; coluna < m; coluna++)
    {
        Aresta aresta = arestas[coluna];
        int i = aresta.Saida().Name();
        int j = aresta.Entrada().Name();

        matriz[i, coluna] = 1;
        matriz[j, coluna] = 1;
    }
    return matriz;
}

static void ListaAdjacencia(GrafoNDirecionado grafo)
{
    foreach(Vertice v in  grafo.Vertices())
    {
        Console.Write("V"+ v.Name());
        foreach(Vertice w in v.Vizinhanca())
        {
            Console.Write("-> V" +w.Name());
        }
        Console.WriteLine();
    }
}

static void ImprimirMatriz(int[,] matriz)
{
    int linhas=matriz.GetLength(0);
    int colunas=matriz.GetLength(1);
    for(int i = 0; i < linhas; i++)
    {
        for(int j = 0; j < colunas; j++)
        {
            Console.Write(matriz[i,j]+"\t");
        }
        Console.WriteLine();
    }
}

