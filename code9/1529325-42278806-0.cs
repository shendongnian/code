     if (platform == Platform.Android)
            {
                
                var path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                path = path.Substring(6);
                path = path.Replace("UITest", "My_AppFolder_PCL\\My_AppFolder_PCL.Droid");
                path = path + "/com.mycompany.myapp.apk";
                path = path.Replace("\\", "//");
                return ConfigureApp
                    .Android
                    .EnableLocalScreenshots()
                    .ApkFile(path)
                    .StartApp();
            }
