using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoder
{
    class ABC067
    {
        void A()
        {
            var rgb = Console.ReadLine().Split(' ');
            var r = int.Parse(rgb[0]);
            var g = int.Parse(rgb[1]);
            var b = int.Parse(rgb[2]);
            if ((r * 100 + g * 10 + b) % 4 == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }

        void B()
        {
            var N = int.Parse(Console.ReadLine());
            var astr = Console.ReadLine().Split(' ');
            var a = new int[astr.Length];
            for (int i = 0; i < astr.Length; i++)
            {
                a[i] = int.Parse(astr[i]);
            }
            Console.WriteLine(a.Max() - a.Min());
        }

        void C()
        {
            var N = int.Parse(Console.ReadLine());
            var a = Console.ReadLine().Split(' ').Select(x => int.Parse(x));
            bool[] colors = new bool[8];
            int others = 0;
            foreach (var rate in a)
            {
                if (rate >= 3200)
                {
                    others++;
                }
                else
                {
                    colors[rate / 400] = true;
                }
            }
            var min = colors.Count(x => x);
            var max = min + others;
            Console.WriteLine($"{(min > 0 ? min : 1)} {max}");
        }

        static void D()
        {
            var N = int.Parse(Console.ReadLine());
            var S = Console.ReadLine();
            int left = 0;
            for (int i = 0; i < N; i++)
            {
                if (S[i] == '(')
                {
                    left++;
                }
                else
                {
                    if (left > 0)
                    {
                        left--;
                    }
                    else
                    {
                        S = "(" + S;
                        N++;
                        i++;
                    }
                }
            }
            while (left-- > 0)
            {
                S = S + ")";
            }
            Console.WriteLine(S);
        }
    }
}
