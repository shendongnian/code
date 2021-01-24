    var dbContextParameter = new ResolvedParameter((pi, ctx) => pi.ParameterType == typeof(IdentityDbContext),
                                                        (pi, ctx) => ctx.Resolve<DatabaseContext>());
      builder.RegisterType<UserStore<User, Role, DatabaseContext, Guid,UserClaim,UsersInRole,UserLogin,UserToken,RoleClaim>>()
                .As<IUserStore<User>>().WithParameter(dbContextParameter).InstancePerLifetimeScope();
            builder.RegisterType<CustomRoleStore>()
                //RegisterType<UserStore<User, Role, DatabaseContext, Guid,UserClaim,UsersInRole,UserLogin,UserToken,RoleClaim>>()
                .As<IRoleStore<Role>>().WithParameter(dbContextParameter).InstancePerLifetimeScope();
