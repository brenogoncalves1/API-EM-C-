using API_EM_C_.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_EM_C_.InfraEstrutura
{
    public class ProdutosRepository : IProdutosRepository
    {
        private readonly ConnectionContex _Context;

        // Recebe o contexto via injeção de dependência
        public ProdutosRepository(ConnectionContex context)
        {
            _Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void add(Produtos produtos)
        {
            _Context.Produtos.Add(produtos);
            _Context.SaveChanges();
        }

        public void delete(Produtos produtos)
        {
            var produtoExistente = _Context.Produtos.FirstOrDefault(p => p.Id_Produto == produtos.Id_Produto);

            if (produtoExistente != null)
            {
                _Context.Produtos.Remove(produtoExistente);
                _Context.SaveChanges();
            }
        }

        public List<Produtos> get()
        {
            try
            {
                var produtos = _Context.Produtos.ToList();
                if (produtos == null || produtos.Count == 0)
                    Console.WriteLine("Nenhum produto encontrado.");
                return produtos;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao recuperar produtos: {ex.Message}");
                return new List<Produtos>();
            }
        }

        public void update(Produtos produtos)
        {
            var produtoExistente = _Context.Produtos.FirstOrDefault(p => p.Id_Produto == produtos.Id_Produto);

            if (produtoExistente == null)
                throw new Exception("Produto não encontrado.");

            produtoExistente.Nome = produtos.Nome;
            produtoExistente.Descricao = produtos.Descricao;
            produtoExistente.Preco = produtos.Preco;
            produtoExistente.Estoque = produtos.Estoque;
            produtoExistente.ImagemUrl = produtos.ImagemUrl;

            _Context.SaveChanges();
        }
    }
}
