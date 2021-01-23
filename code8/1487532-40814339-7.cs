    [TestClass]
    public class UnitTest6 {
        [TestMethod]
        public async Task GetIdAsyncTest() {
            var id = await GetIdAsync("");
            Assert.IsNotNull(id);
        }
        public async Task<int> GetIdAsync(string username) {
            var httpClient = new HttpClient();
            var json = await Task.FromResult("[{\"Id\":1,\"FirstName\":\"a\"}]"); //await httpClient.GetStringAsync("");
            var list = JsonConvert.DeserializeObject<List<dynamic>>(json);
            var obj = list.FirstOrDefault();
            int Id = obj != null ? obj.Id : 0;
            return Id;
        }
    }
