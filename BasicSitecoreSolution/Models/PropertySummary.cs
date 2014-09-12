using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicSitecoreSolution.Models
{
    using Sitecore.Data.Events;
    using Sitecore.Data.Items;
    using Sitecore.Mvc.Presentation;
    using Sitecore.Web.UI.WebControls;

    using Rendering = Sitecore.Mvc.Presentation.Rendering;

    public interface IPropertySummary
    {
        string Cost { get; set; }

        string NumberOfBedrooms { get; set; }

        string Area { get; set; }

        string PostCode { get; set; }

        string PropertyType { get; set; }
    }

    public class PropertySummary 
    {
        public string Cost { get; set; }

        public string NumberOfBedrooms { get; set; }

        public string Area { get; set; }

        public string PostCode { get; set; }

        public string PropertyType { get; set; }
    }
}