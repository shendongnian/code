    class StudentUI{
     int myHours;
     private string[] days = { "Sunday", "Monday", "Tuesday", "Wednesday", 
     "Thursday", "Friday", "Saturday" };
     public StudentUI()
     { }
     public void MainMethod(){
       Student my = new Student(days.length);
       Console.WriteLine("Please enter your name:\t ");
       my.Name = Console.ReadLine();
       Console.WriteLine("Please enter your student ID number:\t ");
       my.ID = int.Parse(Console.ReadLine());
        FillHours(my);
        this.DisplayData(my);
        this.DisplayAverage(my);
    }
    public void FillHours(Student my){
        for (int i = 0; i < this.days.Length; i++){
            Console.Write("Enter the number of hours that you studied ITDEV-115 on {0}:\t ", this.days[i]);
            myHours = int.Parse(Console.ReadLine());
            my.EnterHours(i, myHours);
        }
    }
    
    class Student{
    private int id;
    private string name;
    private double[] hours;
    public student(int size)
    {
    hours = new double[size];
    }
    public void EnterHours(int index, int myHours)
        {
            hours[index] = myHours;
    }
