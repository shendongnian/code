    List<string> buffer = new List<string>();
            for (int i = 0; i < class02.myList.Count; i++)
            {
                wits2 = class02.myList[i].Substring(0, 4);
                //Console.WriteLine(class02.myList[i]); //Remove this
                Console.WriteLine(wits2);  //Use wits2 instead since this is what you get on your Substring
            }
