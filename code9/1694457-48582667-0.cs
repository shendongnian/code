            IList<IService> Services = new List<IService>();
            foreach(var service in Assembly.GetExecutingAssembly().GetTypes().Where
            (t => String.Equals(t.Namespace, "Myapp.Services", StringComparison.Ordinal) && t.BaseType == typeof(object)))
            {
                if (service.Name == nameof(GetAccountService))
                {
                    Services.Add(new GetAccountService());
                }
                if (service.Name == nameof(GetCardsService))
                {
                    Services.Add(new GetCardsService());
                }
            }
            return Services.ToArray();
