            if (Directory.Exists(rootFolder))
            {
                try
                {
                    string[] valid = { "Test", "OtherTest" };
                    foreach (string f in Directory.GetFiles(rootFolder))
                    {
                        if (valid.Any(v => f.ToString().Contains(v)))
                        {
                            // create file
                        }
                    }
                }
                catch
                {
                    // log stuff
                }
            }
        }
