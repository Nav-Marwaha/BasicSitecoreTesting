using StructureMap;
namespace BasicSitecoreSolution {
    using BasicSitecoreSolution.BusinessLogic.Properties;
    using BasicSitecoreSolution.BusinessLogic.Wrappers;

    public static class IoC {
        public static IContainer Initialize() {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                    });
            //                x.For<IExample>().Use<Example>();

                            x.For<ISitecoreWrapper>().Use<SitecoreWrapper>();
                            x.For<IPropertyManager>().Use<PropertyManager>();
                        });
            return ObjectFactory.Container;
        }
    }
}