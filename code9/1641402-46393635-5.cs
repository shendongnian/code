    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Json;
    using System.Threading.Tasks;
    using System.Net;
    using System.Net.Http;
    using System.IO;
    [DataContract]
    public class Question
    {
        // Question members...
    }
    [DataContract]
    public class TotalQuestionsResult
    {
        [DataMember(Name = "items")]
        public Question[] Items { get; set; }
        [DataMember(Name = "has_more")]
        public bool HasMore { get; set; }
        [DataMember(Name = "quota_max")]
        public int QuotaMax { get; set; }
        [DataMember(Name = "quota_remaining")]
        public int QuotaRemaining { get; set; }
        [DataMember(Name = "total")]
        public int Total { get; set; }
    }
    public async Task<int> GetTotalNumberOfQuestions()
    {
        // Get the data.
        using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate }))
        {
            client.BaseAddress = new Uri("https://api.stackexchange.com/2.2");
            var response = await client.GetAsync("questions?fromdate=1506211200&todate=1506297600&order=desc&sort=creation&site=stackoverflow&filter=!)5IW-5QudQH7_nJ7d.eBuocQb(B)");
            var responseStream = new MemoryStream(await response.Content.ReadAsByteArrayAsync());
            var serializer = new DataContractJsonSerializer(typeof(TotalQuestionsResult));
            var result = (TotalQuestionsResult)serializer.ReadObject(responseStream);
            
            return result.Total;
        }
    }
