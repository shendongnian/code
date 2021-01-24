    public static Employee FindById(Employee root, int id) 
    {
        if (root.Id == id)
        {
            return root;
        }
        else if (root.Employees != null) 
        {
            foreach (var e in root.Employees) 
            {
                var pe = FindById(e, id);
                if (pe != null)
                {
                    return pe;
                }
            }
        }
        return null;
    }
