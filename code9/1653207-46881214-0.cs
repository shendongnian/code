    public class ViewItem
        {
            private int No { get; set; }
            private string Name { get; set; }
    
            public ViewItem(int no, string name)
            {
                this.No = no;
                this.Name = name;
            }
            
           public override bool Equals(Object obj)
            {
                // Check for null values and compare run-time types.
                if (obj == null || GetType() != obj.GetType())
                    return false;
    
                ViewItem other = (ViewItem) obj;
                return (No == other.No);
            }
            
        }
