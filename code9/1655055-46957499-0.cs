    List<Device> GetDevices()
        {
            List<Device> devices = new List<Device>();
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly assembly in assemblies)
            {
                try
                {
                    foreach (var ti in assembly.DefinedTypes)
                    {
                    
                        if (ti.BaseType == typeof(Device))
                        {
                         devices.Add((Device)assembly.CreateInstance(ti.FullName));
                        }
                    }
                }
                catch
                { }
            }
            return devices;
        }
