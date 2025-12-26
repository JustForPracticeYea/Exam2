using ExamApp;

EnterNumberOfDot();
double[,] matrix = new double[Class1.n, Class1.n];
InitMatrix();
SearchShortestDistanse();





void EnterNumberOfDot()
{
    int numberOfDot = 9; //количество точек на карте
    while (Class1.n != numberOfDot)
    {
        Console.Write("Введите количество точек на карте: ");
        Class1.n = int.Parse(Console.ReadLine());
        if (Class1.n == numberOfDot)
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
    for (int i = 0; i < Class1.n; i++)
    {
        for (int j = 0; j < Class1.n; j++)
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
            double[] shortestDistanse = Class1.Dijkstra(matrix, n1 - 1);
            Console.WriteLine($"Кратчайшее растояние между вершинами {n1} и {n2} = {shortestDistanse[n2 - 1]}");
        }
    }
}