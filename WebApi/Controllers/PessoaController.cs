using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;
using WebApi.Repository;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoa _InterfacePessoa;

        public PessoaController(IPessoa iPessoa)
        {
            _InterfacePessoa = iPessoa;
        }

        [HttpGet("/api/Pessoa/List")]
        [Produces("application/json")]
        public async Task<object> List()
        {
            return await _InterfacePessoa.List();
        }

        [HttpPost("/api/Pessoa/Add")]
        [Produces("application/json")]
        public async Task<object> Add(PessoaModel pessoa)
        {
            try
            {
                await _InterfacePessoa.Add(pessoa);
            }
            catch (Exception ex)
            {

            }

            return Task.FromResult("OK");
        }

        [HttpPut("/api/Pessoa/Update")]
        [Produces("application/json")]
        public async Task<object> Update(PessoaModel pessoa)
        {
            try
            {
                await _InterfacePessoa.Update(pessoa);
            }
            catch (Exception ex)
            {

            }

            return Task.FromResult("OK");
        }


        [HttpGet("/api/Pessoa/GetById")]
        [Produces("application/json")]
        public async Task<object> GetEntityById(int id)
        {
            var x = await _InterfacePessoa.GetEntityById(id);
            return x;
        }

        [HttpDelete("/api/Pessoa/Delete")]
        [Produces("application/json")]
        public async Task<object> Delete(int id)
        {
            try
            {
                var pessoa = await _InterfacePessoa.GetEntityById(id);

                await _InterfacePessoa.Delete(pessoa);

            }
            catch (Exception ex)
            {
                return false;
            }

            return true;

        }

    }
}
