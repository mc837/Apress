using System.Linq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Concrete
{
    public class EFProductRepository: IProductsRepository
    {
        private EFDbContext _context = new EFDbContext();

        public IQueryable<Product> Products {
            get { return _context.Products; }
        }
    }
}
