using Application.Interface.Services;
using Application.Services;
using Domain.Entity;
using Infrastructure.Repository.Interface;
using Moq;

namespace TestesUnitarios
{
    public class Tests
    {

        [Test]
        public void RetornarErroComDataFabricacaoMaiorQueValidade()
        {
            //Arrange     
            Produto produto = new Produto();
            produto.dataFabricacao = DateTime.Now.AddDays(1);
            produto.dataValidade = DateTime.Now;

            ProductService service = new ProductService(null);

            //Assert
            Assert.Throws<Exception>(() => service.Insert(produto));
        }

        [Test]
        public void NaoEnviarCodigoParaFuncaoQuePedeCodigo()
        {
            //Arrange     
            ProductService service = new ProductService(null);

            //Assert
            Assert.Throws<Exception>(() => service.GetByCode(0));
        }
    }
}