    var weekendWarriors = new Queue<string>();
    CheckRefreshQueue<string>(weekendWarriors, employees);
    for (int i = 0; i < dates.Length; i++)
    {
        DateTime newDate = new DateTime();
        newDate = dates[i];
        
        if (newDate.DayOfWeek == DayOfWeek.Saturday || newDate.DayOfWeek == DayOfWeek.Sunday)
        {   
            string emp1;
            string emp2;
            CheckRefreshQueue<string>(weekendWarriors, employees);
            emp1 = weekendWarriors.Dequeue();
            CheckRefreshQueue<string>(weekendWarriors, employees);
            emp2 = weekendWarriors.Dequeue();
        }
    }
