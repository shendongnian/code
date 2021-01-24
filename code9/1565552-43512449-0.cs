        public static IDictionary<string, List<ClassRoomAllocation>> GroupBy(List<ClassRoomAllocation> classRoomAllocationList)
        {
            var result = new Dictionary<string, List<ClassRoomAllocation>>();
            foreach (var allocation in classRoomAllocationList)
            {
                var group = result.ContainsKey(allocation.CourseCode)
                    ? result[allocation.CourseCode]
                    : new List<ClassRoomAllocation>();
                group.Add(allocation);
                result[allocation.CourseCode] = group;
            }
            
            return result;
        }
