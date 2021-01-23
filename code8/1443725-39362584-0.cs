    using (var db = new TimeTable.EntityFramework.TimeTableEntities())
            {
                List<int> list = new List<int>() { 2, 1, 4, 3 };
                var a = db.place_users_info.ToArray();
                var b = list.Select(x=>a[x]).ToList();
            }
