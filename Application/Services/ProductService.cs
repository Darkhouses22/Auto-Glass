using Application.Interface.Services;
using Domain.Entity;
using Infrastructure.Repository.Interface;
using X.PagedList;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository) 
        {
            _repository = repository;
        }

        public void Delete(int codeProduct)
        {
            _repository.Delete(codeProduct);
        }

        public void Edit(Produto product)
        {
            if (product.dataFabricacao >= product.dataValidade)
                throw new Exception("Data Fabricação é maior que data Validade");

            _repository.Edit(product);
        }

        public IPagedList<Produto> GetAll(int pagina, int tamanhoPagina)
        {
            return _repository.GetAll(pagina,tamanhoPagina);
        }

        public IPagedList<Produto> GetBy(int pagina, int tamanhoPagina, Produto product)
        {
            return _repository.GetAll(pagina,tamanhoPagina, product);
        }

        public Produto GetByCode(int code)
        {
            if(code == default)
                throw new Exception("O Código tem que ser maior que 0");

            var produto = new Produto() { codigo = code };

            return _repository.GetAll(product:produto).FirstOrDefault();
        }

        public void Insert(Produto product)
        {
            if (product.dataFabricacao >= product.dataValidade)
                throw new Exception("Data Fabricação é maior que data Validade");

            _repository.Insert(product);
        }
    }
}
