using System;

namespace BubbleSortIP3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            double[] vec = { 5, 7, 0.1, 4, 7, 9, 0, 1, 2, 90, 9, 7, 3, 9.7 };
            BubbleSort bs = new BubbleSort();
            bs.ordena(vec);
        }
    }
}
