    public class InventoryAttempt
    {
        public static void BalanceChange(string filePath, int ID, int change)
        {
            //Load Data
            string jsonString = File.ReadAllText(Application.dataPath + filePath);
    
            Item[] item = JsonHelper.FromJson<Item>(jsonString);
    
            //Loop through the Json Data Array
            for (int i = 0; i < item.Length; i++)
            {
                //Check if Id matches
                if (item[i].Id == ID)
                {
                    Debug.Log("Found!");
                    //Increment Change value?
                    item[i].Balance += change;
                    break; //Exit loop
                }
            }
    
            //Convert to Json
            string newJsonString = JsonHelper.ToJson(item);
    
            //Save
            File.WriteAllText(Application.dataPath + filePath, newJsonString);
        }
    }
