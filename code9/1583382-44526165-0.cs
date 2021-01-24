    else if(e.Error.InnerException is IOException)
                        {
                            bool canAccess = false;
                            while (!canAccess)
                            {
                                try
                                {
                                    File.Move(Userstate[0], Userstate[0]);
                                    canAccess = true;
                                    Debug.Print("Can now access file: " + Userstate[0]);
                                }
                                catch(IOException) { }
                            }
                        }
