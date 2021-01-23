        var isHeightValid = false;
        do 
        {
            var inputHeight = (Console.ReadLine ());
            if (!float.TryParse (inputHeight, out userHeight)) {
                Console.WriteLine ("Invalid input");
                Console.Write ("Please try again: ");
            } 
            else 
            {
                isHeightValid = false;
            }
        }
        while (!isHeightValid);
