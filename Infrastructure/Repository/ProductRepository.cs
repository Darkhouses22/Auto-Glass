using Domain.Entity;
using Infrastructure.Context;
using Infrastructure.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using X.PagedList;

namespace Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context) 
        {
            _context = context;
        }

        public void Delete(int codeProduct)
        {
            var produto = _context.Produto.AsTracking().Where(x => x.codigo == codeProduct).FirstOrDefault();
            produto.status = false;

            _context.SaveChanges();
        }

        public void Edit(Produto product)
        {
            var produto = _context.Produto.AsTracking().Where(x => x.codigo == product.codigo).FirstOrDefault();
            produto.descricao = product.descricao;
            produto.descricaoFornecedor = product.descricaoFornecedor;
            produto.status = product.status;
            produto.dataFabricacao = product.dataFabricacao;
            produto.dataValidade = product.dataValidade;
            produto.codigoFornecedor = product.codigoFornecedor;
            produto.descricaoFornecedor = product.descricaoFornecedor;
            produto.cnpjFornecedor = product.cnpjFornecedor;

            _context.SaveChanges();
        }

        public IPagedList<Produto> GetAll(int pagina = 1, int tamanhoPagina = 1, Produto product = null)
        {
            var query = _context.Produto.AsNoTracking();

            if (product is not null)
            {
                if(product.codigo != default)
                    query = query.Where(x => x.codigo == product.codigo);

                if (product.status != null)
                    query = query.Where(x => x.status == product.status);

                if (product.codigo != default)                
                    query = query.Where(x => x.codigo <= product.codigo);

                if(product.dataFabricacao != null)                
                    query = query.Where(x => x.dataFabricacao <= product.dataFabricacao);
                
                if(product.dataValidade != null)                
                    query = query.Where(x => x.dataValidade <= product.dataValidade);

                if (!string.IsNullOrEmpty(product.descricao))
                    query = query.Where(x => x.descricao.Contains(product.descricao));

                if (!string.IsNullOrEmpty(product.descricaoFornecedor))
                    query = query.Where(x => x.descricaoFornecedor.Contains(product.descricaoFornecedor));

                if (!string.IsNullOrEmpty(product.cnpjFornecedor))
                    query = query.Where(x => x.cnpjFornecedor.Contains(product.cnpjFornecedor));

                if (product.codigoFornecedor != null)
                    query = query.Where(x => x.codigoFornecedor == product.codigo);
            }
            return query.OrderBy(x => x.codigo)
                        .ToPagedList(pagina, tamanhoPagina);
        }

        public async void Insert(Produto product)
        {
            _context.Produto.Add(product);

            _context.SaveChanges();
        }
    }
}
