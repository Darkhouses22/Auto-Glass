using Domain.Entity;
using X.PagedList;

namespace Infrastructure.Repository.Interface
{
    public interface IProductRepository
    {
        IPagedList<Produto> GetAll(int pagina = 1, int tamanhoPagina = 1, Produto product = null);
        void Insert(Produto product);
        void Edit(Produto product);
        void Delete(int codeProduct);
    }
}
