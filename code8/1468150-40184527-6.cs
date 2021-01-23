    class Program
    {
        static void Main(string[] args)
        {
            List<IAbs> managers=new List<IAbs>();
            var pm=new PlayerManager(new Player() { ID=1001 });
            var gm=new GameRoomManager(new GameRoom() { ID=2050 });
            managers.Add(pm);
            managers.Add(gm);
            IItem part = managers[0].GetItem("0000");
            
        }
    }
