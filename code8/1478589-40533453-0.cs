    public class Enero
    {
        public string valor { get; set; }
        public string almacenado { get; set; }
    }
    
    public class Febrero
    {
        public string valor { get; set; }
        public string almacenado { get; set; }
    }
    
    public class Mayo
    {
        public string valor { get; set; }
        public string almacenado { get; set; }
    }
    
    public class Agosto
    {
        public string valor { get; set; }
        public string almacenado { get; set; }
    }
    
    public class Noviembre
    {
        public string valor { get; set; }
        public string almacenado { get; set; }
    }
    
    public class ListadoMeses
    {
        public Enero Enero { get; set; }
        public Febrero Febrero { get; set; }
        public Mayo Mayo { get; set; }
        public Agosto Agosto { get; set; }
        public Noviembre Noviembre { get; set; }
    }
    
    public class RootObject
    {
        public string accion { get; set; }
        public string ejercicio { get; set; }
        public string codigoPieza { get; set; }
        public string solicitado { get; set; }
        public string solicitante { get; set; }
        public ListadoMeses listadoMeses { get; set; }
    }
