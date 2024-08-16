using WebApi.Entities;

namespace WebApi.Repository
{
    public interface IPessoa
    {
        Task Add(PessoaModel Objeto);
        Task Update(PessoaModel Objeto);
        Task Delete(PessoaModel Objeto);
        Task<PessoaModel> GetEntityById(int Id);
        Task<List<PessoaModel>> List();
    }
}
