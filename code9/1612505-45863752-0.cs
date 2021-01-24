            builder.RegisterType<Database1>()
                .Keyed<IUnitOfWork>(DbName.Db1)
                .Keyed<DbContext>(DbName.Db1).AsSelf().InstancePerRequest();
            builder.RegisterType<Database2>()
                .Keyed<IUnitOfWork>(DbName.Db2)
                .Keyed<DbContext>(DbName.Db2).AsSelf().InstancePerRequest();
