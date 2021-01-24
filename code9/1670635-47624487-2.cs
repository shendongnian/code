    static void Main(string[] args)
    {
        var player = new Player();
        //  Whatever
        player.Name = "Bob";
        player.Gender = "Male";
        //  print stats for Bob
        player.PrintStats();
        var otherPlayer = new Player();
        otherPlayer.Name = "Fred";
        //  print stats for Fred
        otherPlayer.PrintStats();
