using System;
using System.Data;
using System.Data.OleDb;
using TetrisChallenge.Entities;

namespace TetrisChallenge.Services
{
    public static class Database
    {
        private const string connectionString = @"Provider=SQLOLEDB.1;Password=sequor#123;Persist Security Info=True;User ID=sequor;Initial Catalog=dbTetrisChallenge;Data Source=SQO-175;Connect Timeout = 30";
        private const string procedureInsert = "InserirPontuacao";
        private const string procedureConsult = "ObterTop10Pontuacoes";
        private const string errorGetRankingMessage = "Erro ao obter pontuação dos jogadores";
        private const string errorInsertRankingMessage = "Erro ao armazenar pontuação dos jogadores";

        private static OleDbConnection connection;

        private static void createConnection()
        {
            if (connection == null || connection.State != ConnectionState.Open)
            {
                connection = new OleDbConnection(connectionString);

                connection.Open();
            }
        }

        private static void destroyConnection()
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public static bool InsertNewRanking(string playerName, int score)
        {
            bool sucess = false;
            try
            {
                createConnection();
                using (OleDbCommand command = new OleDbCommand(procedureInsert, connection))
                {
                    // Define o tipo de comando como stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    // Adiciona os parâmetros
                    command.Parameters.AddWithValue("@PlayernName", playerName);
                    command.Parameters.AddWithValue("@Pontuacao", score);

                    // Executa a stored procedure
                    command.ExecuteNonQuery();

                    sucess = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, errorInsertRankingMessage);
                sucess = false;
            }
            finally
            {
                destroyConnection();
            }
            return sucess;
        }

        public static List<PlayerRank> ObterTop10Pontuacoes()
        {
            bool sucess = false;
            List<PlayerRank> pontuacoes = new List<PlayerRank>();
            try
            {
                createConnection();

                // Cria um comando para a stored procedure
                using (OleDbCommand command = new OleDbCommand(procedureConsult, connection))
                {
                    // Define o tipo de comando como stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    // Executa a stored procedure
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PlayerRank PlayerRank = new PlayerRank
                            {
                                Jogador = reader["NamePlayer"].ToString(),
                                PontuacaoJogador = Convert.ToInt32(reader["Pontuacao"])
                            };

                            pontuacoes.Add(PlayerRank);
                        }
                    }
                }

                destroyConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, errorGetRankingMessage);
                sucess = false;
            }
            finally 
            { 
                destroyConnection(); 
            }
            return pontuacoes;
        }
    }

}