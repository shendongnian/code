        try
        {
            if (int.Parse(q.textBoxNumberOfEmployees.Text) < 15)
            {
                Rect1.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            }
        }
        catch(System.FormatException ex) //This code will be executed because a System.FormatException was thrown
        {
            //write the error message to the console (optional)
            Console.WriteLine(ex.Message);
            //You can write whatever code you'd like here to try and combat the error.
            //One possible approach is to just fill Rect1 regardless. Delete the
            //code below if you would not like the exception to fill Rect1
            //if this exception is thrown.
            Rect1.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        }
