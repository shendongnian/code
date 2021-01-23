        using LightSwitchApplication.UserCode;
        namespace LightSwitchApplication
        {
            public partial class Application
            {
                partial void Application_Initialize()
                {
                    Current.CreateDataWorkspace().DeleteAllSets();
                }
                //Some other methods here if you already modified this class.
            }
        }
