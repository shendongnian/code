      QueryResult = db.Courses.Where(x=>x.Name == "Name").Select(x=> new { A = x.Name, B= x.Description})
                 .Union(db.CourseDesc.Where(y=>y.MainHeading == "Name").Select(y=> new {A = y.MainHeading, B = y.MainDesc })
                 .Union( //so on 
                 //Where can go either before or after .ToList
                 .Where(item=>item.A == "Name")
                 .ToList();
