using System;
using System.Collections.Generic;
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
            cmd.CommandText = @"INSERT INTO [dbo].[Produto] (
                                     [Nome]
                                    ,[Descricao]
                                    ,[Imagem]) 
                                VALUES (
                                      @Nome
                                    , @Descricao
                                    , @Imagem)";

            IDbDataParameter paranNome = new SqlParameter("Nome", produto.Nome);
            cmd.Parameters.Add(paranNome);

            IDbDataParameter paranDescricao = new SqlParameter("Descricao", produto.Descricao);
            cmd.Parameters.Add(paranDescricao);

            IDbDataParameter paranImagem = new SqlParameter("Imagem", produto.Imagem);
            cmd.Parameters.Add(paranImagem);

            cmd.ExecuteNonQuery();
        }

        internal void Atualizar(Produto produto)
        {
            IDbCommand cmd = conexao.CreateCommand();
            cmd.CommandText = @"UPDATE [dbo].[Produto]
                                   SET [Nome] = @Nome
                                      ,[Descricao] = @Descricao
                                      ,[Imagem] = @Imagem
                                 WHERE Id = @Id";

            IDbDataParameter paranId = new SqlParameter("Id", produto.Id);
            cmd.Parameters.Add(paranId);

            IDbDataParameter paranNome = new SqlParameter("Nome", produto.Nome);
            cmd.Parameters.Add(paranNome);

            IDbDataParameter paranDescricao = new SqlParameter("Descricao", produto.Descricao);
            cmd.Parameters.Add(paranDescricao);

            IDbDataParameter paranImagem = new SqlParameter("Imagem", produto.Imagem);
            cmd.Parameters.Add(paranImagem);

            cmd.ExecuteNonQuery();
        }

        internal void Remover(Produto produto)
        {
            IDbCommand cmd = conexao.CreateCommand();
            cmd.CommandText = @"DELETE [dbo].[Produto] WHERE Id = @Id";

            IDbDataParameter paranId = new SqlParameter("Id", produto.Id);
            cmd.Parameters.Add(paranId);

            cmd.ExecuteNonQuery();
        }

        internal IList<Produto> Produtos()
        {
            List<Produto> lista = new List<Produto>();

            IDbCommand cmd = conexao.CreateCommand();
            cmd.CommandText = @"SELECT * FROM [dbo].[Produto]";

            IDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Produto produto = new Produto();
                produto.Id = Convert.ToInt32(dataReader["Id"]);
                produto.Nome = Convert.ToString(dataReader["Nome"]);
                produto.Descricao = Convert.ToString(dataReader["Descricao"]);
                produto.Imagem = Convert.ToString(dataReader["Imagem"]);
                lista.Add(produto);

                Console.Write(string.Format("Produto: {0}, {1}, {2}, {3}", produto.Id, produto.Nome, produto.Descricao, ));
            }

            Console.Read();
            return lista;
        }
    }
}
