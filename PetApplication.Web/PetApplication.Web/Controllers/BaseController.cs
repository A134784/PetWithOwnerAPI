﻿
namespace PetWithOwnerApplication.Web.Controllers
{
    using PetWithOwnerApplication.Repository;
    using PetWithOwnerApplication.Utility;
    using System.Web.Mvc;
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