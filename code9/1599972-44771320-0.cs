     void bindHandler(string buttonName)
            {
                string methodName = buttonName + "_click";  
                System.Reflection.MethodInfo m = this.GetType().GetMethods().FirstOrDefault(x => x.Name == buttonName + "_click");
                PictureBox button = buttonList[buttonName];
                Delegate handler = Delegate.CreateDelegate(typeof(EventHandler), this, m);
                button.Click += (EventHandler)handler;
            }
