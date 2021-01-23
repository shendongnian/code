    kernel.Bind(c => c
                    .FromAssemblyContaining<IRecipeRepository>()
                    .IncludingNonePublicTypes()
                    .SelectAllClasses()
                    .BindDefaultInterface()
                    .Configure(y => y.InRequestScope()));
