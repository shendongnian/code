        private void RemoveAllConventions(DbModelBuilder modelBuilder)
        {
            var conventions = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes().Where(t => t.IsClass && t.GetInterface("IConvention") != null));
            var remove = typeof(ConventionsConfiguration).GetMethods().Where(m => m.Name == "Remove" && m.ContainsGenericParameters).First();
            foreach (var item in conventions)
            {
                try
                {
                    remove.MakeGenericMethod(item).Invoke(modelBuilder.Conventions, null);
                }
                catch (Exception)
                {
                }
            }
        }
