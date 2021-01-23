    public class WcfServiceFactory : UnityServiceHostFactory
        {
            protected override void ConfigureContainer(IUnityContainer container)
            {
                //Attach hook for AOP attributes
                container.AddNewExtension<Interception>();
    
    			// register all your components with the container here
                // container
                //    .RegisterType<IService1, Service1>()
                //    .RegisterType<DataContext>(new HierarchicalLifetimeManager());
    
                container.RegisterTypes(AllClasses.FromLoadedAssemblies(),
                    WithMappings.FromMatchingInterface,
                    WithName.Default,
                    null,                //WithLifetime IF we want to change the lifetime aspect aka Singletons 
                    GetMembers,
                    false
                    );
    
                container.RegisterType<IPaymentService, PaymentService>();
                container.RegisterType<IPaymentManager, PaymentManager>();
                container.RegisterType<IPaymentMethodRepository, PaymentMethodRepository>();
                container.RegisterType<IPaymentWithdrawScheduleRepository, PaymentWithdrawScheduleRepository>();
                container.RegisterType<IPaymentPreEnrollmentRepository, PaymentPreEnrollmentRepository>();
                container.RegisterType<ISharedLoanDataRepository<tblPaymentMethod>, SharedLoanDataRepository<tblPaymentMethod>>();
                container.RegisterType<ISharedLoanDataRepository<tblPaymentWithdrawSchedule>, SharedLoanDataRepository<tblPaymentWithdrawSchedule>>();
                container.RegisterType<IPaymentWithdrawScheduleOffSetTypeRepository, PaymentWithdrawScheduleOffSetTypeRepository>();
                container.RegisterType<IPaymentMethodTypeRepository, PaymentMethodTypeRepository>();
                container.RegisterType<IPaymentWithdrawScheduleFrequencyTypeRepository, PaymentWithdrawScheduleFrequencyTypeRepository>();
                container.RegisterType<IPaymentCustomerNotificationRepository, PaymentCustomerNotificationRepository>();
                container.RegisterType<ITraceLogger, TraceLogger>();
                container.RegisterType<IPaymentWithdrawScheduleCancelReasonRepository, PaymentWithdrawScheduleCancelReasonRepository>();
            }
    
            private IEnumerable<InjectionMember> GetMembers(Type type)
            {
                var list = new List<InjectionMember>();
                list.Add(new InterceptionBehavior<PolicyInjectionBehavior>(type.ToString()));
                list.Add(new Interceptor<InterfaceInterceptor>(type.ToString()));
                return list;
            }
        } 
