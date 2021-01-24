    public class Sesion
    {
        static Sesion()
        {
            Instance = new Sesion();
        }
        public static Sesion Instance { get; }
        private Sesion() { }
        public int IdSesion { get; set; }
        //other properties...
    }
