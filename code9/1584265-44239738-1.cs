    public class HotelService
    {
        private ConcurrentDictionary<int, Lazy<TestPnrHeaderResponse>> _sharedList
            = new ConcurrentDictionary<int, Lazy<TestPnrHeaderResponse>>();
        private TestPnrHeaderResponse LoadGetCache(int count)
        {
            var resp = new Lazy<TestPnrHeaderResponse>();
            resp.Value.PnrLegs = new List<PnrLegVM>();
            resp.Value.listInt = new List<int>();
            List<int> listInt = resp.Value.listInt;
            Task.Factory.StartNew(() =>
            {
                listInt.AddRange(GetIntList());
            });
            
            return resp.Value;
        }
        private IEnumerable<int> GetIntList()
        {
            return Enumerable.Range(0, 5);
        }
        public TestPnrHeaderResponse TestMultiThread(int count)
        {
            var resp = new TestPnrHeaderResponse();
            resp = _sharedList.GetOrAddLazy(count,(k)=> LoadGetCache(k));
          
            if (resp == null)
            {
                LoadGetCache(count);
            }
            if (resp != null)
            {
                if (count % 2 == 0)
                {
                    resp.PnrLegs.Add(new PnrLegVM
                    {
                        ApplicationType = count.ToString(),
                        PKCity = count,
                        PKNationality = 1,
                        PKPnrHeader = 1,
                        PKPnrLeg = 1
                    });
                    resp.StatusCode = System.Net.HttpStatusCode.Accepted;
                }
                else
                {
                    resp.PnrLegs.Add(new PnrLegVM
                    {
                        ApplicationType = count.ToString(),
                        PKCity = count,
                        PKNationality = 99,
                        PKPnrHeader = 99,
                        PKPnrLeg = 99
                    });
                    resp.StatusCode = System.Net.HttpStatusCode.Redirect;
                }
            }
            return resp;
        }
    }
