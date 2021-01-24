        public class GetProp : MarkupExtension
        {
            public GetProp(String propname, Object source)
            {
                _source = source;
                _propName = propname;
            }
            private Object _source;
            private String _propName;
            public override object ProvideValue(IServiceProvider serviceProvider)
            {
                var propInfo = _source.GetType().GetProperty(_propName);
                return propInfo.GetValue(_source);
            }
        }
    XAML
        <Button 
            Command="{Binding
                PropertySource.SomeEnumProperty,
                Source={x:Static Application.Current},
                Converter={myConverters:EnumConverter
                    On={local:GetProp OnCommand, {x:Static local:App.Current}}, 
                    Off={local:GetProp OffCommand, {x:Static local:App.Current}}
                ConverterParameter={x:Static myEnum:enumValue}}"
            />
