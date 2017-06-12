using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoder
{
    class AGC015
    {
        protected static long InputNumber() { return long.Parse(Console.ReadLine()); }
        protected static string InputString() { return Console.ReadLine(); }
        protected static long[] InputNumbers() { return Console.ReadLine().Split(' ').Select(x => long.Parse(x)).ToArray(); }
        protected static string[] InputStrings() { return Console.ReadLine().Split(' '); }

        void A()
        {
            var NAB = InputNumbers();
            var N = NAB[0];
            var A = NAB[1];
            var B = NAB[2];

            if (A > B || N == 1 && A != B)
            {
                Console.WriteLine(0);
            }
            else
            {
                var min = A * (N - 1) + B;
                var max = A + B * (N - 1);
                Console.WriteLine((B - A) * (N - 2) + 1);
            }
        }

        void B()
        {
            var S = InputString();
            var N = S.Length;
            long ans = 0;
            for (int i = 0; i < N; i++)
            {
                ans += S[i] == 'D' ? (N - 1) * 2 - i : N - 1 + i;
            }
            Console.WriteLine(ans);
        }

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

        void C_tle()
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

            // 探索
            var visited = new bool[N, M];
            var que = new Queue<long[]>();
            for (int q = 0; q < Q; q++)
            {
                // visited の初期化
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < M; j++)
                    {
                        visited[i, j] = false;
                    }
                }

                int count = 0;
                for (int i = Questions[q].x1; i <= Questions[q].x2; i++)
                {
                    for (int j = Questions[q].y1; j <= Questions[q].y2; j++)
                    {
                        if (S[i, j] && !visited[i, j])
                        {
                            count++;
                            visited[i, j] = true;
                            que.Enqueue(new long[] { i, j });

                            while (que.Count > 0)
                            {
                                var cell = que.Dequeue();
                                var x = cell[0];
                                var y = cell[1];
                                if (x > Questions[q].x1 && S[x - 1, y] && !visited[x - 1, y])
                                {
                                    que.Enqueue(new long[] { x - 1, y });
                                    visited[x - 1, y] = true;
                                }
                                if (y < Questions[q].y2 && S[x, y + 1] && !visited[x, y + 1])
                                {
                                    que.Enqueue(new long[] { x, y + 1 });
                                    visited[x, y + 1] = true;
                                }
                                if (x < Questions[q].x2 && S[x + 1, y] && !visited[x + 1, y])
                                {
                                    que.Enqueue(new long[] { x + 1, y });
                                    visited[x + 1, y] = true;
                                }
                                if (y > Questions[q].y1 && S[x, y - 1] && !visited[x, y - 1])
                                {
                                    que.Enqueue(new long[] { x, y - 1 });
                                    visited[x, y - 1] = true;
                                }
                            }
                        }
                    }
                }
                Console.WriteLine(count);
            }
        }
    }
}
