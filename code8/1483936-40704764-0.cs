    var httpClientTwitterRegistration = Lifestyle.Transient.CreateRegistration<HttpClient>(
        () => new HttpClient("https://twitter"),
        container);
    container.RegisterConditional(typeof(HttpClient), httpClientTwitterRegistration,
        c => c.Consumer.ImplementationType == typeof(TwitterBusiness));
    var httpClientInstagramRegistration = Lifestyle.Transient.CreateRegistration<HttpClient>(
        () => new HttpClient("https://instagram"),
        container);
        
    container.RegisterConditional(typeof(HttpClient), httpClientInstagramRegistration,
        c => c.Consumer.ImplementationType == typeof(InstagramBusiness));
