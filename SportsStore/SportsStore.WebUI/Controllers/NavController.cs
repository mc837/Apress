using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;

namespace SportsStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private readonly IProductsRepository _repo;

        public NavController(IProductsRepository repo)
        {
            _repo = repo;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = _repo.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);
                
            return PartialView(categories);
        }

    }
}
