    static void Main(string[] args)
            {
                DeviceUserGroup folder = GetTopLevelGroupAsYouWish();
                BuildHierarchy (folder);
                Console.ReadKey();
            }
            static void BuildHierarchy(DeviceUserGroup userGroup)
            {
                try
                {
                    foreach (Device device in userGroup.Devices)
                        Console.WriteLine(device.Name);
                    foreach (DeviceUserGroup group  in userGroup.Groups)
                    {
                        Console.WriteLine(group.Name);
                        BuildHierarchy(group);
                    }
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
