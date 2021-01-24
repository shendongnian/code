    Console.WriteLine("Current: {0}", Settings.Default.MySetting);
    // we don't see the previous value here...
    Console.WriteLine("Previous: {0}", Settings.Default.GetPreviousVersion("MySetting"));
    // ...so we manually add the SettingsManageabilityAttribute to it...
    var setting = Settings.Default.Properties["MySetting"];
    setting.Attributes.Add(typeof(SettingsManageabilityAttribute), new SettingsManageabilityAttribute(SettingsManageability.Roaming));
    // ...retrieve the previous value...
    Console.WriteLine("Previous: {0}", Settings.Default.GetPreviousVersion("MySetting"));
    // ...and then clean up after ourselves by removing the attribute.
    setting.Attributes.Remove(typeof(SettingsManageabilityAttribute));
    // ...now we don't see the previous value anymore.
    Console.WriteLine("Previous: {0}", Settings.Default.GetPreviousVersion("MySetting"));
