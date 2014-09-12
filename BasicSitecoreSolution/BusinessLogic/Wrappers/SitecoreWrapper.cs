namespace BasicSitecoreSolution.BusinessLogic.Wrappers
{
    using Sitecore.Data.Items;

    public interface ISitecoreWrapper
    {
        Item[] GetPropertyItems();
    }

    public class SitecoreWrapper : ISitecoreWrapper
    {
        public Item[] GetPropertyItems()
        {
            var DB = Sitecore.Configuration.Factory.GetDatabase("master");

            return DB.SelectItems("fast:/sitecore/content/PropertySite/Properties//*");
        }
    }

}