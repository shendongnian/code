    namespace Randomizer
    {
        public class Apartment
        {
            public int height;
            public int bas;
            public int hasPent;
            public Room[,,] rooms;
    
            public Apartment(int b = 100, int h = 100, int p = 100)
            {
                height = h;
                bas = b;
                hasPent = p;
                rooms = new Room[bas, bas, height];
                finCon(bas, height, hasPent, rooms);
            }
    
            public void finCon(int b, int h, int p, Room[,,] ro)
            {
                Random r = new Random();
                if (b == 100)
                {
                    b = r.Next(2, 4);
                }
                if (h == 100)
                {
                    h = r.Next(4, 15);
                }
                if (p == 100)
                {
                    p = r.Next(0, 20);
                }
            }
        }
    
        public class Room
        {
            int some = 37;
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Apartment ap = new Apartment();
                ap.finCon(ap.bas, ap.height, ap.hasPent, ap.rooms);
                Console.WriteLine("{0}{1}", ap.bas, ap.height);
            }
        }
    }
