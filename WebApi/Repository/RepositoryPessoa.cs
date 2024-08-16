using Microsoft.EntityFrameworkCore;
using WebApi.Config;
using WebApi.Entities;

namespace WebApi.Repository
{
    public class RepositoryPessoa : IPessoa
    {

        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositoryPessoa()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }


        public async Task Add(PessoaModel Objeto)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                await data.Set<PessoaModel>().AddAsync(Objeto);
                await data.SaveChangesAsync();
            }
        }

        public async Task Delete(PessoaModel Objeto)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                data.Set<PessoaModel>().Remove(Objeto);
                await data.SaveChangesAsync();
            }
        }

        public async Task<PessoaModel> GetEntityById(int Id)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                var r = await data.Set<PessoaModel>().FindAsync(Id);
                return r;
            }
        }

        public async Task<List<PessoaModel>> List()
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                return await data.Set<PessoaModel>().ToListAsync();
            }
        }

        public async Task Update(PessoaModel Objeto)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                data.Set<PessoaModel>().Update(Objeto);
                await data.SaveChangesAsync();
            }
        }
    }
}
