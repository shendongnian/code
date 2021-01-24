    void Main()
    {
        Movie m1 = new Movie("Matrix", "Wachowski Brothers", "USA");
        Console.WriteLine(m1.Title);
        Console.WriteLine(m1.director.Name);
    }
    
    class Movie
    {
        public Director director; 
        public string Title { get; set; }
    
        public Movie( string title, Director director ){
         Title = title;
         this.director=director;
    
        }
    
        public Movie( string title, string DirectorName, string DirectorNationality){
         Title = title;
         director=new Director(DirectorName, DirectorNationality);
    
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
