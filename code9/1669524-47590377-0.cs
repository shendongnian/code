            var kernel = new StandardKernel();
            kernel.Bind<IContainer>()
                .To<Container>()
                .WithConstructorArgument("data",
                    ctx => ctx.Request.ParentContext.Parameters
                        .Single(x => x.Name == "data")
                        .GetValue(ctx, null));
            kernel.Bind<IAlgorithm>().To<Algorithm>();
            kernel.Bind<IAlgorithmFactory>().ToFactory();
            var factory = kernel.Get<IAlgorithmFactory>();
            var algorithm = factory.Create(new List<int>() { 1 });
