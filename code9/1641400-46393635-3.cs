    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Json;
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
    public void TotalQuestions()
    {
        // Get the data.
        var responseStream = ...;
        var serializer = new DataContractJsonSerializer(typeof(TotalQuestionsResult));
        var result = (TotalQuestionsResult)serializer.ReadObject(responseStream);
        Console.WriteLine(result.Total);
    }
