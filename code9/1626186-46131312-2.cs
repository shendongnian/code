    public class ValidateString : IValidator<string>
    {
        public void Validate<T>(T entity, object rukeObj = null, object nullChekcObj = null) where T : class
        {
            var item = (string) Convert.ChangeType(entity, typeof(string));
            var rule = (Regex)Convert.ChangeType(rukeObj, typeof(Regex));
            var reqItem = Convert.ChangeType(nullChekcObj, typeof(bool));
            var isRequire = reqItem != null && (bool) reqItem;
            if (isRequire && string.IsNullOrEmpty(item))
                throw new ArgumentException("value can not be null!");
            if (!rule.Match(item).Success)
                throw new ArgumentException("[" + item + "] is not a valid input!");
        }
    }
