    @model List<KeyValuePair<string, object>>
    
    <div>
        @foreach (KeyValuePair<string, object> item in Model)
        {
            Type type = item.Value.GetType();
    
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Boolean:
                    {
                        <input type="checkbox"/>
                        break;
                    }
                case TypeCode.String:
                    {
                        <input type="text"/>
                        break;
                    }
                default:
                {
                    if (type == typeof (MyCustomType))
                    {
                        ...
                    }
                    else if (type == typeof (MyOtherType))
                    {
                        ...
                    }
                }
            }
        }
    </div>
