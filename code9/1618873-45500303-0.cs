    Dictionary<string,double> plist = new Dictionary<string,int>();
    
    ObjectIdCollection myDictionaryObj = promptforObjColl("\nSelect Objects: ");
    double currentValue;
    foreach (ObjectId pid in mycoll)
    {
        if (pid.GetType() == typeof(Polyline))
        {
            polyline pcl = pid.GetObject(OpenMode.ForRead) as Polyline;
            if(myDictionaryObj.TryGetValue(pcl.StyleName, out currentValue))
            {
                myDictionaryObj[pcl.StyleName]+= currentValue;
            }
            else
            {
                myDictionaryObj.Add(pcl.StyleName,pcl.Area);
            }
        }
    }
