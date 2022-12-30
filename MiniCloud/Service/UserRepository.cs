using Application.Interfaces;
using Domain;
using Persistence;

namespace MiniCloud.Service
{
    public class UserRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly UserDbContext _context;

        public UserRepository(UserDbContext context)
        {
            _context = context;
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(Guid id)
        {
            var result = _context.Set<T>().FirstOrDefault(x => x.Id == id);

            if (result == null)
            {
                //todo: need to add logger
                return null;
            }

            return result;
        }

        public async Task<Guid> Add(T entity)
        {
            entity.CreatedOn= DateTime.Now;
            entity.ModefiedOn= DateTime.Now;

            var result = await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity.Id;
        }
    }
}
