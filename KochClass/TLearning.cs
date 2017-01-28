using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KochClass
{
    class TLearning
    {
        public TLearning()
        {
            TFiler F = new TFiler("a.txt");

            TSOM SOM = new TSOM(F.N, 0.1, 0.1);

            F.Normalize();

            for (int i = 0; i < F.Count; i++)
            {
                SOM.Add(F[i], 0);
            }

            Console.WriteLine("Количество классов = {0}", SOM.Count);

            F.Out(SOM, "b.txt");
        }
    }
}

