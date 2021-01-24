    using System;
    using System.Collections.Generic;
    
    class StudentUI {
      int myHours;
    
      private string[] days = { "Sunday", "Monday", "Tuesday", "Wednesday", 
         "Thursday", "Friday", "Saturday" };
    
      public StudentUI() { }
      
      public static void Main (string[] args) {
        Student my = new Student();
        Console.WriteLine("Please enter your name:\t ");
        my.Name = Console.ReadLine();
    
        Console.WriteLine("Please enter your student ID number:\t ");
        my.ID = int.Parse(Console.ReadLine());
      
        var StudentUI = new StudentUI();
        StudentUI.FillHours(my);
        // DisplayData(my);
        // DisplayAverage(my);
      }
      
      
        public void FillHours(Student my) {
    
          for (int i = 0; i < this.days.Length; i++) {
    
              Console.Write("Enter the number of hours that you studied ITDEV-115 on {0}:\t ", this.days[i]);
              myHours = int.Parse(Console.ReadLine());
              my.EnterHours(i, myHours);
          }
        }
        
        
    }
    
    public class Student {
        public int ID;
        public string Name;
        private List<int> Hours = new List<int>();
      
        public void EnterHours(int index, int myHours) {
          Hours.Add(myHours);
        }
    }
