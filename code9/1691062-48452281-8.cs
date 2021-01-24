    // #using System.ComponentModel.DataAnnotations.dll
    // #using System.Windows.Interactivity.dll
    public class AutoColumnFormatBehavior : Behavior<DataGrid>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.AutoGeneratingColumn += OnAutoGeneratingColumn;
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.AutoGeneratingColumn -= OnAutoGeneratingColumn;
        }
        private void OnAutoGeneratingColumn(
            object sender,
            DataGridAutoGeneratingColumnEventArgs e)
        {
            var binding = (e.Column as DataGridBoundColumn)?.Binding;
            if (binding != null && binding.StringFormat == null)
                binding.StringFormat = GetFormat(e.PropertyType, e.PropertyDescriptor);
        }
        private static string GetFormat(Type type, object descriptor)
        {
            var attribute = default(DataTypeAttribute);
            if (descriptor is MemberInfo mi)
                attribute = mi.GetCustomAttribute<DataTypeAttribute>();
            else if (descriptor is MemberDescriptor md)
                attribute = md.Attributes[typeof(DataTypeAttribute)] as DataTypeAttribute;
            var typeCode = GetTypeCode(type);
            var isNumericType = typeCode >= TypeCode.SByte && typeCode <= TypeCode.Decimal;
            var isIntegerType = isNumericType && typeCode < TypeCode.Single;
            if (attribute?.DataType == DataType.Currency)
                return isIntegerType ? "C0" : "C";
            var formatFromAttribute = attribute?.DisplayFormat?.DataFormatString;
            if (formatFromAttribute != null)
                return formatFromAttribute;
            if (isNumericType)
                return isIntegerType ? "N0" : "N";
            return null;
        }
        private static TypeCode GetTypeCode(Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                type = type.GetGenericArguments()[0];
            if (type.IsEnum)
                return TypeCode.Object;
            return Type.GetTypeCode(type);
        }
    }
