     public static SelectList ToSelectList<TEnum>(this TEnum enumObj,
                                                          Func<TEnum, string> getText = null,
                                                          Func<TEnum, object> getValue = null,
                                                          Func<TEnum, bool> ignore = null)
        {
            var query = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
            if (ignore != null)
                query = query.Where(e => !ignore(e));
            var values = query.Select(e =>
            {   
                object value = getValue != null ? getValue(e) : e;
                string name = null;
                if (getText != null)
                    name = getText(e);
                
                name = name ?? EnumExtension.GetDisplayName((Enum)(object) e) ?? e.ToString();
                return new { @Name = name, @Value = value };
            });
            return new SelectList(values, "Value", "Name", enumObj);
        }
