        void DeleteClass()
        {
            string ns, cl;
            ns = "nameSpace path";
            cl = "ClassName";
            string serverString = @"\\" + System.Environment.GetEnvironmentVariable("COMPUTERNAME") +ns;
            ManagementScope mScope = new ManagementScope(serverString);
            using (ManagementClass cls = new ManagementClass(mScope, new ManagementPath(cl), new ObjectGetOptions()))
            {
                using (ManagementObjectCollection objCol = cls.GetInstances())
                {
                    foreach (ManagementObject obj in objCol)
                    {
                        obj.Delete();//cleare the instances
                    }
                }
                cls.Delete();//delete the class
            }
        }
