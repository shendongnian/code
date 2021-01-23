    using AutoMapper;
    ...
        public ObjectEntity Downcast() {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ObjectModel, ObjectEntity>());
            var mapper = config.CreateMapper();
            return mapper.Map<ObjectEntity>(this);
        }
