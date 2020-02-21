using Senai.Peoples.WebAPI.Domains;
using Senai.Peoples.WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebAPI.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private string StringConexao = "Data Source=DEV5\\SQLEXPRESS; initial catalog=M_Peoples; user Id=sa; pwd=sa@132";

        public void AtualizarIdUrl(int id, FuncionarioDomain funcionario)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdate = "UPDATE Funcionarios SET Nome = @Nome, Sobrenome = @Sobrenome, DataNascimento = @DataNascimento WHERE IdFuncionario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionario.Sobrenome);
                    cmd.Parameters.AddWithValue("@DataNascimento", funcionario.DataNascimento);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public FuncionarioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectById = "SELECT IdFuncionario, Nome, Sobrenome, DataNascimento FROM Funcionarios WHERE IdFuncionario = @ID ";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            IdFuncionario = Convert.ToInt32(rdr[0]),
                            Nome = rdr["Nome"].ToString(),
                            Sobrenome = rdr["Sobrenome"].ToString(),
                            DataNascimento = Convert.ToDateTime(rdr[3])
                        };

                        return funcionario;
                    }

                    return null;
                }


            }
        }

        public void Cadastrar(FuncionarioDomain funcionario)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "INSERT INTO Funcionarios (Nome, Sobrenome, DataNascimento) VALUES (@Nome, @Sobrenome, @DataNascimento)";

                SqlCommand cmd = new SqlCommand(queryInsert, con);

                cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                cmd.Parameters.AddWithValue("Sobrenome", funcionario.Sobrenome);
                cmd.Parameters.AddWithValue("@Datanascimento", funcionario.DataNascimento);

                con.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDelete = "DELETE FROM Funcionarios WHERE IdFuncionario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }            
        }

        public List<FuncionarioDomain> Listar()
        {
            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT IdFuncionario, Nome, Sobrenome, DataNascimento FROM Funcionarios";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            IdFuncionario = Convert.ToInt32(rdr[0]),
                            Nome = rdr["Nome"].ToString(),
                            Sobrenome = rdr["Sobrenome"].ToString(),
                            DataNascimento = Convert.ToDateTime(rdr[3])
                        };
                        funcionarios.Add(funcionario);
                    }
                }
            }
            return funcionarios;
        }
    }
}
