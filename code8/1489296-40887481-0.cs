    // set the navigator bindings
    Kernel.Bind(s => s.FromAssemblyContaining(typeof(BaseWizardStepNavigator))
                      .SelectAllClasses()
                      .WhichAreNotGeneric()
                      .InheritedFrom<BaseWizardStepNavigator>()
                      .BindAllBaseClasses()
                      .Configure(c => c.InRequestScope())
                      );
    // pass in all children of BaseWizardStepNavigator to the manager instance
    Bind<NavigatorManager>().ToSelf()
                            .InRequestScope()
                            .WithConstructorArgument(typeof(IEnumerable<BaseWizardStepNavigator>),
                                                        n => n.Kernel.GetAll<BaseWizardStepNavigator>());
