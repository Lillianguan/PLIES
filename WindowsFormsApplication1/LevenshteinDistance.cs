using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class LevenshteinDistance
    {
        public static int Compute(string a, string b)
        {
            if (a == b)
                return 0;
            if (a.Length == 0 || b.Length == 0)
                return a.Length == 0 ? b.Length : a.Length;
            int len1 = a.Length + 1,
                len2 = b.Length + 1,
                I = 0,        
                i = 0,
                c, j, J;
            int[,] d = new int[len1, len2];
            while (i < len2)
                d[0, i] = i++;
            i = 0;
            while (++i < len1)
            {
                J = j = 0;
                c = a[I];
                d[i, 0] = i;
                while (++j < len2)
                {
                    d[i, j] = Math.Min(Math.Min(d[I, j] + 1, d[i, J] + 1), d[I, J] + (c == b[J] ? 0 : 1));
                    ++J;
                };
                ++I;
            };
            return d[len1 - 1, len2 - 1];

            //int n = s.Length;
            //int m = t.Length;
            //int[,] d = new int[n + 1, m + 1];

            //// Step 1
            //if (n == 0)
            //{
            //    return m;
            //}

            //if (m == 0)
            //{
            //    return n;
            //}

            //// Step 2
            //for (int i = 0; i <= n; d[i, 0] = i++)
            //{
            //}

            //for (int j = 0; j <= m; d[0, j] = j++)
            //{
            //}

            //// Step 3
            //for (int i = 1; i <= n; i++)
            //{
            //    //Step 4
            //    for (int j = 1; j <= m; j++)
            //    {
            //        // Step 5
            //        int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

            //        // Step 6
            //        d[i, j] = Math.Min(
            //            Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
            //            d[i - 1, j - 1] + cost);
            //    }
            //}
            //// Step 7
            //return d[n, m];
        }
    }
}
