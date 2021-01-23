    #if UseExtA
    using ExternalService = ExtA.ExternalService;
    #endif
    #if UseExtB
    using ExternalService = ExtB.ExternalService;
    #endif
    #if UseGeneral
    using ExternalService = General.ExternalService;
    #endif
