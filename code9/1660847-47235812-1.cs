    internal class DF : IEditorDataFilter
    {
        public object Convert(EditorDataFilterConvertArgs conversionArgs)
        {
            switch(conversionArgs.Direction)
            {
                case ConversionDirection.DisplayToEditor:
                    break;
                case ConversionDirection.EditorToDisplay:
                    var valueAsString = conversionArgs.Value.ToString();
                    var year = int.Parse(valueAsString.Substring(0, 4));
                    var month = int.Parse(valueAsString.Substring(4, 2));
                    var day = int.Parse(valueAsString.Substring(6, 2));
                    var hours = int.Parse(valueAsString.Substring(8, 2));
                    var minutes = int.Parse(valueAsString.Substring(10, 2));
                    var result = new DateTime(year, month, day, hours, minutes, 0).ToString("yyyy-MM-dd HH:mm:ss");
    
                    conversionArgs.Handled = true;
                    conversionArgs.IsValid = true;
                    return result;
                case ConversionDirection.OwnerToEditor:
                    break;
                case ConversionDirection.EditorToOwner:
                    break;
                default:
                    break;
            }
    
            return conversionArgs.Value;
        }
    }
