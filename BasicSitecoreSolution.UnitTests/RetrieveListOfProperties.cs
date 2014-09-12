namespace BasicSitecoreSolution.UnitTests
{
    using System;
    using System.Collections.Generic;
    using BasicSitecoreSolution.BusinessLogic.Properties;
    using BasicSitecoreSolution.Models;
    using System.Linq;
    using BasicSitecoreSolution.UnitTests.TestHelper;
    using Microsoft.QualityTools.Testing.Fakes;
    using Microsoft.VisualStudio.TestTools.UnitTesting;


    [TestClass]
    public class RetrieveListOfProperties
    {
        private IDisposable context;

        private IPropertyManager _propertyManager;

        [TestInitialize]
        public void Setup()
        {
            context = ShimsContext.Create();
            _propertyManager = new PropertyManager(new FakeSitecore());
        }

        [TestCleanup]
        public void Teardown()
        {
            context.Dispose();
        }


        [TestMethod]
        public void Test_That_All_Properties_Are_Returned()
        {
            var properties = _propertyManager.GetAllProperties();

            var numberOfSemiDetachedProperties = properties.Where(x => x.PropertyType.Equals("Semi-Detached House"))
                                                           .Select(x => x.NumberOfBedrooms)
                                                           .FirstOrDefault();

            var numberOfTerracedProperties = properties.Where(x => x.PropertyType.Equals("Terraced House"))
                                                       .Select(x => x.NumberOfBedrooms)
                                                       .FirstOrDefault();

            Assert.IsInstanceOfType(properties, typeof(List<PropertySummary>));

            Assert.IsTrue(properties.Select(x => x.Cost).Contains("200000"));
            Assert.IsTrue(properties.Select(x => x.PostCode).Contains("Ec1 1ah"));
            Assert.AreEqual("1", numberOfSemiDetachedProperties);
            Assert.AreEqual("2", numberOfTerracedProperties);
        }

        [TestMethod]
        public void Test_Number_Of_Propeties()
        {

            var propertyCount = _propertyManager.GetCountOfProperties();

            Assert.IsInstanceOfType(propertyCount, typeof(PropertyCount));

            Assert.AreEqual(2, propertyCount.Count);
        }
    }
}
