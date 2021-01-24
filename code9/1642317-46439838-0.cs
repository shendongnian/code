            static void Main(string[] args)
            {
                MyListClass[] myListClass = new MyListClass[3];
                Console.WriteLine(Pull<string>("","",myListClass));
            }
        }
        public class MyListClass
        {
            string myProperty { get; set; }
        }
