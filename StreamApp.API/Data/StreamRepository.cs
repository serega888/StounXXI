using System.Threading.Tasks;

namespace StreamApp.API.Data
{
    public class StreamRepository : IStreamRepository
    {
        private readonly DataContext _context;
        public StreamRepository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveAll()
        {
             return await _context.SaveChangesAsync() > 0;
        }
    }
}