    using System;
    using System.Configuration;
    var connectionString = "...";
    var connectionStringSetting = new ConnectionStringSettings("OrionDB", connectionString);
    var field = ConfigurationElementCollection.GetField("bReadOnly",
        Reflection.BindingFlags.NonPublic | Reflection.BindingFlags.Instance);
    var connectionStrings = ConfigurationManager.ConnectionStrings;
    field.SetValue(connectionStrings, false);
    connectionStrings.Add(connectionStringSetting);
