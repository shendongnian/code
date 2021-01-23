        Mapper.Initialize(cfg =>
        {
            cfg.ShouldMapProperty = p =>
            {
                var setMethod = p.GetSetMethod(true);
                return !(setMethod == null || setMethod.IsPrivate || setMethod.IsFamily);
            };
        });
