using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONet
{
    class Program
    {
        static void Main(string[] args)
        {
            GravarProdutoNoBanco();
        }

        private static void GravarProdutoNoBanco()
        {
            ProdutoDAO produtoDAO = new ProdutoDAO();

            produtoDAO.Adicionar(new Produto()
            {
                Nome = "Lantera",
                Descricao = "Luz xenom extra forte.",
                Imagem = "https://http2.mlstatic.com/D_Q_NP_235121-MLB20705073330_052016-Q.jpg"
            });

        }
    }
}
