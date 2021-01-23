    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    
    namespace SO.RajGan
    {
        class SomeData
        {
            public int StatusId { get; set; }
            public string LastUpdateUser { get; set; }
    
            public override string ToString()
            {
                return $"Last update user: {LastUpdateUser}; Status ID = {StatusId}";
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var dataList = new List<SomeData>();
    
                for(int i = 0; i < 100000; i++)
                {
                    dataList.Add(new SomeData() { StatusId = new Random(i).Next(1, 10), LastUpdateUser = $"User {i + 1}" });
                }
    
                Parallel.ForEach(dataList, item => 
                {
                    item.LastUpdateUser = "Batch";
                    item.StatusId = 2;
                });
    
                Debug.Assert(dataList != null);
            }
        }
    }
