            var result = GroupBy(classRoomAllocationList);
            foreach (var item in result)
            {
                var schedule = String.Join(" + ", item.Value.Select(v => $"\"{v.ScheduleInfo}\""));
                Console.WriteLine($"{item.Key}, CourseName = \"{item.Value.First().CourseName}\", ScheduleInfo = {schedule}");
            }
