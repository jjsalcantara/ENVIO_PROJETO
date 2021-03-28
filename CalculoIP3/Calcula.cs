using System;
using System.Collections.Generic;
using System.Text;

namespace CalculoIP3
{
    class Calcula
    {
        public int calculaPercentualBranco(int totB, int totE)
        {
            int div_100 = totE / 100;
            int percentual = totB /  div_100;
            return percentual;
        }

        public int calculaPercentualVAlidos(int totV, int totE)
        {
            int div_100 = totE / 100;
            int percentual = totV / div_100;
            return percentual;
        }

        public int calculaPercentualNulos(int totN, int totE)
        {
            int div_100 = totE / 100;
            int percentual = totN / div_100;
            return percentual;
        }
    }
}
