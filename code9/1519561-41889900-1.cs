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
            if (lastClosed > -1)
                if (lastClosed == objectList.Count - 1)
                    return new List<SomeObject>() { objectList[lastClosed] };
                else 
                    return objectList.Skip(lastClosed + 1).ToList();
            else
                return objectList;
        }
