    xmlns:sys="clr-namespace:System;assembly=mscorlib"
 
		<StackPanel>
            <ListView x:Name="ExampleLV" SelectedValue="{Binding ElementName=Cbox, Path=SelectedValue, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}">
                <ListView.ItemsSource>
                    <x:Array Type="{x:Type sys:String}">
                        <sys:String>Test1</sys:String>
                        <sys:String>Test2</sys:String>
                        <sys:String>Test3</sys:String>
                    </x:Array>
                </ListView.ItemsSource>
                <ListView.View>
                    <GridView>
                        <GridViewColumn Header="Column1"/>
                    </GridView>
                </ListView.View>
            </ListView>
            
            <TextBox Text="{Binding ElementName=Cbox, Path=SelectedValue, Mode=TwoWay, UpdateSourceTrigger=LostFocus}"/>
            
            <ComboBox x:Name="Cbox">
                <ComboBox.ItemsSource>
                    <x:Array Type="{x:Type sys:String}">
                        <sys:String>Test1</sys:String>
                        <sys:String>Test2</sys:String>
                        <sys:String>Test3</sys:String>
                    </x:Array>
                </ComboBox.ItemsSource>                
            </ComboBox>
        </StackPanel>
