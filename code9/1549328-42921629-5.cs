    public class MvcRegistry : Registry
        {
            public MvcRegistry()
            {
                For<BundleCollection>().Use(BundleTable.Bundles);
                For<RouteCollection>().Use(RouteTable.Routes);
                For<IIdentity>().Use(() => HttpContext.Current.User.Identity);
                For<IUserStore<ApplicationUser>>().Use<UserStore<ApplicationUser>>();
                For<DbContext>().Use(() => new ApplicationDbContext());
                For<IAuthenticationManager>().Use(() => HttpContext.Current.GetOwinContext().Authentication);
                For<HttpSessionStateBase>().Use(() => new HttpSessionStateWrapper(HttpContext.Current.Session));
                For<HttpContextBase>().Use(() => new HttpContextWrapper(HttpContext.Current));
                For<HttpServerUtilityBase>().Use(() => new HttpServerUtilityWrapper(HttpContext.Current.Server));
            }
        }
