        public string Codigo { get; set; } 
        public string Nombre { get; set; }
        public decimal ZZZDiferencia { get; set; }
    }
    public class cliente_ventas_Enero : cliente_ventas
    { 
        public String Tramo { get; set; } 
        public decimal EstrellasSupera { get; set; } 
        public decimal EstrellasVolumen { get; set; } 
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            foreach (var cv in MyMethod()) 
            {
                if (cv is cliente_ventas_Enero cve)
                {
                    // Do something with the variable cve (of type cliente_ventas_Enero) here.
                }
                else
                {
                    // Do something with the variable cv (of type cliente_ventas) here
                }
            }
        }
        public static List<cliente_ventas> MyMethod() 
        {
            var newList = new List<cliente_ventas>();
            // depending on your logic, add instances of cliente_ventas or cliente_ventas_Enero to the list here.
            return newList;
        }
    }
