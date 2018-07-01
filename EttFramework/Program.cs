namespace ADONet
{
    class Program
    {
        static void Main(string[] args)
        {
            //GravarProduto();
            //AtualizarProduto();
            ListarProdutos();
        }

        private static void ListarProdutos()
        {
            ProdutoDAO produtoDAO = new ProdutoDAO();
            var produtos = produtoDAO.Produtos();
        }

        private static void AtualizarProduto()
        {
            ProdutoDAO produtoDAO = new ProdutoDAO();
            produtoDAO.Atualizar(new Produto()
            {
                Id = 1,
                Nome = "Lantera V2",
                Descricao = "Luz xenom extra forte.",
                Imagem = "https://http2.mlstatic.com/D_Q_NP_235121-MLB20705073330_052016-Q.jpg"
            });
        }

        private static void GravarProduto()
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
