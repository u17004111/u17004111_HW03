using System.Web;
using System.Web.Mvc;

namespace _272_hw03_final_rev2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
