namespace BasicSitecoreSolution.BusinessLogic.Properties
{
    using System.Collections.Generic;
    using System.Linq;

    using BasicSitecoreSolution.BusinessLogic.Wrappers;
    using BasicSitecoreSolution.Models;

    using Sitecore.Data.Items;

    public interface IPropertyManager
    {
        List<PropertySummary> GetAllProperties();

        PropertyCount GetCountOfProperties();
    }

    public class PropertyManager : IPropertyManager
    {
        private readonly ISitecoreWrapper _sitecoreWrapper;

        public PropertyManager(ISitecoreWrapper sitecoreWrapper)
        {
            _sitecoreWrapper = sitecoreWrapper;
        }

        public List<PropertySummary> GetAllProperties()
        {
            var propertyItems = _sitecoreWrapper.GetPropertyItems();

            var propertyList = propertyItems.Select(GetPropertySummery).ToList();

            return propertyList;
        }

        private PropertySummary GetPropertySummery(Item propertyItem)
        {
            var summary = new PropertySummary
                              {
                                  Cost = propertyItem.Fields["Cost"].Value,
                                  Area = propertyItem.Fields["Area"].Value,
                                  NumberOfBedrooms = propertyItem.Fields["Number Of Bedrooms"].Value,
                                  PostCode = propertyItem.Fields["Post code"].Value,
                                  PropertyType = propertyItem.TemplateName
                              };

            return summary;
        }

        public PropertyCount GetCountOfProperties()
        {

            return new PropertyCount { Count = 2 };
        }
    }

    public class PropertyCount
    {
        public int Count { get; set; }
    }
}