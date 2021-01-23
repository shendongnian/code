    public class Room
    {
       public string Type { get; set; } = "Default"; // with C#6 property initialization
       public double Length { get; set; }
       public double Width { get; set; }
       public double Height { get; set; }
       public Room() {} // no code here, Type is initalized, double is 0 by default
       public Room(string t, double l, double w, double h)
       {
            Type = t;
            Length = l;
            Width = w;
            Height = h;
       }
       public double GetArea()
       {
            return Length * Width;
       }
       public double GetVolume()
       {
            return Length * Width * Height;
       }
       public void Display()
       {
            Console.WriteLine("Room Type: " + Type);
            Console.WriteLine("Room Length: " + Length);
            Console.WriteLine("Room Width: " + Width);
            Console.WriteLine("Room Height: " + Height);
            Console.WriteLine("Room Area: " + GetArea().ToString("F 2") + " sq ft " );
            Console.WriteLine("Room Volume: " + GetVolume().ToString("F 2") + " cu ft ");
        }
    }
    
