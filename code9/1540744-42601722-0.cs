    static void Main(string[] args)
        {
            List<Lista> products = new List<Lista>();
            products.Add(new Lista() { codigo = 01, precio = 6.00, producto = "aceite mezcla" });
            products.Add(new Lista() { codigo = 02, precio = 2.00, producto = "arroz" });
            //Print out 'products'
            foreach (Lista l in products)
            {
                Console.WriteLine(string.Format("{0}\t|{1}\t|{1}", l.codigo, l.producto, l.precio));
            }
            
            int consoleInput;
            if(int.TryParse(Console.ReadLine(), out consoleInput))
            {
                Lista target = products.Find((lista) => lista.codigo == consoleInput);
                Console.WriteLine(target.codigo + "\t" + target.producto + "\t" + target.precio);
            }
            Console.ReadLine();
            
        }
        public struct Lista
        {
            public double precio;
            public string producto;
            public int codigo;
        }
