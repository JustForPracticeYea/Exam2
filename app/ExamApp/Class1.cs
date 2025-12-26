using System;
using System.Collections.Generic;
using System.Text;

namespace ExamApp
{
    public class Class1
    {
        public static int n = 0;
            /*Реализация алгоритма Дейкстры для поиска кратчайших путей во взвешенном графе.
         * Входные данные:      а - матрица инцидентности взвешенного графа
         *                      v0 - номер вершины, для которой вычисляются кратчайшие расстояния
         *                           до остальных вершин
         * Выходные данные:     одномерный массив кратчайших расстояний от вершины а 
         *                      до каждой из вершин графа (включая саму вершину а)
        */

        public static double[] Dijkstra(double[,] a, int v0)
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
}
