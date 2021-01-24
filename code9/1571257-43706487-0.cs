           public void LoadFileFromBinary(string fileName)
            {
                using (Stream stream = File.Open(filePath, FileMode.Open))
                {
                    MatchInfo matchInfo = BinarySerialization.ReadFromBinaryFile<MatchInfo>(stream);
                    int count = 1;
                    List<PlayerInfo> listOfPlayers = BinarySerialization.ReadFromBinaryFile<List<PlayerInfo>>(stream,count);
                    List<RoundEndEvent> listOfRoundEndEvents = BinarySerialization.ReadFromBinaryFile<List<RoundEndEvent>>(stream, count);
                    List<BombPlantEvent> listOfBombPlants = BinarySerialization.ReadFromBinaryFile<List<BombPlantEvent>>(stream, count);
                    List<BombDefuseEvent> listOfBombDefuses = BinarySerialization.ReadFromBinaryFile<List<BombDefuseEvent>>(stream, count);
                    List<BombExplodeEvent> listOfBombExplosions = BinarySerialization.ReadFromBinaryFile<List<BombExplodeEvent>>(stream, count);
                    List<SmokeEvent> listOfSmokes = BinarySerialization.ReadFromBinaryFile<List<SmokeEvent>>(stream, count);
                    List<MolotovEvent> listOfMolotovs = BinarySerialization.ReadFromBinaryFile<List<MolotovEvent>>(stream, count);
                    List<FlashEvent> listOfFlashes = BinarySerialization.ReadFromBinaryFile<List<FlashEvent>>(stream, count);
                    List<GrenadeEvent> listOfGrenades = BinarySerialization.ReadFromBinaryFile<List<GrenadeEvent>>(stream, count);
                    List<KillEvent> listOfKills = BinarySerialization.ReadFromBinaryFile<List<KillEvent>>(stream, count);
                }
            }
            public static List<T> ReadFromBinaryFile<T>(Stream stream, int count)
            {
                List<T> data = new List<T>();
                var binaryFormatter = new BinaryFormatter();
                for (int i = 0; i < count; i++)
                {
                    data.Add((T)binaryFormatter.Deserialize(stream));
                }
                return data;
            }
