using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAppMenu.Models
{
    public class Menu
    {
        private int menuPai = 0;

        public int MenuPai
        {
            get { return menuPai; }
            set { menuPai = value; }
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Link { get; set; }
        

        public Menu(int _id, string _itemNome, string _itemLink, int _menuPai)
        {
            Id = _id;
            Nome = _itemNome;
            Link = _itemLink;
            MenuPai = _menuPai;
        }
    }
}