using System;
using System.Web.UI;
using Microsoft.SharePoint;
using System.Text;
using System.Diagnostics;

namespace DBS.CarasNovas.CarasNovas
{
    public partial class CarasNovasUserControl : UserControl
    {
        private int limiteColaboradoresProcurar = 4;
        private SPWeb oWebsiteRoot;

        /// <summary>
        /// Valida se todas as listas e colunas que serão usadas existem no site
        /// </summary>
        private void carregaConfereVariaveis()
        {
            oWebsiteRoot = SPContext.Current.Site.RootWeb;

            //Lista vazia que pode ter as listas e colunas não encontradas
            StringBuilder itensNaoEncontrados = new StringBuilder();

            #region "Lista de Usuários"

            String[] colunasListaUsuarios = 
            { 
               // "Data_x0020_Admissao", 
                "Nome Resumido",
                "Setor",
                "Ramal"/*,
                "PublishingContactEmail"*/
            };

            SPList usuarios = oWebsiteRoot.SiteUserInfoList;

            //loop para checar se as colunas existem
            foreach (String coluna in colunasListaUsuarios)
            {
                try
                {
                    Guid z = usuarios.Fields[coluna].Id;
                }
                catch (ArgumentException)
                {
                    itensNaoEncontrados.AppendLine("SiteUserInfoList[\"" + coluna + "\"]");
                }
            }

            #endregion "Lista de Usuários"

            if (itensNaoEncontrados.ToString().Length > 0)
            {
                throw new Exception("Os seguintes itens não foram encontrados: " +
                    Environment.NewLine + itensNaoEncontrados.ToString() +
                    " Certifique-se que eles existam no seu site antes de utilizar essa webpart.");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            carregaConfereVariaveis();
            SPListItem novoColaborador;

            //lblNomeResumido.Text = "teste da webpart";

            try
            {
                novoColaborador = getNovoColaborador();

                lblNomeResumido.Text = novoColaborador["Nome_x0020_Resumido"].ToString();

                if (novoColaborador["Setor"] != null)
                {
                    String strSetor = novoColaborador["Setor"].ToString();
                    if (strSetor.Contains("#"))
                    {
                        strSetor = strSetor.Substring(strSetor.IndexOf("#")+1);
                    }

                    lblSetor.Text = strSetor;
                }

                if (novoColaborador["PublishingContactEmail"] != null)
                    lblEmail.Text = novoColaborador["PublishingContactEmail"].ToString();

                if (novoColaborador["Ramal"] != null)
                    LblRamal.Text = novoColaborador["Ramal"].ToString();

                if (novoColaborador.Attachments.Count > 0)
                    imgFuncionario.ImageUrl = novoColaborador.Attachments.UrlPrefix + novoColaborador.Attachments[0].ToString();
            }
            catch (Exception ex)
            {
                //Microsoft.Office.Server.Diagnostics.PortalLog.LogString(ex.ToString());
                lblEmail.Text = ex.ToString();
            }
        }

        private SPListItem getNovoColaborador()
        {
            //Todos os usuários
            using (SPWeb oWebsiteRoot = SPContext.Current.Site.RootWeb)
            {
                SPList lstUsuarios = oWebsiteRoot.SiteUserInfoList;

                var query = new SPQuery
                {
                    Query = @"                                
                                    <Where>
                                        <IsNotNull>
                                            <FieldRef Name='Data_x0020_Admissao' />
                                        </IsNotNull>
                                    </Where>
                                    <OrderBy>
                                        <FieldRef Name='Data_x0020_Admissao' Ascending='False' />
                                    </OrderBy>", 
                    RowLimit = (uint) limiteColaboradoresProcurar
                };
                
                var varNovosColaboradores = lstUsuarios.GetItems(query);

                if (varNovosColaboradores.Count < limiteColaboradoresProcurar)
                {
                    limiteColaboradoresProcurar = varNovosColaboradores.Count;
                }

                //Escolho um dos colaboradores randomicamente
                Random rand = new Random();
                int index = rand.Next(0, limiteColaboradoresProcurar);
              
                return (SPListItem)varNovosColaboradores[index];

            }//fim do using
        }
    }
}
