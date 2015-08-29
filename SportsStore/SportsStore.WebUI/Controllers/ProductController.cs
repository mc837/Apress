using System.Linq;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductsRepository _repository;
        public int pageSize = 4;

        public ProductController(IProductsRepository productRepository)
        {
            _repository = productRepository;
        }


        public ViewResult List(string category, int page = 1)
        {
            var viewModel = new ProductsListViewModel
            {
                Products = _repository.Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductId)
                .Skip((page-1)*pageSize)
                .Take(pageSize),

                PagingInfo =  new PagingInfo{
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = _repository.Products.Count(p => category == null || p.Category == category)
                },
                CurrentCategory = category
            };

            return View(viewModel);
        }
    }
}
