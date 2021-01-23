    using (RegistryKey localMachine = Environment.Is64BitProcess
        ? RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
        : Registry.LocalMachine)
    {
        using (var key = localMachine.OpenSubKey("SOFTWARE\\MyCompany\\MyApp"))
        {
            if (key != null)
            {
                string project = (string) key.GetValue("PROJECT");
                if (!string.IsNullOrEmpty(project))
                {
                    if (project.Contains("000984"))
                    {
                        // do some project specific things here
                    }
                    else if(project.Contains("001065"))
                    {
                        // do some project specific things here
                    }
                }   
            }
        }
    }
