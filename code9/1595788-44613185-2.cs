    cbCurrency.ItemsSource = dict.Values;
=>
    <ComboBox x:Name="cbCurrency">
       <ComboBox.ItemTemplate>
         <DataTemplate>
           <StackPanel Orientation="Vertical">
             <TextBlock Text="{Binding Name, Mode=OneWay}" />
             <TextBlock Text="{Binding Symbol_Native, Mode=OneWay}" />
             <TextBlock Text="{Binding Decimal_Digits, Mode=OneWay}" />
             <TextBlock Text="{Binding Code, Mode=OneWay}" />
           </StackPanel>
         </DataTemplate>
       </ComboBox.ItemTemplate>
    </ComboBox>
