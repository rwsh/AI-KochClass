﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KochClass
{
    class TX
    {
        public int N;
        public double[] x;
        public string Name;

        public TX(int N, string Name, double[] c)
        {
            this.N = N;
            this.Name = Name;
            x = new double[N];

            if (c != null)
            {
                for (int i = 0; i < N; i++)
                {
                    x[i] = c[i];
                }
            }
        }

        public void Normalize()
        {
            double M = Double.MinValue;

            for (int i = 0; i < N; i++)
            {
                if (Math.Abs(x[i]) > M)
                {
                    M = Math.Abs(x[i]);
                }
            }

            for (int i = 0; i < N; i++)
            {
                x[i] /= M;
            }
        }
    }
}
