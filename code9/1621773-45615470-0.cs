    static async Task StartListenForMouseChangeAsync()
        {
         await Task.Factory.StartNew(()=> {
          do
            {
              Console.Title = "Scanning";
               var mouse = new ManagementObjectSearcher($"winmgmts:\\.\\root\\CIMV2");
                mouse.Query = new ObjectQuery("SELECT * FROM Win32_PointingDevice");
                var data = mouse.Get();
                var states = new Boolean[data.Count];
                var props = new List<ManagementBaseObject>();
                  foreach (var item in data)
                    {
                      props.Add(item);
                    }
                    for (int i = 0; i < data.Count; i++)
                        {
                            states[i] = props[i].Properties["DeviceID"].Value.ToString().StartsWith("USB");
                        }
    
                        var hasUsbMouse = states.Contains(true);
    
                        Console.Title = $"Mouse Status: {hasUsbMouse}";
    
                        Thread.Sleep(5000);
                        Console.Clear();
                    } while (true);
    
                }, TaskCreationOptions.LongRunning);
            }
