
namespace PetWithOwnerApplication.Web
{
    using PetWithOwnerApplication.Utility;
    using System.Web.Mvc;

    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            //Exception Filter
            filters.Add(new AppErrorHandler());
        }
    }
}
