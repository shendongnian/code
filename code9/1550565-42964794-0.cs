            Subject<Notification> producer = new Subject<Notification>();
            //This way there's only one producer feeding the group and the duration
            var connectedProducer =
                producer
                    .Publish()
                    .RefCount();
            connectedProducer
                .GroupByUntil(
                    item => item.Name,
                    item => connectedProducer.Where(x=> x.Id == 3))
                .SelectMany(result =>
                {
                    return result.Aggregate<Notification, List<Notification>>(new List<Notification>(), (dict, item) =>
                    {
                        dict.Add(item);
                        return dict;
                    });
                })
                //not sure if you need this but just a way to filter out the signal
                .Where(item => item.First().Id != 3) 
                .Subscribe(results =>
                {
                    //This will only run after a "3" is passed in and then you get a list of everything passed in with the names
                    //not sure if you wanted intermediate results or for it all to just come through once the signal indicates processing
                });
