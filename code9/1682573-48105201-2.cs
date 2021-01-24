    public List<string> GetErrorMessagesByReflection() {
        bool IsList(Type aType) => aType.IsGenericType && aType.GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>));
        var errorMessages = new List<string>();
        var props = this.GetType().GetProperties()
                        .Where(p => IsList(p.PropertyType));
        foreach (var prop in props) {
            var aList = prop.GetValue(this) as IEnumerable;
            foreach (var anItem in aList) {
                var possibleErrorMessage = anItem.GetType().GetProperty("ErrorMessage").GetValue(anItem) as string;
                if (!String.IsNullOrEmpty(possibleErrorMessage))
                    errorMessages.Add(possibleErrorMessage);
            }
        }
        return errorMessages;
    }
