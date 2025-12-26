using ExamApp;

namespace AppTest
{
    public class UnitTest1
    {
        [Fact]
        public void DijkstraTest()
        {
            double[,] matrix = new double[2, 2] { { 0, 1.5 } , {1.5, 0  } };
            int v = 1;
            double[] dist = [0, 1.5];
            double[] res = Class1.Dijkstra(matrix, v);
            Assert.Equal(res[1],dist[1]);
        }
    }
}
