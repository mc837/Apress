using System.Web.Mvc;
using SportsStore.Domain.Abstract;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductsRepository _repository;

        public ProductController(IProductsRepository productRepository)
        {
            this._repository = productRepository;
        }


        public ViewResult List()
        {
            return View(_repository.Products);
        }
    }
}
