        public interface IMachineFactory
        {
            IEquipmentData Create(IMachine machine);
        }
        public class EquipmentDataComponentSelector : ITypedFactoryComponentSelector
        {
            public Func<IKernelInternal, IReleasePolicy, object> SelectComponent(MethodInfo method, Type type, object[] arguments)
            {
                return (k, s) => k.Resolve<IEquipmentData>(new Dictionary<string, object> { ["machine"] = arguments[0] });
            }
        }
    Main:
        WindsorContainer container = new WindsorContainer();
        container.AddFacility<TypedFactoryFacility>();
        container.Register(
            Component.For<IEquipmentData>()
                     .ImplementedBy<MachineDataViewModel>()
                     .LifestyleTransient(),
            Component.For<EquipmentDataComponentSelector>(),
            Component.For<IMachineFactory>()
                     .AsFactory(f => f.SelectedWith<EquipmentDataComponentSelector>()));
        var machine = new IMachine();
        var factory = container.Resolve<IMachineFactory>();
        var resultWithFactory = factory.Create(machine);
