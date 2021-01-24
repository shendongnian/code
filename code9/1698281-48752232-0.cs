    bool listConstainsSpecificObjCount(List<GameObject> targetObjList, GameObject targetObj, int appearedCount)
    {
        bool containsSpecificObjCount = false;
    
        //1 Dictionary to hold the object found in each loop
        Dictionary<GameObject, int> tempDic = new Dictionary<GameObject, int>();
    
        //2 Loop over the targetObjList
        for (int i = 0; i < targetObjList.Count; i++)
        {
            //Current Object in the Loop
            GameObject currentDicObj = targetObjList[i];
    
            int dicResult = 0;
    
            //3 Check if the Object from the current loop exist in the dictionary
            if (tempDic.TryGetValue(currentDicObj, out dicResult))
            {
                //It exists, increment the count by 1
                dicResult++;
    
                //Update data/value in the existing Dictionary
                tempDic[currentDicObj] = dicResult;
            }
            else
            {
                //Use 1 for the value because we are about to add it to the Dictionary
                dicResult = 1;
    
                //Add current Object to the Dictionary for the first time
                tempDic.Add(currentDicObj, dicResult);
            }
    
            //4 Check if we have reached that x amount in the dictionray then break out of the loop
            if (dicResult >= appearedCount)
            {
                containsSpecificObjCount = true;
                break;
            }
        }
        return containsSpecificObjCount;
    }
