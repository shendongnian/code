    public class Student
    {
        private int _age = 1;
    
        public Student(int initAge)
        {
            SetAge(initAge);
        }
    
        public void SetAge(int age)
        {
            if (age <= 0)
            {
                Console.WriteLine("Your age cannot be less then 1 year.");
                Console.ReadLine();
                Environment.Exit(0);
            }
            else
            {
                _age = age;
            }
        }
    
        public int GetAge()
        {
            return _age;
        }
    }
