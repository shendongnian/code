    using System;
    
        class Program
        {
            static void Main(string[] args)
            {
                Foobar x = new Foobar();
                Console.WriteLine(x.bla); //this works (prints hello world)
                Console.WriteLine(x["bla"]); //this wont work but is my achivment
            }
        }
    
        class Foobar : Class
        {
            public Foobar()
            {
                this.bla = "hello world";
            }
    
            public string bla { get; set; }
        }
    
        class Class
        {
            public string this[string name]
            {
                get
                {
                    return this.GetType().GetProperty(name).GetValue(this).ToString();
                }
            }
        }
