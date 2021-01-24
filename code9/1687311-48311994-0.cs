    public void TypeWritter(string message, int delay, bool newLine = true)
    {
        var player = new SoundPlayer
        {
            SoundLocation = @"C:\Users\Erick\Desktop\C#\CanizHospital\CanizHospital\typewriter-key-1.wav"
        };
        foreach (char c in message)
        {
            player.Play();
            Console.Write(c);
            Thread.Sleep(delay);
            player.Stop();
        }
        if (newLine)
        {
            Console.Write(Environment.NewLine);
            player.SoundLocation = @"C:\Users\Erick\Desktop\C#\CanizHospital\CanizHospital\typewriter-return-1.wav";
            player.PlaySync();
            //Thread.Sleep(delay); // Might not be necessary
        }
    }
