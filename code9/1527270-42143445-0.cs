    var pathWithEnv = @"%USERPROFILE%\AppData\Local\Cargas - Amostras\";
                if (System.IO.Directory.Exists(pathWithEnv))
                {
                    pathWithEnv = System.IO.Path.Combine(pathWithEnv, @"_logs\");
                    if (System.IO.Directory.Exists(pathWithEnv))
                    {
                    //Do what you want to do, both directories are found.    
                    }
                    else
                    {
                        System.IO.Directory.CreateDirectory(pathWithEnv);
                        //Do what you want to do, both directories are available.
                    }
                }
                else
                {
                    System.IO.Directory.CreateDirectory(pathWithEnv);
                    
                        pathWithEnv = System.IO.Path.Combine(pathWithEnv, @"_logs\");
                        if (System.IO.Directory.Exists(pathWithEnv))
                        {
                            //Do what you want to do, both directories are available now.
                        }
                        else
                        {
                            System.IO.Directory.CreateDirectory(pathWithEnv);
                            //Do what you want to do, both directories are created.
                        }
                }
