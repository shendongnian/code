    public static void Main(string[] args)      
    {   
         //some stuff
        while ((NewMorg = MyReader.ReadMorg()) != null)
        {
            string NewMorgName = NewMorg.getName();
            Location NewMorgXY = NewMorg.getLocation();
            string NewMorgMovement = NewMorg.getMovement();
            string NewMorgFeeding = NewMorg.getFeeding();
            Console.WriteLine(NewMorgName + " " + NewMorgXY.X + " " + NewMorgXY.Y + " " + NewMorgMovement + " " + NewMorgFeeding);
            //MyReader.Close(); -> this line put it out from the while loop
        }
        //put it here
        MyReader.Close();
       //other stuff
     }
