    using System;
          
    public class Program
    {
      public static void Main()
      {
        Movie m1 = new Movie("Matrix", MovieGenre.Action, 8, 2000 );
      }
    }
    public enum MovieGenre
    {
      Action,
      Horror,
      Drama,
      Comedy,
      Thriller
    }
    public class Movie
    {
    public string Title { get; set; }
    public MovieGenre Genre { get; set; }
    public int Rank { get; set; }
    public int Year { get; set; }
    public Movie( string title, MovieGenre genre, int rank, int year ){
     Title = title;
     Genre = genre;
     Rank = rank;
     Year = year;
    }
}
