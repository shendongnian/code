    var students = new [] 
    {
        new student { scode=1,name = "mahta", lastname = "sahabi", phone = 3244 },
        new student { scode=2, name = "niki", lastname = "fard", phone = 5411 },
        ... etc
    }.ToDictionary(s => s.scode);
    
    var courses = new [] 
    {
        new course { code = 1, name = "Mathemathics", unit = 3 },
        ....
    }.ToDictionary(c => c.code);
    
    var grades = new [] 
    {
        new grade { term = 1, value = 53, student = students[1], course = courses[2] },
        new grade { term = 2, value = 99, student = students[1], course = courses[1] },
    ...
    }
