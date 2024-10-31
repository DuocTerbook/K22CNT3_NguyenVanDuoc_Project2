using System.Web;
using System.Web.Mvc;

namespace NguyenVanDuoc_2210900016_Project2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
