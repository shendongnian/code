        public class GetInstanceProp : MarkupExtension
        {
            public GetInstanceProp(String propname, Object source)
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
                    On={local:GetInstanceProp OnCommand, {x:Static local:App.Current}}, 
                    Off={local:GetInstanceProp OffCommand, {x:Static local:App.Current}}
                ConverterParameter={x:Static myEnum:enumValue}}"
            />
    You need to understand what you're doing here: Markup extensions are evaluated once and only once, around when the XAML is parsed. It's a *markup* extension. `GetProp` will give you the value the property had *then*. That's OK if it's a command property with no setter, that's initialized in the constructor or the first time anybody calls the getter. That's the case we've got here. But very often, that's not the case. 
