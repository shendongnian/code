    mockStudentRepository
        .Setup(m => m.Update(It.IsAny<IStudent>()))
        .Callback<IStudent>(s => {
            var student = students.Where(x => x.Id == s.Id).FirstOrDefault();
            if(student != null) {
                    //...
            }
        }); 
