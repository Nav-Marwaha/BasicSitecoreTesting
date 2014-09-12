using System.Collections.Generic;
using System.Linq;

namespace BasicSitecoreSolution.UnitTests.TestHelper
{
    using BasicSitecoreSolution.BusinessLogic.Wrappers;

    using Microsoft.QualityTools.Testing.Fakes;

    using Sitecore.Collections;
    using Sitecore.Collections.Fakes;
    using Sitecore.Data;
    using Sitecore.Data.Fields;
    using Sitecore.Data.Fields.Fakes;
    using Sitecore.Data.Items;
    using Sitecore.Data.Items.Fakes;

    public class FakeSitecore : ISitecoreWrapper
    {
        public Item[] GetPropertyItems()
        {
            return new Item[]
                       {
                           new ShimItem { NameGet = () => "TestItem1", TemplateNameGet = () => "Semi-Detached House", FieldsGet = () => this.GetTestFieldCollection(1) },
                           new ShimItem { NameGet = () => "TestItem2", TemplateNameGet = () => "Terraced House", FieldsGet = () => this.GetTestFieldCollection(2), }
                       };
        }

        private FieldCollection GetTestFieldCollection(int i)
        {
            var fields = new List<Field>(this.Getfields(i));

            FakesDelegates.Func<string, Field> names = name => fields.FirstOrDefault(x => x.Name.Equals(name));

            return new ShimFieldCollection { ItemGetString = names };
        }

        private IEnumerable<Field> Getfields(int i)
        {
            var fields = new List<Field>
                             {
                                 new ShimField { IDGet = () => new ID(), NameGet = () => "Cost", ValueGet = () => "200000" },
                                 new ShimField { IDGet = () => new ID(), NameGet = () => "Area", ValueGet = () => "London" },
                                 new ShimField { IDGet = () => new ID(), NameGet = () => "Number Of Bedrooms", ValueGet = () => i.ToString() },
                                 new ShimField { IDGet = () => new ID(), NameGet = () => "Post code", ValueGet = () => "Ec1 1ah" }
                             };

            return fields;
        }
    }
}
