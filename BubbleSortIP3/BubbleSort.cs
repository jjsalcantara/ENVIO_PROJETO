using System;
using System.Collections.Generic;
using System.Text;

namespace BubbleSortIP3
{
    class BubbleSort
    {
        public void ordena(double [] vetor)
        {
            double temp;
            for (int j = 0; j <= vetor.Length - 2; j++)
            {
                for (int i = 0; i <= vetor.Length - 2; i++)
                {
                    if (vetor[i] > vetor[i + 1])
                    {
                        temp = vetor[i + 1];
                        vetor[i + 1] = vetor[i];
                        vetor[i] = temp;
                    }
                }
            }

            Console.WriteLine("Resultado:");
            foreach (double p in vetor)
                Console.Write(p + " ");
            Console.Read();
        }
    }
}
