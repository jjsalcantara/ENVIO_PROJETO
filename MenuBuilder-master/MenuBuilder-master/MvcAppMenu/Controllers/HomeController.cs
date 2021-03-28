using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAppMenu.Models;
using System.Text;
using System.IO;
using System.Web.UI;

namespace MvcAppMenu.Controllers
{

    public class HomeController : Controller
    {
        //Lista que armazena o menu pesquisado no banco
        List<Menu> menuLista = null;

        [HttpGet]
        public ActionResult Index()
        {
            string meuMenu = string.Empty;

            //Pesquisa os dados para montagem do menu
            menuLista = PesquisarDadosMenu();

            //Caso encontre informações...
            if (menuLista != null && menuLista.Count > 0)
            {
                meuMenu = CriarMenu();
            }

            return View((object)meuMenu);
        }

        #region CriarMenu

        /// <summary>
        /// Inicia a criação do menu percorrendo os itens roots
        /// </summary>
        /// <returns>string com menu construído</returns>
        private string CriarMenu()
        {
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlWriter = new HtmlTextWriter(stringWriter);

            //Inicia o menu
            htmlWriter.RenderBeginTag(HtmlTextWriterTag.Ul);

            //Percorre apenas o nível root, ou seja, o nível que não tem pai
            foreach (var menuItem in menuLista.Where(m => m.MenuPai == 0))
            {
                CriarSubMenu(htmlWriter, menuItem);
            }

            //finaliza o menu
            htmlWriter.RenderEndTag(); //UL

            return stringWriter.ToString();
        }

        #endregion //CriarMenu

        #region CriarSubMenu

        /// <summary>
        /// Criar a estrutura do menu com seus respectivos itens e sub itens
        /// </summary>
        /// <param name="htmlWriter">Escritor das tags html</param>
        /// <param name="itemCorrente">Item corrente do menu</param>
        private void CriarSubMenu(HtmlTextWriter htmlWriter, Menu itemCorrente)
        {
            try
            {
                //Pequisa os filhos do item corrente do menu
                var listaFilhos = menuLista.Where(m => m.MenuPai == itemCorrente.Id);

                // booleano que indica se o item corrente tem filho
                bool temFilho = listaFilhos.Count() > 0;

                htmlWriter.RenderBeginTag(HtmlTextWriterTag.Li);

                MontarItemMenu(htmlWriter, itemCorrente);

                if (temFilho)
                    htmlWriter.RenderBeginTag(HtmlTextWriterTag.Ul);

                foreach (var itemFilho in listaFilhos)
                {
                    //para cada filho do item corrente, aciona novamente o próprio método passando o itemFilho como itemCorrente
                    CriarSubMenu(htmlWriter, itemFilho);
                }

                if (temFilho)
                    htmlWriter.RenderEndTag(); //UL

                htmlWriter.RenderEndTag(); //LI
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion //CriarSubMenu

        #region MontarItemMenu
        /// <summary>
        /// Cria formatações, link e demais detalhes dos itens do menu
        /// </summary>
        /// <param name="htmlWriter">Escritor das tags html</param>
        /// <param name="itemCorrente"></param>
        private static void MontarItemMenu(HtmlTextWriter htmlWriter, Menu itemCorrente)
        {
            if (!string.IsNullOrEmpty(itemCorrente.Link))
            {
                htmlWriter.AddAttribute(HtmlTextWriterAttribute.Href, itemCorrente.Link);
                htmlWriter.RenderBeginTag(HtmlTextWriterTag.A);
                htmlWriter.Write(itemCorrente.Nome);
                htmlWriter.RenderEndTag(); //A
            }
            else
            {
                htmlWriter.Write(itemCorrente.Nome);
            }
        }

        #endregion //MontarItemMenu

        #region PesquisarDadosMenu
        /// <summary>
        /// Simula uma pesquina do menu no bando de dados.
        /// </summary>
        /// <returns></returns>
        private List<Menu> PesquisarDadosMenu()
        {
            List<Menu> menuLista = new List<Menu>();

            menuLista.Add(new Menu(1, "Elementos Processuais", string.Empty, 0));
            menuLista.Add(new Menu(2, "Processo", "ProcessoConsulta.aspx", 1));
            menuLista.Add(new Menu(3, "Nota de Expediente", "NotaExpedienteConsulta.aspx", 1));
            menuLista.Add(new Menu(4, "Andamento", "AndamentoConsulta.aspx", 1));
            menuLista.Add(new Menu(5, "Fase", "FaseConsulta.aspx", 1));

            menuLista.Add(new Menu(6, "Elementos do Direito", string.Empty, 0));
            menuLista.Add(new Menu(7, "Pessoa", "PessoaConsulta.aspx", 6));
            menuLista.Add(new Menu(8, "Contratante", "Contratante.aspx", 7));
            menuLista.Add(new Menu(9, "PessoaFisica.aspx", "Pessoa Física", 7));
            menuLista.Add(new Menu(10, "TJComarcaConsulta.aspx", "TJ Comarca", 6));

            menuLista.Add(new Menu(11, "Sair", string.Empty, 0));

            return menuLista;
        }

        #endregion //PesquisarDadosMenu
    }
}
