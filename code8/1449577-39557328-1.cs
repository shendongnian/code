       public void SaveLevel(string LevelName) 
        {
        string res;
            using (StreamWriter file = new StreamWriter (LevelName+".txt"))
            {
                foreach (GameObject entity in levelStruct.Keys)
                { 
                    foreach(Vector2 v in levelStruct[entity])){
                          res = " "+"("+v.x+"."+v.y+")";
                 }
              file.WriteLine (entity.ToString () + ": " + res);
                           
                }
            }
        }
