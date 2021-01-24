    void Main()
    {
        Director d1 = new Director("Wachowski Brothers", "USA"); 
        Movie m1 = new Movie("Matrix", d1);
        Console.WriteLine(m1.Title);
        Console.WriteLine(m1.director.Name);
    }
    
    class Movie
    {
        public Director director; 
        public string Title { get; set; }
    
        public Movie( string title, Director directorName ){
         Title = title;
         director=directorName;
    
        }
    }
    class Director
    {
        public string Name { get; set; }
        public string Nationality { get; set; }
    
        public Director(string name, string nationality){
            Name = name;
            Nationality = nationality;
        }
    }
