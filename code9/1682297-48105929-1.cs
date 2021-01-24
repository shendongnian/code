    public class MyServiceModule : Module
    {
        protected override void AttachToComponentRegistration(
            IComponentRegistry componentRegistry, IComponentRegistration registration)
        {
            registration.Preparing += Registration_Preparing;
            base.AttachToComponentRegistration(componentRegistry, registration);
        }
        private void Registration_Preparing(Object sender, PreparingEventArgs e)
        {
            e.Parameters = e.Parameters.Union(new[] {
                new ResolvedParameter(
                    (p, i) => p.ParameterType == typeof(MyService),
                    (p, i) => i.Resolve<MyService>(
                                new NamedParameter("className", 
                                                   p.Member.DeclaringType.ToString())
                              )
                ),
            });
        }
    }
