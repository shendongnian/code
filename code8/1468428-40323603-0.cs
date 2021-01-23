    class Program
    {
        static void Main(string[] args)
        {
          Program p = new Program();
          var result=  p.GetParentSet(6);
            foreach(var a in result)
            {
                Console.WriteLine(string.Format("{0} {1} {2}",a.ID,a.Name,a.DepartmentId));
            }
           Console.Read();
        }
        private List<Department> GetParentSet(int id)
        {
            List<Department> result = new List<Department>(); //Result set
            using (RamzDBEntities context = new RamzDBEntities())
            {
                var nodeList = context.Departments.Where(t=>t.ID<=id).ToList(); //Get All the the entries where ID is below or greater than the given to the list
                var item = nodeList.Where(a => a.ID == id).SingleOrDefault(); //Get the default item for the given ID
                result.Add(item); //Add it to the list. This will be the leaf of the tree
                int size = nodeList.Count(); //Get the nodes count
                for (int i = size;  i >= 1;i--)
                {
                    var newItem=    nodeList.Where(j => j.ID == item.DepartmentId).SingleOrDefault(); //Get the immediate parent. This can be done by matching the leaf Department ID against the parent ID
                    if (item!=null && !result.Contains(newItem)) //If the selcted immediate parent item is not null and it is not alreday in the list
                    {
                        result.Add(newItem); //Add immediate parent item  to the list
                    }
                    if (newItem.ID == 1) //If the immediate parent item  ID is 1 that means we have reached the root of the tree and no need to iterate any more.
                        break;
                    item = newItem; //If the immediate parent item ID is not 1 that means there are more iterations. Se the immediate parent as the leaf and continue the loop to find its parent
                }
            }
            return result; //return the result set
        }
    }
