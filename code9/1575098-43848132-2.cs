    int n, i;
    Console.WriteLine("Enter number of players");
    n = int.Parse(Console.ReadLine());
    Player[] p = new Player[n];
    Console.WriteLine("Enter the player names");
    for (i = 0; i < n; i++)
    {
        p[i] = new Player();
        p[i].PlayerName = Console.ReadLine();
    }
    Console.WriteLine("Player list:");
    var pl = from t in p select t.PlayerName;
    foreach (var name in pl) Console.WriteLine(name);
