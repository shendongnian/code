    var fixture = new Fixture();
    fixture.Customizations.Add(
        SpecimenBuilderNodeFactory.CreateTypedNode(
            typeof(IEnumerable<Item>),
            new Postprocessor(
                new EnumerableRelay(),
                new CompositeSpecimenCommand(
                    new AutoPropertiesCommand(),
                    new ItemCollectionSpecimenCommand()))));
    fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
        .ForEach(b => fixture.Behaviors.Remove(b));
    fixture.Behaviors.Add(new OmitOnRecursionBehavior());
