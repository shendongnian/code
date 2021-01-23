    public class MeComparer : IComparer<string> {
        public int Compare(string stringA, string stringB) {
            // your compare logic goes here...
            // eg. return int.Parse(stringA) - int.Parse(stringB)
        }
    }
    
    // and use it like 
    return JsonConvert.SerializeObject(new Entities()
        .Student_Master
        .Where(k => k.Student_Location == Location && k.Student_Course == Program)
       .OrderBy(i => i.Student_Batch, new MeComparer()) // <-- HERE
       .Select(i => i.Student_Batch)
       .Distinct()
       .ToList());
