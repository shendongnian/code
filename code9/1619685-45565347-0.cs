            var assemblies = AppDomain.CurrentDomain.GetAssemblies();           // Get my CurrentDomain Object
            Assembly myType = Assembly.GetExecutingAssembly();                  // Extract list of all references in my project
            foreach (var assembly in assemblies)                                // Search for the library that contains namespace that have needed controls
            {
                if (assembly.GetName().ToString().ToUpper().IndexOf("FIBACONTROLS") > -1)   
                {
                    myType = assembly;                                          // Get All types in the library
                    List<Type> myTps = myType.GetTypes().ToList();
                    Type mT = null;
                    foreach (Type selType in myTps)                             // Find the type that refer to needed user-defined control
                    {
                        if (selType.Name.ToUpper() == "FIBACOLORPICKER")
                        {
                            mT = selType;
                            break;
                        }
                    }
                    if (mT == null)
                        return;
                    object myInstance = Activator.CreateInstance(mT);           // Created an instance on the type
                    Control mFib = (Control)myInstance;                         // create the control's object
                    mFib.Name = "Hahah";                                        // add the control to my form
                    mFib.Left = 100;
                    mFib.Top = 200;
                    mFib.Visible = true;
                    this.Controls.Add(mFib);
                    break;
                }
            }
