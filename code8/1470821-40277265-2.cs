     public bool Comparer<T>(T object1, T object2)
        {
            if (object1 is Student && object2 is Student)
            {
                var student1 = (Student)(object)object1;
                var student2 = (Student)(object)object2;
                return student1.Mark == student2.Mark;
            }
            else if (object1 is Teacher && object2 is Teacher)
            {
                var teacher1 = (Teacher)(object) object1;
                var teacher2 = (Teacher)(object) object2;
                return teacher1.Salary == teacher2.Salary;
            }
            else 
           {
              //... Put your other logic here
           }
            return false;
        }
