    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    
    namespace Processing {
        public class MyProcessor {
    
            public async Task<IEnumerable<Subscription>> ProcessSubscriptionRequestsAsync(IEnumerable<SubscriptionRequest> subscriptionRequests) {
                var subscriptionProcessingTasks = subscriptionRequests.Select(request => ProcessSubscriptionForASingleRecord(request)).ToArray();
                return await Task.WhenAll(subscriptionProcessingTasks);
            }
    
            public async Task<Subscription> ProcessSubscriptionForASingleRecord(SubscriptionRequest request) {
                //process the request
                try {
                    var subscription = await Context.ProcessRequest(request);
                    return subscription;
                } catch {
                    //something went wrong with the request
                }
            }
        }
    
        public class SubscriptionRequest {
            //A subcription request
        }
    
        public class Subscription {
            //A completed subscription request
        }
    }
