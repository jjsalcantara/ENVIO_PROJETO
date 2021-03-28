using System;

namespace CalculoIP3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        
            // atribui valores as campos
            ValoresVoto val = new ValoresVoto();
            val.Validos = 500000;
            val.Brancos = 100000;
            val.Nulos = 50000;
            val.TotEleitores = 700000;

            //Resultados
            Calcula calc = new Calcula();
            int pv;
            int pb;
            int pn;

            pv = calc.calculaPercentualVAlidos(val.Validos, val.TotEleitores);
            pb = calc.calculaPercentualBranco(val.Brancos, val.TotEleitores);
            pn = calc.calculaPercentualNulos(val.Nulos, val.TotEleitores);

            // Impressço dos resultados
            Console.WriteLine("Percentual de votos válidos : " +  pv);
            Console.WriteLine("Percentual de votos brancos : " + pb);
            Console.WriteLine("Percentual de abstinencia   : " + pn);
        }
    }
}
