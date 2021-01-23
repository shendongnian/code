    public WhateverYouNeedForTheDatabase Foo { get; set; }
    [ProtoMember(someNumber)]
    private WhateverYouNeedForTheSerializer FooSerialized {
        get { return FromX(Foo); }
        set { Foo = ToX(value); }
    }
