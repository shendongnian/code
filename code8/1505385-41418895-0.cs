            object[] data = new object[]{with data inside};   
        
            Hashtable GameData1 = new Hashtable();
            GameData1.Add("data1", data);
            Hashtable GameData2= new Hashtable();
            GameData2.Add("data2", data);
            room.SetCustomProperties(GameData1);
            room.SetCustomProperties(GameData2);
