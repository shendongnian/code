     Configuration config = serverManager.GetApplicationHostConfiguration();
                var section = config.GetSection("system.webServer/modules", "");
                var collection = section.GetCollection();
                var element = collection.CreateElement();
                element.Attributes["name"].Value = "MyHttpModule";
                element.Attributes["type"].Value = MyHttpModule.XXXModule, MyHttpModule, Version=1.0.0.0, Culture=neutral, PublicKeyToken=bc88fbd2dc8888795";
                collection.Add(element);
                serverManager.CommitChanges();
