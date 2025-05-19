using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComercialTDSClass
{
    public class Produto
    {

        public int Id { get; set; }
        public string? Codbarras { get; set; }
        public string? Descricao { get; set; }
        public double? ValorUnit { get; set; }
        public string? UnidadeVenda { get; set; }
        public Categoria? Categoria { get; set; }
        public double EstoqueMinimo { get; set; }
        public double ClasseDesconto { get; set; }
        public Stream Imagem { get; set; }
        public DateTime DataCad { get; set; }
        public bool Descontinuado { get; set; }
        public Produto() 
        {
            Categoria = new();
        }

        public Produto(int id, string? codbarras, string? descricao, double? valorUnit, string? unidadeVenda, Categoria? categoria, double estoqueMinimo, double classeDesconto, Stream imagem, DateTime dataCad, bool descontinuado)
        {
            Id = id;
            Codbarras = codbarras;
            Descricao = descricao;
            ValorUnit = valorUnit;
            UnidadeVenda = unidadeVenda;
            Categoria = categoria;
            EstoqueMinimo = estoqueMinimo;
            ClasseDesconto = classeDesconto;
            Imagem = imagem;
            DataCad = dataCad;
            Descontinuado = descontinuado;
        }
        public Produto(string? codbarras, string? descricao, double? valorUnit, string? unidadeVenda, Categoria? categoria, double estoqueMinimo, double classeDesconto, Stream imagem, DateTime dataCad, bool descontinuado)
        {
            Codbarras = codbarras;
            Descricao = descricao;
            ValorUnit = valorUnit;
            UnidadeVenda = unidadeVenda;
            Categoria = categoria;
            EstoqueMinimo = estoqueMinimo;
            ClasseDesconto = classeDesconto;
            Imagem = imagem;
            DataCad = dataCad;
            Descontinuado = descontinuado;
        }
        public Produto(int id, string? codbarras, string? descricao, double? valorUnit, string? unidadeVenda, Categoria? categoria, double estoqueMinimo, double classeDesconto, Stream imagem)
        {
            Id = id;
            Codbarras = codbarras;
            Descricao = descricao;
            ValorUnit = valorUnit;
            UnidadeVenda = unidadeVenda;
            Categoria = categoria;
            EstoqueMinimo = estoqueMinimo;
            ClasseDesconto = classeDesconto;
            Imagem = imagem;
        }
        public void Inserir()
        {
            //spcod_barras, 
            //spdescricao, 
            //spvalor_unit, 
            //spunidade_venda,
            //spcategoria_id, 
            //spestoque_minimo,
            //spclasse_desconto,

            var cmd = Banco.Abrir();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "sp_produto_insert";
            cmd.Parameters.AddWithValue("spcod_barras", Codbarras);
            cmd.Parameters.AddWithValue("spdescricao", Descricao);
            cmd.Parameters.AddWithValue("spvalor_uni", ValorUnit );
            cmd.Parameters.AddWithValue("spunidade_venda", UnidadeVenda);
            cmd.Parameters.AddWithValue("spcategoria_id", Categoria);
            cmd.Parameters.AddWithValue("spestoque_minimo",EstoqueMinimo);
            cmd.Parameters.AddWithValue("spclasse_desconto", ClasseDesconto);
            cmd.Parameters.AddWithValue("spimagem", Imagem);
            Id = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Connection.Close();



        }
        public bool Atualizar()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "sp_produto_update";
            cmd.Parameters.AddWithValue("spid", Id);
            cmd.Parameters.AddWithValue("spcod_barras", Codbarras);
            cmd.Parameters.AddWithValue("spdescricao", Descricao);
            cmd.Parameters.AddWithValue("spvalor_uni", ValorUnit);
            cmd.Parameters.AddWithValue("spunidade_venda", UnidadeVenda);
            cmd.Parameters.AddWithValue("spcategoria_id", Categoria);
            cmd.Parameters.AddWithValue("spestoque_minimo", EstoqueMinimo);
            cmd.Parameters.AddWithValue("spclasse_desconto", ClasseDesconto);
            cmd.Parameters.AddWithValue("spimagem", Imagem);
            if(cmd.ExecuteNonQuery() > 0)
                return true;
            else
                return false;
        }
        public Produto ObterporId(int id)
        {
            Produto produto = new();
            var cmd = Banco.Abrir();
            cmd.CommandText = $"select * from produtos where id = {id}";
            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                produto = new(
                    dr.GetInt32(0),
                    dr.GetString(1),
                    dr.GetString(2),
                    dr.GetDouble(3),
                    dr.GetString(4),
                    Categoria.ObterPorId(dr.GetInt32(5)),
                    dr.GetDouble(6),
                    dr.GetDouble(7),
                    dr.GetStream(8),
                    dr.GetDateTime(9),
                    dr.GetBoolean(10)

                    );
            }
            dr.Close();
            cmd.Connection.Close();
            return produto;
        }
        public static List<Produto> ObterLista(int id)
        {
            List<Produto> produtos = new();
            var cmd = Banco.Abrir();
            cmd.CommandText = $"select * from produtos where id = {id}";
            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                produtos.Add(new(
                    dr.GetInt32(0),
                    dr.GetString(1),
                    dr.GetString(2),
                    dr.GetDouble(3),
                    dr.GetString(4),
                    Categoria.ObterPorId(dr.GetInt32(5)),
                    dr.GetDouble(6),
                    dr.GetDouble(7),
                    dr.GetStream(8),
                    dr.GetDateTime(9),
                    dr.GetBoolean(10)

                    ));

            }
            dr.Close();
            cmd.Connection.Close();
            return produtos;
        }


    }
}