    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace SO_39847703
    {
        class Program
        {
            static void Main(string[] args)
            {
                string json = "{\"GuvenlikNoktaArray\": {\"GuvenlikNoktası\": [{\"Id\": 1,\"GuvenlikNoktası1\":\"SANTIYE\",\"KartNo\":\"000001889174217\",\"Sira\": 1},{\"Id\": 2,\"GuvenlikNoktası1\":\"INSAAT\",\"KartNo\":\"000000803567858\",\"Sira\": 2},{\"Id\": 3,\"GuvenlikNoktası1\":\"ÇALISMA\",\"KartNo\":\"000003417926233\",\"Sira\": 3},{\"Id\": 4,\"GuvenlikNoktası1\":\"GÜVENLIK\",\"KartNo\":\"000001888909897\",\"Sira\": 4}]}}";
                AddIstasyon(json);
            }
            public static void AddIstasyon(string json_string)
            {
                dynamic jsonObject = JObject.Parse(json_string);
                string jsonToDeserializeStrongType = jsonObject["GuvenlikNoktaArray"]["GuvenlikNoktası"].ToString();
                List<GuvenlikNoktası> result = JsonConvert.DeserializeObject<List<GuvenlikNoktası>>(jsonToDeserializeStrongType); ;
            }
        }
        public partial class GuvenlikNoktası
        {
            public GuvenlikNoktası()
            {
                this.GüvenlikNoktasıOlay = new HashSet<GüvenlikNoktasıOlay>();
                this.PanikButonuAlarmlari = new HashSet<PanikButonuAlarmlari>();
            }
            public int Id { get; set; }
            public string GuvenlikNoktası1 { get; set; }
            public string KartNo { get; set; }
            public string Sira { get; set; }
            public virtual ICollection<GüvenlikNoktasıOlay> GüvenlikNoktasıOlay { get; set; }
            public virtual ICollection<PanikButonuAlarmlari> PanikButonuAlarmlari { get; set; }
        }
        public class GüvenlikNoktasıOlay
        {
        
        }
        public class PanikButonuAlarmlari
        {
        
        }
    }
