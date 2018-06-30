using System.Data;
using System.Data.SqlClient;

namespace ADONet
{
    class ProdutoDAO: System.IDisposable
    {
        private IDbConnection conexao;

        public ProdutoDAO()
        {
            this.conexao.ConnectionString = "Data Source=DESKTOP-K6073DO;Initial Catalog=HondaFitParts;Persist Security Info=True;User ID=sa;Password=asdasd";            
            this.conexao.Open();
        }
    }
}
