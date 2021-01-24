    public class Program
    {
        static void Main(string[] args)
        {
            // You can initialise movie list
            var movieList = new List<Movie>
            {
                new Movie
                {
                    movieName = "Back to the Future",
                    duration = 116
                }
            };
            
            //Display all movies in list
            int i = 0;
            foreach (var movie in movieList)
            {
                Console.WriteLine("({0}) Name: {1} | Duration: {2} mins", i, movie.movieName, movie.duration);
                i++;
            }
            //Selection of movie
            Console.Write("Please select a movie: ");
            var isNumber = int.TryParse(Console.ReadLine(), out var value);
            if (isNumber && value >= 0 && value < movieList.Count)
            {
                var userMovieSelection = Convert.ToInt32(value);
                var selectedMovie = movieList[userMovieSelection];
                Console.WriteLine("You've selected: {0} | {1} mins", selectedMovie.movieName, selectedMovie.duration);
            }
            else
            {
                Console.WriteLine("Incorrect value entered");
            }
            Console.ReadKey(true);
        }
    }
