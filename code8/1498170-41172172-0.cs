    internal class Program {
        struct Page { //Like an inline class, usually used if you need an object that won't be reused often
            /// <summary>
            /// Name of Page
            /// </summary>
            public String Name { get; set; }
            /// <summary>
            /// Text Page contains
            /// </summary>
            public String Text { get; set; }
            /// <summary>
            /// Date the Page was wrote
            /// </summary>
            public DateTime Date { get; set; }
            /// <summary>
            /// Creates a new Page
            /// </summary>
            /// <param name="n">Name of the Page</param>
            /// <param name="t">Text contained in the page</param>
            /// <param name="d">Date of the Page</param>
            public Page(String n, String t, DateTime d) {
                this.Name = n; //Name
                this.Text = t; //Text
                this.Date = d; //Date      Use DateTime.Now to get the current time
            }
        }
        public static void Main(string[] args) {
            List<Page> Book = new List<Page>();
            Book.Add(new Page("Page Name", "I'm Some Text!", DateTime.Now)); //An example entry
            Book.Add(new Page("Page2", "And some more!", DateTime.Today));
            Book.Add(new Page("Page 3", "And a bit more", DateTime.MaxValue));
            foreach (var p in Book) { //for each variable in book -> var can be used if you don't know the object's type
                string str = string.Format("{0} | {1} : {2}", p.Date, p.Name, p.Text); //returns a string where the numbers replaced by the parameters
                Console.WriteLine(str); //writes the string to the console
            }
            Console.Read(); //Stops console from automatically closing
            /*RESULT
             * 
             * 15/12/2016 19:42:46 | Page Name : I'm Some Text!
             * 15/12/2016 00:00:00 | Page2 : And some more!
             * 31/12/9999 23:59:59 | Page 3 : And a bit more
             * 
             */
        }
    }
