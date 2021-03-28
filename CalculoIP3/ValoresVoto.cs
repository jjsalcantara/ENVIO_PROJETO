using System;
using System.Collections.Generic;
using System.Text;

namespace CalculoIP3
{
    class ValoresVoto
    {
        private int _validos;
        private int _brancos;
        private int _nulos;
        private int _totEleitores;

        public int Validos
        {
            get { return _validos; }
            set { _validos = value; }
        }

        public int Brancos
        {
            get { return _brancos; }
            set { _brancos = value; }
        }

        public int Nulos
        {
            get { return _nulos; }
            set { _nulos = value; }
        }

        public int TotEleitores
        {
            get { return _totEleitores; }
            set { _totEleitores = value; }
        }
        
    }

}
