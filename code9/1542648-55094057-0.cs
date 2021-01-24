    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Box box1 = new Box();
                Box box2 = new Box();
                box2.Checked = true;
                switch (true)
                {
                    case true when box1.Checked:
                        Console.WriteLine("box1 is checked");
                        break;
                    case true when box2.Checked:
                        Console.WriteLine("box2 is checked");
                        break;
                    default:
                        Console.WriteLine("neither box checked");
                        break;
                }
                return;
            }
        }
    
        class Box
        {
            public bool Checked = false;
        }
    }
