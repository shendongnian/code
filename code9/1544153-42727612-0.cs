    Person you = person.First(x => x.FullName == name);
    if (you == null)
    {
        person.Add(new Person(name, food));
    }
    else
    {
        you.MyExpense.Add(new Expense(food));
    }
