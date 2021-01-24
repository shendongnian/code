    public class RequiredListAttribute : ValidationAttribute
    {
        public override bool IsValid(object list)
        {
            var list = list as IList;
            if (list != null)
            {
                return list.Count > 0;
            }
            return false;
        }
    }
