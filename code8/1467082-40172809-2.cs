    static void SimulateTyping(string message, int delay = 100) {        //'delay' is optional when calling the function
        foreach (char character in message)                               //take every character from your string seperately
        {
            Console.Write(character);                                     //print one character
            System.Threading.Thread.Sleep(delay);                         //wait for a small amount of time
        }
    }
