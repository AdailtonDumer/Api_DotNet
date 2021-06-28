using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("{Controller}/v1")]
    public class ProductController : ControllerBase
    {

        [HttpGet]
        public ActionResult GetAll([FromServices] DataContext context)
        {
            try
            {
                var products = context.Products;

                return Ok(new { Mensagem = "Sucesso", Corpo = products });
            }
            catch (Exception ex)
            {
                return Ok(new { Mensagem = "Erro", Corpo = ex.Message });
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> Get([FromServices] DataContext context, int id)
        {
            try
            {
                var product = await context.Products.FindAsync(id);
                if (product == null)
                    return NotFound(new { Mensagem = "Produto não encontrado", Corpo = id });

                return Ok(new { Mensagem = "Sucesso", Corpo = product });
            }
            catch (Exception ex)
            {
                return Ok(new { Mensagem = "Erro", Corpo = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult Post([FromServices] DataContext context, [FromBody] Product product)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Ok(new { Mensagem = "Erro de Validação", Corpo = ModelState });

                context.Add(product);
                context.SaveChanges();

                return Ok(new { Mensagem = "Gravado com sucesso!", Corpo = product });
            }
            catch (Exception ex)
            {
                return Ok(new { Mensagem = "Erro", Corpo = ex.Message });
            }
        }

        [HttpPut]
        public ActionResult Put([FromServices] DataContext context, [FromBody] Product product)
        {
            try
            {
                var databaseProduct = context.Products.FirstOrDefault(x => x.Id == product.Id);
                if (databaseProduct == null)
                    ModelState.AddModelError(nameof(product.Id), "Produto não encontrado na base de dados");

                if (!ModelState.IsValid)
                    return NotFound(new { Mensagem = "Erro de Validação", Corpo = ModelState });

                context.Entry(databaseProduct).CurrentValues.SetValues(product);
                context.SaveChangesAsync();

                return Ok(new { Mensagem = "Registro Atualizado com Sucesso", Corpo = product });
            }
            catch (Exception ex)
            {
                return Ok(new { Mensagem = "Erro", Corpo = ex.Message });
            }
        }

        [HttpDelete]
        public ActionResult Delete([FromServices] DataContext context, [FromBody] Product product)
        {
            try
            {
                context.Products.Remove(product);
                context.SaveChanges();

                return Ok(new { Mensagem = "Excluído com Sucesso", Corpo = "" });
            }
            catch (Exception ex)
            {
                return Ok(new { Mensagem = "Erro", Corpo = ex.Message });
            }
        }
    }
}
