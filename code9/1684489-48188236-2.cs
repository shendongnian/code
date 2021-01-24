            RspServer server = new RspServer();
            Type ClassType = server.GetType();
            Dictionary<string, string> Description2Value = new Dictionary<string, string>();
            foreach (PropertyInfo pi in ClassType.GetProperties().Where(pi => Attribute.IsDefined(pi, typeof(Description))))
            {
                Description d = (Description)pi.GetCustomAttributes(typeof(Description), false)[0];
                string PropVal = (string)pi.GetValue(server);
                Description2Value.Add(d.Value, PropVal);
            }
