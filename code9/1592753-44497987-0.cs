    public class Utente
    {
        private static readonly Lazy<Utente> lazy =
        new Lazy<Utente>(() => new Utente());
         
        // private C'tor - prevent from other to create your class
        private Utente() { }
        // Give access to your instnace
        public static Utente Instance
        {
            get
            {
                return lazy.Value;
            }
        }
