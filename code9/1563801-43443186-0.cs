     Position where;
            BinaryFormatter formatter = new BinaryFormatter();
            
            if (!File.Exists("PlayerPosData.txt"))
            {
                File.Create("PlayerPosData.txt");
                where.x = 50;
                where.y = 20;
            }
            else
            {
                using (var playerPosData = File.OpenRead("PlayerPosData.txt"))
                {
                    where = (Position)formatter.Deserialize(playerPosData);
                }
            }
           
            // ...
            using (var playerPosData = File.OpenWrite("PlayerPosData.txt"))
            {
                formatter.Serialize(playerPosData, where); // it stops here and says "it can't be modified" the second time
            }
            
                Console.ReadKey();
