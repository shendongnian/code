    public class WrapperObject : BrObject
    {
        public string Titolo { get; set; }
        public string Descrizione { get; set; }
        public Allegati Immagini { get; set; }
    
        public WrapperObject(BrObject o)
        {
            this.Titolo  = o.Titolo;
            this.Descrizione = o.Descrizione;
            this.Immagini = o.Immagini;
        }
    }
