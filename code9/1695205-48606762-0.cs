    public class ExampleTest : TestKit
    {
        [Fact]
        public void Select_should_map_output()
        {
            using (var materializer = Sys.Materializer())
            {
                // create test probe for subscriptions
                var probe = this.CreateManualSubscriberProbe<int>();
                
                // create flow materialized as publisher
                var publisher = Source.From(new[] { 1, 2, 3 })
                    .Select(i => i + 1)
                    .RunWith(Sink.AsPublisher<int>(fanout: false), materializer);
                // subscribe probe and receive subscription
                publisher.Subscribe(probe);
                var subscription = probe.ExpectSubscription();
                
                // request number of elements to receive, here drain source utill the end
                subscription.Request(4); 
                // validate assertions
                probe.ExpectNext(2);
                probe.ExpectNext(3);
                probe.ExpectNext(4);
                // since source had finite number of 3 elements, expect it to complete
                probe.ExpectComplete();
            }
        }
    }
