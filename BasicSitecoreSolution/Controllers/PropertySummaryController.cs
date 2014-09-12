using System;
using System.Web.Mvc;

namespace BasicSitecoreSolution.Controllers
{
    using BasicSitecoreSolution.BusinessLogic.Properties;
    using BasicSitecoreSolution.BusinessLogic.Wrappers;

    public class PropertySummaryController : Controller
    {
        
        private IPropertyManager _propertyManager;
        // GET: HelloWorld

        public PropertySummaryController(IPropertyManager propertyManager)
        {
            _propertyManager = propertyManager;
        }
        public ActionResult Index()
        {

            var properties = _propertyManager.GetAllProperties();

            return View(properties);
        }
    }
}