    public class ProductCollection
    {
      ...
        public void CreateNewGroupByLetter(ObservableCollection<ProductGroup> oldGroupByLetter)
        {
            if (oldGroupByLetter != null&&this.GroupByLetter!=null)//add this.GroupByLetter!=null to call the setter of GroupByLetter.
            {
                foreach (var group in oldGroupByLetter)
                {
                    foreach (var product in group)
                    {
                        Add(new Product {
                             Name=product.Name
                        });
                    }
                }
            }
        }
    }
