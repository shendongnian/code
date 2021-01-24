    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApp1
    {
        public class Program
        {
            public class Posts
            {
                public Posts()
                {
                    _tags = new List<string>();
                }
    
                private List<string> _tags { get;}
    
                public List<string> Tags
                {
                    get { return _tags ; }
                }
    
                public bool AddTag(string tag)
                {
                    var maxTag = 5; // put in config
    
                    if (_tags.Count() + 1 > maxTag)
                    {
                        //throw new Exception("unable to add tag... too many tags");
                        return false;
                    }
    
                    _tags.Add(tag);
                    return true;
                }
            }
    
            public static void Main()
            {
                // limit tags to 5
    
                var post = new Posts();
    
                for (var a = 0; a < 10; a++)
                {
                    Console.WriteLine(post.AddTag(a.ToString())
                        ? "Added " + a + " to the tags"
                        : "Failed to add " + a + " to the tags");
                }
    
                
            }
        }
    }
