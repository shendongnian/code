    using System;
					
    public class Program
    {
     	public static void Main()
     	{
		Console.WriteLine("Hello World");
		
		decimal[][] grades = {
            new decimal []{255628, 89.6m, 90, 82.9m},
            new decimal []{311899, 77.7m, 83.9m, 81.8m, 77},
            new decimal []{314499, 100, 93.7m, 96.7m},
            new decimal []{323345, 62.1m, 55.2m}
        };
        foreach (var i in grades)
        {
            foreach (var j in grades)
            {
				foreach(var k in j){
				   
					Console.WriteLine(k);
				}
                //textBox1.Text += [i, j] + "\t"; 
            }
        }
        //textBox1.Text += "\r\n";
    
     	}
    }
