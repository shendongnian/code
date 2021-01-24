       [TestMethod]
       public void GroupByWithMultipleStreams()
        {
            Subject<Notification> producer = new Subject<Notification>();
            Subject<RelatedToNotification> otherThingProducer = new Subject<RelatedToNotification>();            
            Observable.Merge(
                producer.Select(n => new { Id = n.Id, notification = n, relatedNotification = (RelatedToNotification)null }),
                otherThingProducer.Select(rn => new { Id = rn.NotificationId, notification = (Notification)null, relatedNotification = rn }))
                .GroupBy(x => x.Id)
                .SelectMany(obs =>
                {
                    return obs.Scan(new ComplexObject() { Id = obs.Key }, (acc, input) =>
                    {
                        acc.Notification = input.notification ?? acc.Notification;
                        acc.Related = input.relatedNotification ?? acc.Related;
                        return acc;
                    });
                })
                .Where(result => result.Notification != null && result.Related != null) // if you only want it to fire when everything has a value
                .Subscribe(result =>
                {
                    //do something with the results here
                }
                );
             
            producer.OnNext(new Notification() { Id = 1, Version = 1 });
            producer.OnNext(new Notification() { Id = 1, Version = 2 });
            producer.OnNext(new Notification() { Id = 2, Version = 17 });
            producer.OnNext(new Notification() { Id = 1, Version = 3 });
            producer.OnNext(new Notification() { Id = 9, Version = 0 });
            producer.OnNext(new Notification() { Id = 9, Version = 1 });
            otherThingProducer.OnNext(new RelatedToNotification() { NotificationId = 2,  SomeData = "2data" });
            otherThingProducer.OnNext(new RelatedToNotification() { NotificationId = 2, SomeData = "2data1" });
            otherThingProducer.OnNext(new RelatedToNotification() { NotificationId = 9, SomeData = "9Data" });
            producer.OnNext(new Notification() { Id = 2, Version = 1 });
        }
        class ComplexObject
        {
            public int Id { get; set; }
            public Notification Notification { get; set; }
            public RelatedToNotification Related { get; set; }
        }
        class Notification
        {
            public int Id { get; set; }
            public int Version { get; set; }
            public string Name { get; set; }
        }
        public class RelatedToNotification
        {
            public int NotificationId { get; set; }
            public string SomeData { get; set; }
        }
