using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyatnashkiwinF
{
    class Pyatnashki
    {
        public int N { get; private set; }
        public int[,] Area { get; private set; }
        public int Count { get; private set; }
        public DateTime StartedAt { get; private set; }
        History history;
        public void Save()
        {
            history.history.Push(new Memento15(N, Area, Count, StartedAt));
        }
        public void Undo()
        {
            if (history.history.Count > 0)
            {
                Memento15 memento15 = history.history.Pop();
                N = memento15.N;
                Area = memento15.Area;
                Count = memento15.Count;
                StartedAt = memento15.StartedAt;
            }
        }
        public Pyatnashki(int n = 4)
        {
            history = new History();
            N = n;
            Area = new int[n, n];
            Count = 0;
            StartedAt = DateTime.Now;
            Generator();
        }
        private void Generator()
        {
            int num = 0;
            for(int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    Area[i, j]=num++;
            Random random = new Random();
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                {
                    int x = random.Next(N);
                    int y = random.Next(N);
                    num = Area[i, j];
                    Area[i, j] = Area[x,y];
                    Area[x, y] = num;
                }
        } 
        public bool IsWinner()
        {
            int num = 1;
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                {
                    if (i == N - 1 && j == N - 1)
                        return true;
                    if (Area[i, j] != num++)
                        return false;
                }
            return true;
        }
        public void Step(int x, int y)
        {
            Count++;
            if(x > 0 && Area[y, x - 1] == 0)
            {
                Area[y, x - 1] = Area[y, x];
                Area[y, x] = 0;
            }
            if (y > 0 && Area[y - 1, x] == 0)
            {
                Area[y-1, x] = Area[y, x];
                Area[y, x] = 0;
            }
            if (x < N - 1 && Area[y, x + 1] == 0)
            {
                Area[y, x + 1] = Area[y, x];
                Area[y, x] = 0;
            }
            if (y < N - 1 && Area[y + 1, x] == 0)
            {
                Area[y + 1, x] = Area[y, x];
                Area[y, x] = 0;
            }
        }
    }
}
