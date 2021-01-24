    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var server = new WorldServer();
    
                server.Test();
            }
        }
        
        public class JsonData
        {
            public string header;
            public Dictionary<string, string> data = new Dictionary<string, string>();
            public int connectionId;
        }
        
        
        public class WorldServer
        {
            private Character character = new Character();
        
            public void Test() {
                character.UpdateCharacterState(this);
            }
        
            public void Broadcast(){
                Console.WriteLine("We in Broadcast");
            }
        }
       
        
        
        public class Character 
        {
            public void UpdateCharacterState(WorldServer server)
            {
                Console.WriteLine("State:");
        
                server.Broadcast();
            }
        }
    }
