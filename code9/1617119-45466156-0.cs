            if (true)
            {
                services.AddSingleton((_) => MockDbContext.GetMockDbContext());
            } else
            {
                services.AddScoped((_) => new ProductionDbContext());
            }
