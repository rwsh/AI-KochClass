using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace KochClass
{
    class TFiler
    {
        ArrayList XX;

        public int N = -1;

        public TFiler(string Name)
        {
            XX = new ArrayList();
            StreamReader f = new StreamReader(Name);

            string s;

            while ((s = f.ReadLine()) != null)
            {
                Add(s);
            }

            f.Close();
        }

        public void Out(TSOM SOM, string Name)
        {
            StreamWriter f = new StreamWriter(Name);

            for (int i = 0; i < Count; i++)
            {
                f.WriteLine("{0}\t{1}", SOM.GetClass(this[i]) + 1, this[i].Name);
            }

            f.Close();
        }

        public void Add(string s)
        {
            if(s.Length < 3)
            {
                return;
            }

            string[] ss = s.Split('\t');
            N = ss.Count();

            TX X = new TX(N, s, null);

            for (int i = 0; i < N; i++)
            {
                try
                {
                    X.x[i] = Convert.ToDouble(ss[i]);
                }
                catch
                {
                    return;
                }
            }

            XX.Add(X);
        }

        public void Normalize()
        {
            for (int i = 0; i < Count; i++)
            {
                this[i].Normalize();
            }
        }

        public TX this[int i]
        {
            get
            {
                return (TX)XX[i];
            }
            set
            {
                XX.Add(value);
            }
        }
        

        public int Count
        {
            get
            {
                return XX.Count;
            }
        }
    }
}
