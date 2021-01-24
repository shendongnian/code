    public static bool IsValid(SpecialCaseRequest specialCase, out HttpResponseMessage response)
    {
        object[] mParam = new object[] { signingCase, new Error() };
            foreach (Type type in _validationTypes)
            {
                var obj = Activator.CreateInstance(type);
                var isValidMethod = type.GetMethod("IsValid");
                var isValid = (bool) isValidMethod.Invoke(obj, mParam);
            }
        if (result != null)
        {
            return false;
        }
        return true;
    }
