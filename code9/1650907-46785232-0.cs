    eventAggregator.GetEvent<FooEventB>().Publish("Some Payload");
    
    eventAggregator.GetEvent<FooEventB>().Subscribe(OnFooEventBPublished);
    private void OnFooEventBPublished(string payload)
    {
       // Do stuff
    }
