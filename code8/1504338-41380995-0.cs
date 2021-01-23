    var jsonStr = "[[\"Test item 2\",2,1337,1,2,\"Użyj test2\"],[\"Test item 1\",2,1337,1,1,\"Użyj test1\"]]";
                dynamic parsedObjectList = JsonConvert.DeserializeObject(jsonStr);
                parsedObjectList = (IEnumerable)parsedObjectList;
                List<items> itemsList = new List<items>();
                foreach (var itemList in parsedObjectList)
                {
                    var item = new items();
                    item.name = itemList[0];
                    item.weight = itemList[1];
                    item.model = itemList[2];
                    item.scala = itemList[3];
                    item.id = itemList[4];
                    item.rightClick = itemList[5];
                    itemsList.Add(item);
                }
