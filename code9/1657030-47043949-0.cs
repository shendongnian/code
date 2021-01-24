            date = assignment.Start.Date;
            do
            {
                
                foreach (CommitInfo dates in commits)
                {
                    if (dates.TimeStamp.Date == date.Date)
                    {
                        Sorted[date.Date] += 1;
                    }
                }
                date = date.AddDays(1).Date;
            } while (date.Date < assignment.End.Date);
