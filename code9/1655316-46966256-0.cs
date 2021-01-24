    public void SayLanguage()
            {
    #if en_US
                Console.WriteLine("en_US");
    #else
                Console.WriteLine("Language not defined.");
    #endif
            }
