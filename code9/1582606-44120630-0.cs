    class Category
    {
        public List<Expense> expenses = new List<Expense>();
        public static int categoryNum = 0;
        public string name;
        public Category(int num1, string name1)
        {
            categoryNum = num1;
            name = name1;
        }
    
        public void createNewExpense(int expense2, string name2)
        {
            expenses.Add(new Expense(expenses.Count, expense2, name2));
        }
    
        public void deleteExpense(int num)
        {
            if (num > expenses.Count || num < 1)
            {
                MessageBox.Show("Invalid Entry for deletion, make sure the number is not bigger than the biggest person or smaller than 1");
            }
            else
            {
                expenses.RemoveAt(num - 1);
            }
        }
        public void test()
        {
            MessageBox.Show("The Problem is in category or expense classes");
        }
    }
