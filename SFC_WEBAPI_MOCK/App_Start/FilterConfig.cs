using System.Web;
using System.Web.Mvc;

namespace SFC_WEBAPI_MOCK
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
