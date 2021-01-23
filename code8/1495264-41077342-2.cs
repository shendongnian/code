    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace maze_3
    {
        class Program
        {
            static void Main(string[] args)
            {
                Room home = new Room("White House");
                home.CreateRoom("W", "West Wing");
            }
        }
        class Room
        {//open class room
            private string RoomName;
            private Room N = null; // so that when i set the links they are automatically null unless i specify in main 
            private Room E = null;
            private Room S = null;
            private Room W = null;
            private List<Chamber> chambers = new List<Chamber>();
            public Room() { }
            public Room(string name)
            {
                this.RoomName = name;
            }
            public void CreateRoom(string direction, string name)
            {
                Room newRoom = new Room();
                newRoom.RoomName = name;
                switch (direction)
                {
                    case "N":
                        N = newRoom;
                        break;
                    case "E":
                        E = newRoom;
                        break;
                    case "S":
                        S = newRoom;
                        break;
                    case "W":
                        W = newRoom;
                        break;
                }
            }
        }//close class rooom
        public class Chamber// its telling me that a ; is expected ???
        {//open class chamber
            string name = "";
        }//close chamber
    }
