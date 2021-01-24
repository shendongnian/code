    [DataContract]
    public class Model : IModel
    {
        public Model(string Codice, int position)
        {
            this.Codice = Codice;
            Position = position;
        }
        [DataMember(Name = "codice")]
        public string Codice { get; set; }
        [DataMember(Name = "position")]
        public int Position { get; private set; }
    }
