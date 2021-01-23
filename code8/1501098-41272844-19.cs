    using static ExtensionsNamespace.Extensions;
    //...
    var info = GetAttribute<ExtrasDisplayAttribute>(LeadStatus.Created);
    var name = info.Name;
    var bg = info.BackgroundColor;
   
    //...
    public enum LeadStatus : byte
    {
        [ExtrasDisplay(Name = "Created", BackgroundColor = "Red")] Created = 1,
        [ExtrasDisplay(Name = "Assigned")] Assigned = 2,
    }
