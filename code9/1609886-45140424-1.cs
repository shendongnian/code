    //namespacaes to be imported at the top of your code file
    using System.Resources;
    using System.Reflection; 
    
    //source code for your method
    ResourceManager resourceManager = new ResourceManager("TestSatelliteAssembly.Resources.LocalizedResources",Assembly.GetExecutingAssembly());
    DataGridViewColumn.HeaderText = resourceManager.GetString("lblUserNameText");
