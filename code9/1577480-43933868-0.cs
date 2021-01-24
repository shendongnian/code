    public class MySampleClass
    {
        public string Name;
        public object Value;
    }
    public class MyTemplateSelector : DataTemplateSelector
    {
        public DataTemplate BooleanTemplate
        {
            get;
            set;
        }
        public DataTemplate DoubleTemplate
        {
            get;
            set;
        }
        public DataTemplate StringTemplate
        {
            get;
            set;
        }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            MySampleClass temp = item as MySampleClass;
            if(temp.Value is bool)
            {
                return BooleanTemplate;
            }
            else if(temp.Value is double)
            {
                return DoubleTemplate;
            }
            else if(temp.Value is string)
            {
                return StringTemplate;
            }
            else
            {
                return base.SelectTemplate(item, container);
            }
            
            // And so on
        }
    }
    <ResourceDictionary>
        <DataTemplate x:Key="StringTemplate">
            <Grid>
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="100"/>
                    <ColumnDefinition Width="200"/>
                </Grid.ColumnDefinitions>
                <TextBlock Text="{Binding Name}" Margin="2" Grid.Column="0"/>
                <TextBox Text="{Binding Value, Mode=TwoWay}" Margin="2" Grid.Column="1" IsEnabled="{Binding IsLocked}"/>
            </Grid>
        </DataTemplate>
        <DataTemplate x:Key="BooleanTemplate">
            <Grid>
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="100"/>
                    <ColumnDefinition Width="200"/>
                </Grid.ColumnDefinitions>
                <TextBlock Text="{Binding Name}" Margin="2" Grid.Column="0"/>
                <ToggleButton IsChecked="{Binding Value, Mode=TwoWay}" Margin="2" Grid.Column="1" IsEnabled="{Binding IsLocked}"/>
            </Grid>
        </DataTemplate>
        <selector:MyTemplateSelector BooleanTemplate="{StaticResource BooleanTemplate}"
                                     StringTemplate="{StaticResource StringTemplate}"
                                     />
    </ResourceDictionary>
