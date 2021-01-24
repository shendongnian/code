            RspServer server = new RspServer();
            Type ClassType = server.GetType();
            Dictionary<string, string> Description2Value = new Dictionary<string, string>();
            foreach (System.Reflection.PropertyInfo pi in ClassType.GetProperties())
            {
                if (pi.GetCustomAttributes(typeof(Description),false).Length > 0)
                {
                    Description d = (Description)pi.GetCustomAttributes(typeof(Description), false)[0];
                    string PropVal = (string)pi.GetValue(server);
                    Description2Value.Add(d.Value, PropVal);
                }
            }
