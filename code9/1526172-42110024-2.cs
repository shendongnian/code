    for(int i = 0; i < myList.Count; i++)
    {
        if(myList[i].Id == Id) 
        {
            myList[i] = newElement;
            break;
        }
    }
