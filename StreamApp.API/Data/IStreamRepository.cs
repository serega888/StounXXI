using System.Threading.Tasks;

namespace StreamApp.API.Data
{
    public interface IStreamRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
    }
}