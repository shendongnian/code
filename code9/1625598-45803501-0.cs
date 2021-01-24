        while(true)
    {
        if ( !content.Text.Equals ( driver.FindElementByXPath ( myXPath ).Text ) )
        {
                content = driver.FindElementByXPath ( myXPath );
                Console.WriteLine ( content.Text );
                Thread.Sleep(1); //add this code
        }
    }
