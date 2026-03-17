using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using MySql.Data.MySqlClient;
using Projeto.Models;
using Projeto.Repositorio.Contrato;
using System.Data;

namespace Projeto.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly string _conexaoMySQL;

        public UsuarioRepositorio(IConfiguration conf)
        {
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");
        }
        public void Atualizar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Usuario usuario)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("insert into tbUsuario(NomeUsu, Cargo, DataNasc) " +
                                                     " values (@NomeUsu, @Cargo, @DataNasc)", conexao);

                cmd.Parameters.Add("@NomeUsu", MySqlDbType.VarChar).Value = usuario.NomeUsu;
                cmd.Parameters.Add("@Cargo", MySqlDbType.VarChar).Value = usuario.Cargo;
                cmd.Parameters.Add("@DataNasc", MySqlDbType.Date).Value = usuario.DataNasc;

                cmd.ExecuteNonQuery();
                conexao.Close();
            }

        }

        public void Excluir(int Id)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("delete from tbUsuario where IdUsu=@IdUsu", conexao);
                cmd.Parameters.AddWithValue("@IdUsu", Id);
                int i = cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public IEnumerable<Usuario> ObterTodosUsuarios()
        {
            List<Usuario> UsuarioList = new List<Usuario>();
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbUsuario", conexao);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                conexao.Close();

                foreach(DataRow dr in dt.Rows)
                {
                    UsuarioList.Add(
                        new Usuario
                        {
                            IdUsu = Convert.ToInt32(dr["IdUsu"]),
                            NomeUsu = (string)dr["NomeUsu"],
                            Cargo = (string)dr["Cargo"],
                            DataNasc = Convert.ToDateTime(dr["DataNasc"])
                        });
                }
                return UsuarioList;
            }
        }

        public Usuario ObterUsuario(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
