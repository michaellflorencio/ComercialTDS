using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComercialTDSClass
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public Nivel? Nivel { get; set; }
        public bool Ativo { get; set; }
        public Usuario() { }// construtor vazio
        public Usuario(int id, string? nome, string? email, string? senha, Nivel? nivel, bool ativo)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
            Nivel = nivel;
            Ativo = ativo;
        }
        public Usuario(string? nome, string? email, string? senha, Nivel? nivel, bool ativo)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Nivel = nivel;
            Ativo = ativo;
        }
        public Usuario(string? nome, string? email, string? senha, Nivel? nivel)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Nivel = nivel;
        }
        public Usuario(int id, string? senha)
        {
            Id = id;
            Senha = senha;
        }
        public Usuario(int id, string? nome, string? senha, Nivel? nivel, bool ativo)
        {
            Id = id;
            Nome = nome;
            Senha = senha;
            Nivel = nivel;
            Ativo = ativo;
        }
        public void Inserir()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_usuario_insert";
            cmd.Parameters.AddWithValue("spnome", Nome);
            cmd.Parameters.AddWithValue("spemail", Email);
            cmd.Parameters.AddWithValue("spsenha", Senha);
            cmd.Parameters.AddWithValue("spnivel", Nivel.Id);
            Id = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Connection.Close();

        }
        public bool Atualizar()
        {
            return true;
        }
        public static Usuario ObterPorId(int id)
        {
            Usuario usuario = new();

            return usuario;
        }
        public static List<Usuario> ObterLista()
        {
            List<Usuario> usuarios = new();

            return usuarios;
        }
        public static Usuario EfatuarLogin(string email, string senha)
        {
            Usuario usuario = new();

            return usuario;
        }
        public static bool AlterarSenha(string email, string senha)
        {
            return true;
        }


    }
}


