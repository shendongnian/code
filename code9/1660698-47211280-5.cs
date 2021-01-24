    private void serializeList()
    {
        XmlSerializer ser = new XmlSerializer(typeof(List<Event>));
        List<Event> list = new List<Event>();
        list.Add(new Event { EventId = 1, Description = "abc", EventType = EventType.Good, Cost = new Resources { Food = 0, Energy = 1, Happiness = 2, ShipHp = 3, Garbage = 4 }, Reward = new Resources { Food = 0, Energy = 1, Happiness = 2, ShipHp = 3, Garbage = 4 } });
        list.Add(new Event { EventId = 2, Description = "def", EventType = EventType.Good, Cost = new Resources { Food = 0, Energy = 1, Happiness = 2, ShipHp = 3, Garbage = 4 }, Reward = new Resources { Food = 0, Energy = 1, Happiness = 2, ShipHp = 3, Garbage = 4 } });
        list.Add(new Event { EventId = 3, Description = "ghi", EventType = EventType.Good, Cost = new Resources { Food = 0, Energy = 1, Happiness = 2, ShipHp = 3, Garbage = 4 }, Reward = new Resources { Food = 0, Energy = 1, Happiness = 2, ShipHp = 3, Garbage = 4 } });
        StreamWriter sw = new StreamWriter("Assets/TextResources/test.xml");
        ser.Serialize(sw, list);
        sw.Close();
    }
