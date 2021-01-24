    const string TALL_COMPONENTS_LICENSE_KEY = "SOMETHING";
    TallComponents.Licensing.LicenseCollection.Add("PDFRasterizer.NET 3.0 Client Component Key", TALL_COMPONENTS_LICENSE_KEY);
    Assembly callingAssembly = Assembly.GetCallingAssembly();
    AssemblyProductAttribute product = callingAssembly.GetCustomAttribute<AssemblyProductAttribute>();
    AssemblyCompanyAttribute company = callingAssembly.GetCustomAttribute<AssemblyCompanyAttribute>();
    if (product.Product != "CONSTANT1")
    {
        throw new Exception("The product in the assembly is incorrect.");
    }
    if (company.Company != "CONSTANT2")
    {
        throw new Exception("The company in the assembly is incorrect.");
    }
