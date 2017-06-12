
using System.Text;
using System.Threading.Tasks;


using System.Collections.Generic;
using System.Linq;
using System;
class Program
{
    protected static long InputNumber() { return long.Parse(Console.ReadLine()); }
    protected static string InputString() { return Console.ReadLine(); }
    protected static long[] InputNumbers() { return Console.ReadLine().Split(' ').Select(x => long.Parse(x)).ToArray(); }
    protected static string[] InputStrings() { return Console.ReadLine().Split(' '); }
    
    class Question
    {
        public int x1;
        public int x2;
        public int y1;
        public int y2;
        public Question(int _x1, int _y1, int _x2, int _y2)
        {
            x1 = _x1;
            y1 = _y1;
            x2 = _x2;
            y2 = _y2;
        }
    }

    static void Main()
    {
        // 入力
        var NMQ = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
        var N = NMQ[0];
        var M = NMQ[1];
        var Q = NMQ[2];
        bool[,] S = new bool[N, M];
        for (int i = 0; i < N; i++)
        {
            var s = InputString();
            for (int j = 0; j < M; j++)
            {
                S[i, j] = s[j] == '1';
            }
        }
        Question[] Questions = new Question[Q];
        for (int i = 0; i < Q; i++)
        {
            var line = Console.ReadLine().Split(' ').Select(x => int.Parse(x));
            Questions[i] = new Question(line.ElementAt(0) - 1, line.ElementAt(1) - 1, line.ElementAt(2) - 1, line.ElementAt(3) - 1);
        }

        // 計算
        var cell = new int[N, M];
        var edgeX = new int[N, M];
        var edgeY = new int[N, M];
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                if (i > 0 && j > 0)
                {
                    cell[i, j] = cell[i - 1, j] + cell[i, j - 1] - cell[i - 1, j - 1] + (S[i, j] ? 1 : 0);
                    if (i < N - 1)
                    {
                        edgeX[i, j] = edgeX[i - 1, j] + edgeX[i, j - 1] - edgeX[i - 1, j - 1] + (S[i, j] && S[i + 1, j] ? 1 : 0);
                    }
                    if (j < M - 1)
                    {
                        edgeY[i, j] = edgeY[i - 1, j] + edgeY[i, j - 1] - edgeY[i - 1, j - 1] + (S[i, j] && S[i, j + 1] ? 1 : 0);
                    }
                }
                else if (i > 0)
                {
                    cell[i, j] = cell[i - 1, j] + (S[i, j] ? 1 : 0);
                    if (i < N - 1)
                    {
                        edgeX[i, j] = edgeX[i - 1, j] + (S[i, j] && S[i + 1, j] ? 1 : 0);
                    }
                    if (j < M - 1)
                    {
                        edgeY[i, j] = edgeY[i - 1, j] + (S[i, j] && S[i, j + 1] ? 1 : 0);
                    }
                }
                else if (j > 0)
                {
                    cell[i, j] = cell[i, j - 1] + (S[i, j] ? 1 : 0);
                    if (i < N - 1)
                    {
                        edgeX[i, j] += edgeX[i, j - 1] + (S[i, j] && S[i + 1, j] ? 1 : 0);
                    }
                    if (j < M - 1)
                    {
                        edgeY[i, j] += edgeY[i, j - 1] + (S[i, j] && S[i, j + 1] ? 1 : 0);
                    }
                }
                else
                {
                    if (S[i, j])
                    {
                        cell[i, j] = 1;
                        edgeX[i, j] = 1;
                        edgeY[i, j] = 1;
                    }
                }
            }
        }

        for (int q = 0; q < Q; q++)
        {
            /*
            var edges = edgeX[Questions[q].x2, Questions[q].y2]
                - edgeX[Questions[q].x1, Questions[q].y2]
                - edgeX[Questions[q].x2, Questions[q].y1]
                + edgeX[Questions[q].x1, Questions[q].y1]
                + edgeY[Questions[q].x2, Questions[q].y2]
                - edgeY[Questions[q].x1, Questions[q].y2]
                - edgeY[Questions[q].x2, Questions[q].y1]
                + edgeY[Questions[q].x1, Questions[q].y1];*/
            var nodes = cell[Questions[q].x2, Questions[q].y2]
                - cell[Questions[q].x1, Questions[q].y2]
                - cell[Questions[q].x2, Questions[q].y1]
                + cell[Questions[q].x1, Questions[q].y1];
            Console.WriteLine(nodes);
        }
    }
}