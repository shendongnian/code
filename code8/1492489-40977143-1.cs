    var buffer = new StringBuilder();
    using (var api = new KeystrokeAPI())
    {
        api.CreateKeyboardHook((character) => { 
            if (character.ToString() == " ") 
            {
                //check the word
                CallSomeMethodToCheckWord(buffer.ToString());
                //reset the buffer
                buffer = new StringBuilder();
            } 
            else 
            {
                //ToString returns special characters in it, so you could append here and parse later, or parse here.
                buffer.Append(character.ToString());
            }
        });
        Application.Run();
    }
