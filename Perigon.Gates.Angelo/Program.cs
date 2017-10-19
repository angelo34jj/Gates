using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perigon.Gates.Angelo
{
    class Program
    {
        static void Main(string[] args)
        {
            string sDepth = Console.ReadLine();
            // 4
            string sGates = Console.ReadLine();
            // L,R,R,L,L,L,L,R,L,R,R,L,L,R,L

            FindEmpty(sDepth, sGates);
            Console.ReadLine();

                
        }


        private static void FindEmpty(string sDepth, string sGates)
        {
            int depth = 0;

            if (!int.TryParse(sDepth, out depth))
            {
                Console.WriteLine("Depth not a number");
                return;
            }

            double noGates = Math.Pow(2, depth) - 1;

            string[] gates = sGates.Split(',');
            int[] bucket = new int[(int)Math.Pow(2,depth)];

            if (gates.Count() != noGates)
            {
                Console.WriteLine("Gates do not match depth");
                return;
            }

            Dictionary<int, string> dGates = new Dictionary<int, string>();

            for (int i=1; i<=noGates; i++)
            {
                dGates.Add(i, gates[i - 1]);
            };

            int bottomStart = (int)Math.Pow(2, depth);

            for (int i=1; i<=16; i++) // assuming 16 balls
            {
                int currentGate = 1;
                for (int gate=1; gate <= depth; gate++)
                {
                    if (dGates[currentGate] == "L")
                    {
                        dGates[currentGate] = "R";
                        currentGate = currentGate * 2;
                    }
                    else
                    {
                        dGates[currentGate] = "L";
                        currentGate = currentGate * 2 + 1;
                    }
                }
                bucket[currentGate - bottomStart] += 1;
            }

            Console.WriteLine("The following are empty");
            for (int i=0; i < bucket.Count(); i++)
            {
                if (bucket[i] == 0)
                {
                    if (depth <= 4)
                    {
                        Char c = (Char)(65 + i);
                        Console.WriteLine(c.ToString());
                    }
                    else
                    {
                        // in calse of higher depths no alphabet
                        Console.WriteLine($"Bucket {i + 1}");
                    }
                }
            }
            
        }
    }
}
