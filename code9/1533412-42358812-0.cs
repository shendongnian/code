    public class Countries_List_ResultModel
    {
        public override bool Equals(object obj)
        {
            var item = obj as Countries_List_ResultModel;
            if (item == null)
            {
                return false;
            }
            return true; // Add the appropriate logic.
        }
        public override int GetHashCode()
        {
            // Return the hashcode to quickly identify different instances.
            return this.currency.GetHashCode();
        }
    }
