    public class OriginalSynchronous {
        public void ProcessSubscriptionRequest() {
            List<SubscriptionRequest> lstSubscriptionRequests = FromSomeResource();
            List<Task> tsk = new List<Task>();
            Parallel.ForEach(lstSubscriptionRequests, objSubscriptionRequest => {
                var oTsk =
                    new Task(
                        () => ProcessSubscriptionForASingleRecord(objSubscriptionRequest));// update some properties after processing SubscriptionRequest
                oTsk.Start();
                lock (tsk) {
                    tsk.Add(oTsk);
                }
            });
            Task.WaitAll(tsk.ToArray());
        }
        private void ProcessSubscriptionForASingleRecord(SubscriptionRequest request) {
            //modify SubscriptionRequest
        }
    }
    public class ModifiedAsync {
        public async Task ProcessSubscriptionRequest() {
            var subscriptionRequests = await FromSomeResourceAsync();
            var tasks = subscriptionRequests.Select(request => {
                return ProcessSubscriptionForASingleRecord(request);
            }).ToArray();
            await Task.WhenAll(tasks);
        }
        public async Task ProcessSubscriptionForASingleRecord(SubscriptionRequest request) {
            //modify SubscriptionRequest
        }
    }
