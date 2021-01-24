    public class ParentChildBll
    {
        public decimal UpdateTotal(int parentId, decimal oldUnitPrice, decimal newUnitPrice)
        {
            var parent = GetParent(parentId);
            parent.TotalPrice += newUnitPrice - oldUnitPrice;
            UpdateParent(parent);
        }
        public void AddChild(Child child)
        {
            var oldUnitPrice = 0m;
            var newUnitPrice = child.UnitePrice;
            using (var repository = new ChildRepository())
            {
                repository.AddChild(child);
                repository.Save();
            }
            UpdateTotal(child.ParentId, oldUnitPrice, newUnitPrice);
        }
    }
