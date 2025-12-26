int n = 0;
EnterNumberOfDot();
double[,] matrix = new double[n,n];
InitMatrix();
SearchShortestDistanse();





void EnterNumberOfDot()
{
    int numberOfDot = 9; //количество точек на карте
    while (n != numberOfDot)
    {
        Console.Write("Введите количество точек на карте: ");
        n = int.Parse(Console.ReadLine());
        if (n == numberOfDot)
        {
            break;
        }
        else
        {
            Console.WriteLine("Количество точек не соответсвует карте");
        }
    }
}
void InitMatrix()
{
    int n1 = -1,n2 = -1;
    double distanse;
    while (n1 != 0 || n2 != 0)
    {
        Console.WriteLine("Введите две вершины и растояние между ними(для прекращения ввода введите 0): ");
        Console.Write("Первая вершина: ");
        n1 = int.Parse(Console.ReadLine());
        if (n1 == 0)
            break;
        Console.Write("Вторая вершина: ");
        n2 = int.Parse(Console.ReadLine());
        if (n2 == 0)
            break;
        Console.Write("Расстояние между ними: ");
        distanse = double.Parse(Console.ReadLine());
        matrix[n1 - 1,n2 - 1] = distanse;
        matrix[n2 - 1,n1 - 1] = distanse;
    }
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            if (matrix[i,j] == 0)
            {
                matrix[i, j] = double.MaxValue;
            }
        }
    }
}

void SearchShortestDistanse()
{
    {
        int n1 = -1, n2 = -1;
        while (n1 != 0 || n2 != 0)
        {
            Console.WriteLine("Введите две вершины (для прекращения ввода введите 0): ");
            Console.Write("Первая вершина: ");
            n1 = int.Parse(Console.ReadLine());
            if (n1 == 0)
                break;
            Console.Write("Вторая вершина: ");
            n2 = int.Parse(Console.ReadLine());
            if (n2 == 0)
                break;
            double[] shortestDistanse = Dijkstra(matrix, n1 - 1);
            Console.WriteLine($"Кратчайшее растояние между вершинами {n1} и {n2} = {shortestDistanse[n2 - 1]}");
        }
    }






    /*Реализация алгоритма Дейкстры для поиска кратчайших путей во взвешенном графе.
     * Входные данные:      а - матрица инцидентности взвешенного графа
     *                      v0 - номер вершины, для которой вычисляются кратчайшие расстояния
     *                           до остальных вершин
     * Выходные данные:     одномерный массив кратчайших расстояний от вершины а 
     *                      до каждой из вершин графа (включая саму вершину а)
    */

    double[] Dijkstra(double[,] a, int v0)
    {
        double[] dist = new double[n];
        bool[] vis = new bool[n];
        int unvis = n;
        int v;

        for (int i = 0; i < n; i++)
            dist[i] = Double.MaxValue;
        dist[v0] = 0.0;

        while (unvis > 0)
        {
            v = -1;
            for (int i = 0; i < n; i++)
            {
                if (vis[i])
                    continue;
                if ((v == -1) || (dist[v] > dist[i]))
                    v = i;
            }
            vis[v] = true;
            unvis--;
            for (int i = 0; i < n; i++)
            {
                if (dist[i] > dist[v] + a[v, i])
                    dist[i] = dist[v] + a[v, i];
            }
        }
        return dist;
    }
}