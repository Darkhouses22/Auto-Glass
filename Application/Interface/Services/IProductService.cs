using Domain.Entity;
using X.PagedList;

namespace Application.Interface.Services
{
    public interface IProductService
    {
        IPagedList<Produto> GetAll(int pagina, int tamanhoPagina);
        IPagedList<Produto> GetBy(int pagina, int tamanhoPagina, Produto product);
        Produto GetByCode(int code);
        void Insert(Produto product);
        void Edit(Produto product);
        void Delete(int codeProduct);
    }
}
