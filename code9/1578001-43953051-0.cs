    using System;
    using System.Collections;
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                ObservableCollection<MovieModel> models = CreateLists("a", DateTime.Now, new List<string>() { "a", "c" });
            }
            public static ObservableCollection<MovieModel> CreateLists(string name, DateTime date, List<string> names)
            {
                MovieModel db = new MovieModel() { 
                    MovieModels = new List<MovieModel>() {
                        new MovieModel() { Name ="a"},
                        new MovieModel() { Name ="b"},
                        new MovieModel() { Name ="c"}
                    }
                };
                ObservableCollection<MovieModel> contained = new ObservableCollection<MovieModel>();
                // checks if the Movie Names from "names" are in the db
                foreach (var item in names)
                {
                    var query = from c in db.MovieModels
                                where c.Name == item 
                                select c;
                    foreach (var t in query)
                    {
                        contained.Add(t);
                    }
                }
                return contained;
            }
        }
        public class MovieModel
        {
            public List<MovieModel> MovieModels { get; set; }
            public string Name { get; set; }
        
        }
     
    }
