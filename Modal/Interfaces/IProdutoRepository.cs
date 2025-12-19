using Modal.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modal.Interfaces
{
    public interface IProdutoRepository
    {
        Task AdicionarProduto(Products produto);
        Task<Products> ObterProdutoPorId(string id);
        Task<IEnumerable<Products>> ObterTodosProdutos();
        Task AtualizarProduto(Products produto);
    }
}
