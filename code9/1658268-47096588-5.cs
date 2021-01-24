     List<Type> result = new List<Type>();
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
            foreach(var assem in assemblies)
            {
                var list = assem.GetExportedTypes().Where(t => t.GetInterfaces().Contains(typeof(IHttpHandler))).ToList();
                if (list != null && list.Count != 0)
                {
                    result.AddRange(list);
                }
            }
