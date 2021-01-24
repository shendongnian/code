        private List<SomeObject> FilterObjects(List<SomeObject> objectList)
        {
            int lastClosed = -1;
            for (int i = 0; i < objectList.Count; i++)
            {
                if (objectList[i].Status == "Closed")
                    lastClosed = i;
                else if (objectList[i].Status == "Finished")
                    return new List<SomeObject>() { objectList[i] };
            }
            if (objectList.Last().Status == "Closed")
                return new List<SomeObject>() { objectList.Last() };
            else if (lastClosed > -1)
                return objectList.Skip(lastClosed + 1).ToList();
            else
                return objectList;
        }
