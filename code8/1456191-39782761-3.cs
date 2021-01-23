    public void ContrivedScenario() {
        Foo foo = GetFooFromExternalDependency();
        FooBarAdapter adapter = new FooBarAdapter( foo );
        this.NeedsIBar( adapter );
    }
    public void NeedsIBar(IBar bar) { ... }
