    <ComboBox  
        Name="SelectionBarGroupsComboBox">
        <ComboBox.Resources>
            <CompositeCollection x:Key="CompositeCollection">
                <CollectionContainer Collection="{Binding Source={x:Reference SearchPanel}, Path=DataContext.Groups}" />
            </CompositeCollection>
                
            <DataTemplate 
                xmlns:models="clr-namespace:StMaryChurchAttendance.Models"
                DataType="models:Group">
                <TextBlock Text="{Binding Name}" />
            </DataTemplate>
        </ComboBox.Resources>
        <ComboBox.ItemsSource>
            <CompositeCollection>
                <ComboBoxItem Name="AllGroupItem" IsSelected="True">All Groups</ComboBoxItem>
                <CollectionContainer  Collection="{Binding Source={StaticResource CompositeCollection}}" />
            </CompositeCollection>
        </ComboBox.ItemsSource>
    </ComboBox>
