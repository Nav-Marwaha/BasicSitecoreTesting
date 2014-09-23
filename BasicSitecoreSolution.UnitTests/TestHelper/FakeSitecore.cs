using System.Collections.Generic;
using System.Linq;

namespace BasicSitecoreSolution.UnitTests.TestHelper
{
    using System;

    using BasicSitecoreSolution.BusinessLogic.Wrappers;

    using Microsoft.QualityTools.Testing.Fakes;

    using Sitecore.Collections;
    using Sitecore.Collections.Fakes;
    using Sitecore.Data;
    using Sitecore.Data.Fakes;
    using Sitecore.Data.Fields;
    using Sitecore.Data.Fields.Fakes;
    using Sitecore.Data.Items;
    using Sitecore.Data.Items.Fakes;

    public class FakeSitecore : ISitecoreWrapper
    {
        public Item[] GetPropertyItems()
        {


            ItemPath paths1 = new ShimItemPath
            {
                PathGet = () => "ItemPath1"
            };

            ItemPath paths2 = new ShimItemPath
            {
                PathGet = () => "ItemPath2"
            };

            return new Item[]
                       {
                           new ShimItem {IDGet = () => new ID(Guid.NewGuid()), NameGet = () => "TestItem1", TemplateNameGet = () => "Semi-Detached House", FieldsGet = () => this.GetTestFieldCollection(1), PathsGet = () => paths1},
                           new ShimItem {IDGet = () => new ID(Guid.NewGuid()), NameGet = () => "TestItem2", TemplateNameGet = () => "Terraced House", FieldsGet = () => this.GetTestFieldCollection(2), PathsGet = () => paths2}
                       };
        }

        private FieldCollection GetTestFieldCollection(int i)
        {
            var fields = new List<Field>(this.Getfields(i));

            FakesDelegates.Func<string, Field> names = name => fields.FirstOrDefault(x => x.Name.Equals(name));

            FakesDelegates.Func<Sitecore.Data.Fields.Field[]> fieldcollection = fields.ToArray;

            FakesDelegates.Func<IEnumerator<Field>> fieldEnnumerator = () => fields.GetEnumerator();

            FakesDelegates.Func<int> fieldcount = () => fields.Count;

            return new ShimFieldCollection { ItemGetString = names, CountGet = fieldcount, GetFields = fieldcollection, SystemCollectionsGenericIEnumerableSitecoreDataFieldsFieldGetEnumerator = fieldEnnumerator };
        }

        private IEnumerable<Field> Getfields(int i)
        {
            var fields = new List<Field>
                             {
                                 new ShimField { IDGet = () => new ID(), NameGet = () => "Cost",               DisplayNameGet = () => "Cost", ValueGet = () => "200000" },
                                 new ShimField { IDGet = () => new ID(), NameGet = () => "Area",                DisplayNameGet = () => "Area", ValueGet = () => "London" },
                                 new ShimField { IDGet = () => new ID(), NameGet = () => "Number Of Bedrooms",  DisplayNameGet = () => "Number Of Bedrooms", ValueGet = () => i.ToString() },
                                 new ShimField { IDGet = () => new ID(), NameGet = () => "Post code",           DisplayNameGet = () => "Post code", ValueGet = () => "Ec1 1ah" },
                                 new ShimField { IDGet = () => new ID(), NameGet = () => "__Updated By",        DisplayNameGet = () => "__Updated By", ValueGet = () => "Someone" },
                                 new ShimField { IDGet = () => new ID(), NameGet = () => "Empty Field",         DisplayNameGet = () => "Empty Field", ValueGet = () => null },
                             };

            return fields;
        }
    }
}
