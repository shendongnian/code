    public class YourSelector : DataTemplateSelector
    {
        public DataTemplate Enum1 { get; set; }
        public DataTemplate Enum2 { get; set; }
        //...
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            MyEnumsForDropDown value = (MyEnumsForDropDown)item;
            switch(value)
            {
                case MyEnumsForDropDown.Enum1:
                    return Enum1;
                case MyEnumsForDropDown.Enum2:
                    return Enum2;
            }
            return base.SelectTemplate(item, container);
        }
    }
----------
    <Grid>
        <Grid.Resources>
            <DataTemplate x:Key="Enum1">
                <Grid />
            </DataTemplate>
            <DataTemplate x:Key="Enum2">
                <Grid />
            </DataTemplate>
            <local:YourSelector x:Key="selector" Enum1="{StaticResource Enum1}" Enum2="{StaticResource Enum2}" />
        </Grid.Resources>
        <ContentControl Content="{Binding MyObject.MyChosenEnum}"
                        ContentTemplateSelector="{StaticResource selector}" />
    </Grid>
