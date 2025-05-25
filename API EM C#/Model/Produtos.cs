using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_EM_C_.Model
{
    [Table("Produtos")]
    public class Produtos
    {
        [Key]  // Definindo explicitamente a chave primária
        public int Id_Produto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public string? ImagemUrl { get; set; }

        // Construtor padrão (sem parâmetros)
        public Produtos() { }

        // Construtor com parâmetros
        public Produtos(int id_Produto, string nome, string descricao, decimal preco, int estoque, string imagemUrl)
        {
            Id_Produto = id_Produto;
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Estoque = estoque;
            ImagemUrl = imagemUrl;
        }


    
    }

}



