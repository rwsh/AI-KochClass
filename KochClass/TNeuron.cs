using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace KochClass
{
    class TNeuron
    {
        public int N;

        public double[] w;

        public TNeuron(int N, double[] C, Random rnd)
        {
            this.N = N;
            w = new double[N];

            if (C != null)
            {
                for (int i = 0; i < N; i++)
                {
                    w[i] = C[i];
                }
            }

            if(rnd != null)
            {
                for (int i = 0; i < N; i++)
                {
                    w[i] = (rnd.NextDouble() - 0.5) * 2;
                    w[i] /= Math.Sqrt(N);
                }
            }
        }

        public double R(double[] X)
        {
            double res = 0;

            for (int i = 0; i < N; i++)
            {
                res += (w[i] - X[i]) * (w[i] - X[i]);
            }

            res = Math.Sqrt(res);

            return res;
        }
    }
}
