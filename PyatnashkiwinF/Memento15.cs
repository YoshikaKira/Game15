using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyatnashkiwinF
{
    class Memento15
    {
        public int N { get; private set; }
        public int[,] Area { get; private set; }
        public int Count { get; private set; }
        public DateTime StartedAt { get; private set; }
        public Memento15(int n, int[,]area, int count, DateTime start)
        {
            N = n;
            Area = new int[N, N];
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    Area[i, j] = area[i, j];
            Count = count;
            StartedAt = start;
        }
    }
}
