    container.Kernel.AddFacility<WcfFacility>()
                .Register(Component.For<IXMLGenerateService>()
                .AsWcfClient(new DefaultClientModel
                {
                    Endpoint = WcfEndpoint.FromConfiguration("wsSecureService")
                }.Credentials(new UserNameCredentials("zul", "password"))));
            
            _smXMLGenerateService = container.Resolve<IXMLGenerateService>();
