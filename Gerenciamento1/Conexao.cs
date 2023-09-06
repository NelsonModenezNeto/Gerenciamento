using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciamento1
{
    internal class Conexao
    {
        private MySqlConnection connection;
        private string connectionString;

        public Conexao()
        {
            connectionString = "Server=aws.connect.psdb.cloud;Database=teste;user=020o089ewed28p8h4exj;password=pscale_pw_RzJQVpasEXp59YThGrWmLDQ0f7kNxGGqLRQXLmd6AbB;SslMode=VerifyFull";
            connection = new MySqlConnection(connectionString);
        }

        public void AbrirConexao()
        {
            try
            {
                connection.Open();
                Console.WriteLine("Conexão bem-sucedida!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao conectar: {ex.Message}");
            }
        }

        public void FecharConexao()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
                Console.WriteLine("Conexão fechada.");
            }
        }

        public void ExecutarQuery(string query)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                Console.WriteLine("Consulta executada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao executar a consulta: {ex.Message}");
            }
        }
        public MySqlConnection RetornarConexao()
        {
            return connection;
        }

    }
}
