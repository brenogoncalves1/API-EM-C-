using Microsoft.AspNetCore.Mvc;

namespace API_EM_C_.ViewModel
{
    public class ProdutosViewModel 
    {
        public int Id_Produto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public string? ImagemUrl { get; set; }
    }
}
