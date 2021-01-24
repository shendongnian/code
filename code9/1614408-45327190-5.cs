       class  Student
        {
            public string Name { get; set; }
        }
    
        class Course
        {
            public string Title { get; set; } 
        }
             var std = new Student() {Name = "foo"};
            var lstCours = new List<Course>() { new Course(){Title = "math"}};
            var stdJson = JsonConvert.SerializeObject(new {student=std});
            var lstCoursJson = JsonConvert.SerializeObject( new{Cours= lstCours});  
            JObject jObjectStd = JObject.Parse(stdJson);
            JObject jObjectLstCours = JObject.Parse(lstCoursJson);
            jObjectStd.Merge(jObjectLstCours,new JsonMergeSettings(){MergeArrayHandling = MergeArrayHandling.Concat}); 
            Console.WriteLine(jObjectStd.ToString());
