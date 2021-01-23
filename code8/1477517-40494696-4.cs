    public class Person
    {
        public string Nombre { get: set; }
        public string Apellido { get: set; }
        public string Edad { get: set; }
    }
    static void showPersonas(Person[] personsList)        
    {
        foreach (var algo in personsList) 
        {
            Console.WriteLine(algo.nombre);
        }
    }
