    private int GetEnumValue(string enumTypeName, string enumPickedOptionName)
        {
            int result = -1;
            Type enumType;
            try
            {
                enumType= Type.GetType(enumTypeName);
                result = (int)Enum.Parse(enumType, enumPickedOptionName,true);
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
            return result;
        }
