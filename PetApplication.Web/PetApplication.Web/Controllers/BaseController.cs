using PetApplication.Repository;
using PetApplication.Utility;
using System.Web.Mvc;

namespace PetApplication.Web.Controllers
{
    [Audit]
    public class BaseController : Controller
    {
        protected readonly IPetRepository _petRepository;

        public BaseController(IPetRepository petRepository)
        {
            this._petRepository = petRepository;
        }

        public ViewResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}