    services.AddMassTransit(c =>
    {
        c.AddConsumer<MyConsumer>();
        c.AddConsumer<MyOtherConsumer>();
        // or sagas
        c.AddSaga<MySaga>();
    });
    // you still need to register the consumers/sagas
    services.AddScoped<MyConsumer>();
    services.AddScoped<MyOtherConsumer>();
    services.AddSingleton<ISagaRepository<MySaga>, InMemorySagaRepository<MySaga>>();
