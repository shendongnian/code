       static string GetSimpleType(object obj)
        {
            var stringRepresentation = GetTypeString(obj);
            switch (stringRepresentation)
            {
                case "System.Int64":
                case "System.Int32":
                    return "int";
                default:
                    return stringRepresentation;
            }
        }
