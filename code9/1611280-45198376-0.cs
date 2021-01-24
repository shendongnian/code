    namespace StackOverflow45198156
    {
        class Program
        {
            static void Main(string[] args)
            {
                string json = "[{\"Name\":\"Joe\",\"Id\":\"10eea25b-16aa-42d6-950a-4c28cb0537f4\"},{\"Name\":\"Fred\",\"Id\":\"a913f4b4-1c82-4d19-ade8-949227ac7d08\"}]";
    
                var list = JsonConvert.DeserializeObject<List<NameAssociation>>(json);
            }
        }
    
        public abstract class BusinessObjectBaseId
        {
            [DataMember]
            public Guid Id { get; set; }    
        }
    
        [DataContract]
        public class NameAssociation : BusinessObjectBaseId
        {
            [DataMember]
            public string Name { get; set; }
        }
    }
