using API_EM_C_.Model;
using API_EM_C_.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace API_EM_C_.Controllers
{
    [ApiController]
    [Route("api/v1/Produtos")]
    [Authorize] 
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutosRepository _produtosRepository;

        public ProdutosController(IProdutosRepository produtosRepository)
        {
            _produtosRepository = produtosRepository ?? throw new ArgumentNullException(nameof(produtosRepository));
        }

        [HttpPost]
        public IActionResult Add(ProdutosViewModel produtoView)
        {
            if (string.IsNullOrWhiteSpace(produtoView.Nome))
                return BadRequest("O nome do produto é obrigatório.");

            if (produtoView.Preco <= 0)
                return BadRequest("O preço não pode ser negativo ou zerado.");

            if (produtoView.Estoque <= 0)
                return BadRequest("O estoque não pode ser negativo ou zerado.");

            // Verifica se já existe produto com esse Id
            var produtoExistente = _produtosRepository.get().FirstOrDefault(p => p.Id_Produto == produtoView.Id_Produto);

            if (produtoExistente != null)
                return Conflict($"Já existe um produto com o Id {produtoView.Id_Produto}.");

            var produtosView = new Produtos(
                produtoView.Id_Produto,
                produtoView.Nome,
                produtoView.Descricao,
                produtoView.Preco,
                produtoView.Estoque,
                produtoView.ImagemUrl);

            _produtosRepository.add(produtosView);

            return Ok("Produto adicionado com sucesso.");
        }


        [HttpGet]
        public IActionResult get()
        {
            var produtos = _produtosRepository.get();
            return Ok(produtos);
        }

        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            var produtos = _produtosRepository.get().FirstOrDefault(p => p.Id_Produto == id);
            if (produtos == null)
            {
                return NotFound("Produto não encontrado.");
            }
            _produtosRepository.delete(produtos);
            return Ok("Produto deletado com sucesso.");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ProdutosViewModel produtoView)
        {
            if (string.IsNullOrWhiteSpace(produtoView.Nome))
                return BadRequest("O nome do produto é obrigatório.");
            if (produtoView.Preco <= 0)
                return BadRequest("O preço não pode ser negativo ou Zerado.");
            if (produtoView.Estoque <= 0)
                return BadRequest("O estoque não pode ser negativo ou Zerado.");
            var produtos = _produtosRepository.get().FirstOrDefault(p => p.Id_Produto == id);
            if (produtos == null)
            {
                return NotFound("Produto não encontrado.");
            }
            produtos.Nome = produtoView.Nome;
            produtos.Descricao = produtoView.Descricao;
            produtos.Preco = produtoView.Preco;
            produtos.Estoque = produtoView.Estoque;
            produtos.ImagemUrl = produtoView.ImagemUrl;
            _produtosRepository.update(produtos);
            return Ok("Produto atualizado com sucesso.");
        }
    }
}
