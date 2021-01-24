    public class Car
    { 
        public int Insurance { get; set; }
        public int Gas { get; set; }
    }
    
    public class Budget
    { 
        public Car Car { get; set; }
        public Budget()
        {
            Car = new Car();
        } 
    }
    public class BudgetManager
    { 
        public static Budget CreateBudget(int insurance)
        { 
            Budget budget = new Budget();
            budget.Car.Insurance = insurance;
            return budget;
        } 
    }
