    RegistryKey subKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\" + Project.Properties.Resources.PRODUCT_NAME, true);
    const string FORMAT = ""yyyyMMddHHmmss";
    var dt = DateTime.Now;
    subKey.SetValue("TrialEndDate", dt.String(FORMAT), RegistryValueKind.String);
    var storedValue = subKey.GetValue("TrialEndDate") as string;
    var dt2 = DateTime.ParseExact(storedValue, FORMAT);
