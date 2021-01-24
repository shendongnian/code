    public static void FindById(Employees root, int id, out Employees employees, out Employees manager)
    {
        employees = manager = null;
        // todo stack
        var stack = new Stack<Employees>();
        stack.Push(root);
        // all managers seens
        var managers = new List<Employees>();
        while (stack.Count > 0)
        {
            var e = stack.Pop();
            if (e.Id == id) // if found
            {
                employees = e;
                manager = managers.FirstOrDefault(m => m.Id == e.ManagerId);
                return;
            }
            else if (e.employees != null)
            {
                // add only managers with employee
                managers.Add(e);
                foreach (var ep in e.employees)
                {
                    stack.Push(ep);
                }
            }
        }
    }
