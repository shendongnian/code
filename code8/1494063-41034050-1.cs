    class Room 
    {
       public string Name;
       public Room NorthRoom;
       public Room SouthRoom;
       public Room EastRoom;
       public Room WestRoom;
       pulic bool isExit;
       public ConnectToRoom(Room room, Direction direction)
       {
           // Add room connection logic here...
       }
    }
    class Maze
    {
       public Room StartingRoom;
    }
