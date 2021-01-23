    IShellProperty prop = ShellObject.FromParsingName("C:").Properties.GetProperty("System.Volume.BitLockerProtection");
    int? bitLockerProtectionStatus = (prop as ShellProperty<int?>).Value;
    if (bitLockerProtectionStatus.HasValue && (bitLockerProtectionStatus == 1 || bitLockerProtectionStatus == 3 || bitLockerProtectionStatus == 5))
       Console.WriteLine("ON");
    else
       Console.WriteLine("OFF");
