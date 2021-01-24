    {
        StreamWriter a = new StreamWriter ("qasim.txt");
        a.WriteLine ("user a");
        a.WriteLine ("pass a");
        a.WriteLine ("user b");
        a.WriteLine ("pass b");
        a.Close ();
        string username = Console.ReadLine ();
        string pass = Console.ReadLine ();
        StreamReader ab = new StreamReader ("qasim.txt");
        string line1 = ab.ReadLine ();
        string line2 = ab.ReadLine ();
        //int counter1 = 0;
        //int x = 1;
        while ((line1 != null) && (line2 != null))
        {
            if ((line1 == username) && (line2 == pass))
            {
                Console.WriteLine ("Welcome");
                break;
            }
            Console.WriteLine ("Try Again");
            line1 = ab.ReadLine ();
            line2 = ab.ReadLine ();
        }
        Console.WriteLine ();
        ab.Close ();
    }
