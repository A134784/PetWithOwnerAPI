namespace PetApplication.Web.Controllers
{
    using System;
    using System.Web.Mvc;
    using Repository;
    using Utility;

    /// Unity IoC - controller injection
    // Moq in Unit Test
    // Elmah in Logging framework
    // Global Exception filter for additional work in Exception
    // Output cache can be enable if whole page cache is needed
    // Im Memory cache is used to avoid HTTP call overhead for 60 sec
    // Audit log using filter
    public class PetController : BaseController
    {
        public PetController(IPetRepository petRepository) : base(petRepository)
        {
        }

        // Output cache can be enable if whole page cache is needed
    // [OutputCache(Duration = 60)]
    public ActionResult Index()
        {
            try
            {
                var result = this._petRepository.GetPetNamesAccordingToGender();
                Log.Logging(result.ToString());
                return View(result);
            }
            catch (Exception ex)
            {
                Log.LogError(ex);
                throw;
            }
        }
    }
}