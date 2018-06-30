using System.Data;
using System.Data.SqlClient;

namespace ADONet
{
    class ProdutoDAO: System.IDisposable
    {
        private IDbConnection conexao;

        public ProdutoDAO()
        {
            this.conexao = new SqlConnection("Data Source=DESKTOP-K6073DO;Initial Catalog=HondaFitParts;Persist Security Info=True;User ID=sa;Password=asdasd");
            this.conexao.Open();
        }

        public void Dispose()
        {
            this.conexao.Close();
        }

        internal void Adicionar(Produto produto) {
            IDbCommand cmd = conexao.CreateCommand();
            cmd.CommandText = @"INSERT INTO [dbo].[Produto] ([Nome],[Descricao],[Imagem]) VALUES (@Nome ,@Descricao ,@Imagem)";

            IDbDataParameter paranNome = new SqlParameter("Nome", produto.Nome);
            cmd.Parameters.Add(paranNome);

            IDbDataParameter paranDescricao = new SqlParameter("Descricao", produto.Descricao);
            cmd.Parameters.Add(paranDescricao);

            IDbDataParameter paranImagem = new SqlParameter("Imagem", produto.Imagem);
            cmd.Parameters.Add(paranImagem);

            cmd.ExecuteNonQuery();
        }
    }
}
