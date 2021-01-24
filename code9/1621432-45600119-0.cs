    Initially(
        When(OrderCreated)
            .Then(context =>
            {
                ConsumeContext<IOrderCreated> c;
                if (context.TryGetPayload(out c))
                {
                    c.Headers.Get<string>("myheader");
                    // do something
                }
                context.Instance.OrderId = context.Data.OrderId; 
            })
