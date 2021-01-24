    private bool IsTimeBetween(DateTime theTime, DateTime startTime, DateTime endTime)
        {
            if (theTime >= startTime && theTime <= endTime)
                return true;
            else
                return false;
        }
        private void check()
        {
            MyObject myObj = new MyObject
            {
                Id = 1,
                Name = "Test",
                StartDate = new DateTime(2017, 3, 1),
                EndDate = new DateTime(2017, 3, 10)
            };
            List<MyObject> objList = new List<MyObject>();
            foreach (var objInList in objList)
            {
                if (objInList.StartDate >= objInList.EndDate)
                    continue;
                if (IsTimeBetween(objInList.StartDate, myObj.StartDate, myObj.EndDate)
                    || IsTimeBetween(objInList.EndDate, myObj.StartDate, myObj.EndDate))
                {
                    //intersects
                }
                if (objInList.StartDate < myObj.StartDate && objInList.EndDate > myObj.EndDate)
                {
                    //intersects
                }
            }
        }
