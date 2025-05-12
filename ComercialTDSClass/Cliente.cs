using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ComercialTDSClass
{
    public class Cliente
    {

        public List<Endereco>? Enderecos { get; set; }
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public DateOnly DataNasc { get; set; }
        public DateOnly DataCad { get; set; }
        public bool Ativo { get; set; }


        public Cliente(List<Endereco>? enderecos, int id, string? nome, string? cpf, string? telefone, string? email, DateOnly dataNasc, DateOnly dataCad, bool ativo)//construtor
        {
            Enderecos = enderecos;
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Telefone = telefone;
            Email = email;
            DataNasc = dataNasc;
            DataCad = dataCad;
            Ativo = ativo;
        }

        public Cliente(List<Endereco>? enderecos) // construtor list
        {
            Enderecos = enderecos;
        }

        public Cliente() // construtor vazio
        {

        }



        // falta criar a lista dos Clientes




        // inserir
        public void Inserir()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_cliente_insert";
            cmd.Parameters.AddWithValue("spnome", Nome);
            cmd.Parameters.AddWithValue("spcpf", Cpf);
            cmd.Parameters.AddWithValue("sptelefone", Telefone);
            cmd.Parameters.AddWithValue("spemail", Email);
            cmd.Parameters.AddWithValue("spdatanasc", DataNasc);
            Id = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Connection.Close();

        }

        // lista





        // alterar

        
        // deletar





    }
}