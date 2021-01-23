            string path = "Customer\\Calls\\A1\\A2\\A3\\A4";
            var pathArr = path.Split(new string[] { "\\" }, StringSplitOptions.None);
            var pathList = new List<string>();
            while (pathArr.Length != pathList.Count)
            {
                string modifiedPath = "";
                for (int i = 0; i < pathArr.Length; i++)
                {
                    modifiedPath = modifiedPath + pathArr[i] + "\\";
                    if (i == pathList.Count)
                    {
                        pathList.Add(modifiedPath);
                        break;
                    }
                }
            }
            foreach (var str in pathList)
            {
                Console.WriteLine(str.Remove(str.Length - 1));
            }
            Console.ReadKey();
        
