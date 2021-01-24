     static double ComputeAvgTime()
            {
                //For all items wich are not expired yet.
                var contractExpTime = new List<DateTime>();
                var timeStamp = DateTime.Now;
                //Sample Data
                contractExpTime.Add(timeStamp.AddMilliseconds(2000));
                contractExpTime.Add(timeStamp.AddMilliseconds(3000));
                contractExpTime.Add(timeStamp.AddMilliseconds(5000));
                //
                var total = contractExpTime.Where(item => item > timeStamp).Aggregate<DateTime, double>(0, (current, item) => item.Subtract(timeStamp).TotalMilliseconds + current);
                var avg = total / contractExpTime.Count(item => item > timeStamp);
                return avg;
            }
