        public class UserRecord
        {
            public UserRecord(DateTime fromDate)
            {
                FromDate = fromDate;
                AfterUpdate(true);
            }
            public UserRecord AfterUpdate(bool initialRecord)
            {
                IsInitialRecord = initialRecord;
                return this;
            }
            public DateTime FromDate { get; private set; }
            public bool IsInitialRecord { get; private set; }
        }
        public static void Main(string[] args)
        {
            var userRecords =
                new[]
                {
                    new UserRecord(new DateTime(1900, 1, 1)),
                    new UserRecord(new DateTime(1801, 1, 1)),
                    new UserRecord(new DateTime(1913, 1, 1)),
                    new UserRecord(new DateTime(1850, 1, 1))
                };
            var updatedRecords =
                (
                    from minDate in new[] { userRecords.Min(r => r.FromDate) }
                    from record in userRecords
                    where record.FromDate > minDate
                    select record.AfterUpdate(false)
                );
            foreach (var record in updatedRecords)
            {
                Console.WriteLine("{0} ({1})", record.FromDate, record.IsInitialRecord);
            }
            // Etc...
        }
