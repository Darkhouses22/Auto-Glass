using API.Models;
using Application.Interface.Services;
using AutoMapper;
using Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// Controller para gerenciar operações de produtos.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : Controller
    {
        private readonly IProductService _service;
        private readonly IMapper _mapper;
        public ProdutoController(IProductService service, IMapper mapper) 
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtem Todos os produtos
        /// </summary>
        /// <returns>Lista de produtos</returns>
        [HttpGet]
        public ActionResult Get([FromQuery] int pagina, [FromQuery] int tamanhoPagina)
        {
            try
            {
                return Ok(_service.GetAll(pagina,tamanhoPagina));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obtem o Produto pelo código
        /// </summary>
        /// <param name="code">Código do produto</param>
        /// <returns>Retorna o produto pelo id</returns>
        [HttpGet("By")]
        public ActionResult GetAll([FromQuery] int pagina, [FromQuery] int tamanhoPagina, [FromQuery]ProdutoModel model)
        {
            try
            {
                return Ok(_service.GetBy(pagina, tamanhoPagina,_mapper.Map<Produto>(model)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obtem o Produto pelo código
        /// </summary>
        /// <param name="code">Código do produto</param>
        /// <returns>Retorna o produto pelo id</returns>
        [HttpGet("ByCode")]
        public ActionResult GetAll([FromQuery] int code)
        {
            try
            {
                return Ok(_service.GetByCode(code));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Cria um novo produto no banco de dados
        /// </summary>
        /// <param name="model">Produto model</param>
        /// <returns>Retorno de status created e insere o produto</returns>
        [HttpPost]
        public ActionResult Create([FromBody] ProdutoModel model)
        {
            try
            {
                _service.Insert(_mapper.Map<Produto>(model));

                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Edita o produto no banco de dados
        /// </summary>
        /// <param name="model">Produto model</param>
        /// <returns>Retorna nenhum dado</returns>
        [HttpPut]
        public ActionResult Edit([FromBody] EditProdutoModel model)
        {
            try
            {
                _service.Edit(_mapper.Map<Produto>(model));

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Deleta logicamente um produto
        /// </summary>
        /// <param name="id">id do produto</param>
        /// <returns>Retorna nenhum dado</returns>
        [HttpDelete]
        public ActionResult Delete([FromQuery] int id)
        {
            try
            {
                _service.Delete(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
