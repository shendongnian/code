            Mapper.Initialize(cfg =>
                    {
                        cfg.CreateMap<Entity, EntityModel>()
                            .ReverseMap().ForMember(x => x.Messages, o => o.Ignore());
                        cfg.CreateMap<Message, MessageModel>()
                            .ReverseMap();
                    });
            Mapper.Configuration.AssertConfigurationIsValid();
            var model = new EntityModel() { Messages = new List<MessageModel>() { } };
            var entity = new Entity() { Messages = new List<Message>() { new Message() { Content = "Test" } } };
            Mapper.Map(model, entity);
            Assert.IsTrue(entity.Messages.Count == 1);
