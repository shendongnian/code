    using (var fs = new FileStream(@"g:\temp_test.txt", FileMode.Append))
            {
                fs.SetAccessControl(new FileSecurity(@"g:\temp_test.txt", AccessControlSections.Access));
                using (var s = new StreamWriter(fs))
                {
                    s.WriteLine("Test");
                }
            }
