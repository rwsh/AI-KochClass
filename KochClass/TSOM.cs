using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace KochClass
{
    class TSOM
    {
        public int N;
        ArrayList Map;

        double Rc;
        public double nu;

        public TSOM(int N, double Rc, double nu)
        {
            this.N = N;
            Map = new ArrayList();

            this.Rc = Rc;
            this.nu = nu;
        }

        public void Add(TX X, double dnu)
        {
            if (Count < 1)
            {
                Map.Add(new TNeuron(N, X.x, null));
                return;
            }

            double R;

            TNeuron Win = Winner(X, out R);

            if (R < Rc)
            {
                Correct(Win, X);
            }
            else
            {
                Map.Add(new TNeuron(N, X.x, null));
            }

            nu = nu - dnu;

            if (nu < 0)
            {
                nu = 0;
            }
        }

        public int GetClass(TX X)
        {
            if (Count < 1)
            {
                return -1;
            }

            double R;

            TNeuron Win = Winner(X, out R);

            if (R < Rc)
            {
                return Map.IndexOf(Win);
            }
            else
            {
                return -1;
            }
        }

        public void Correct(TNeuron Win, TX X)
        {
            for (int i = 0; i < N; i++)
            {
                Win.w[i] = Win.w[i] + nu * (X.x[i] - Win.w[i]);
            }
        }

        public TNeuron Winner(TX X, out double R)
        {
            TNeuron res = this[0];
            R = res.R(X.x);

            for (int i = 1; i < Count; i++)
            {
                double d = this[i].R(X.x);

                if (d < R)
                {
                    R = d;
                    res = this[i];
                }
            }

            return res;
        }


        public TNeuron this[int i]
        {
            get
            {
                return (TNeuron)Map[i];
            }
            set
            {
                Map[i] = value;
            }
        }
            
        public int Count
        {
            get
            {
                return Map.Count;
            }
        }

    }
}
