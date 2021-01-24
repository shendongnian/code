    //Sabotage
    //Naughty Monkey
    //Hang Break
    //Fire & Dew
    Stack<string> movies = new Stack<string>();
            movies.Push("Fire & Dew");
            movies.Push("Hang Break");
            movies.Push("Naughty Monkey");
            movies.Push("Sabotage");
            //To display the data use foreach loop
            //You will notice that the foreach loop has displayed 
            //the movies in the reverse order to the order I put them on.
            Console.WriteLine("All Movies\n");
            foreach (string movie in movies)
            {
                Console.WriteLine(movie);
            }
            // To access the top most string which is "Fire & Dew title" 
            //I can get it by Pop()
            //Data will be lost using Pop() but if you do not want to 
            //lose  data use Peek() instead
            //try first
            string topMovie = movies.Pop();
            //try later
            //string topMovie = movies.Peek();
            Console.WriteLine($"\nTop Movie is:{topMovie}");
            Console.WriteLine("\nAll Movies: After popping\n");
            
            foreach (string movie in movies)
            {
                Console.WriteLine(movie);
            }
 
