    <Expander x:Name="MyExpander"
              Grid.Column="1"
              Grid.Row="1"
              VerticalAlignment="Top"
              Header="My Expander"
              Expanded="MyExpander_Expanded"
              Collapsed="MyExpander_Collapsed">
      <StackPanel>
        <DataGrid Margin="5"
                  xmlns:s="clr-namespace:System;assembly=mscorlib">
          <!-- Temporary items source to demonstrate grid measuring to fit rows -->
          <DataGrid.ItemsSource>
            <x:Array Type="s:String">
              <s:String>Dummy Row 1</s:String>
              <s:String>Dummy Row 2</s:String>
              <s:String>Dummy Row 3</s:String>
            </x:Array>
          </DataGrid.ItemsSource>
          <DataGrid.Columns>
            <DataGridTextColumn Header="MyFirstColumn" />
            <DataGridTextColumn Header="MySecondColumn" />
            <DataGridTextColumn Header="MyThirdColumn" />
            <DataGridTextColumn Header="MyFourthColumn" />
            <DataGridTextColumn Header="MyFifthColumn" />
            <DataGridTextColumn Header="MySixthColumn" />
            <DataGridTextColumn Header="MySeventhColumn" />
            <DataGridTextColumn Header="MyEighthColumn" />
            <DataGridTextColumn Header="MyNinthColumn" />
            <DataGridTextColumn Header="MyTenthColumn" />
          </DataGrid.Columns>
        </DataGrid>
        <Button x:Name="DoSomething"
                Margin="5"
                Width="100"
                Height="30"
                Content="Do Something"
                Click="DoSomething_Click" />
      </StackPanel>
    </Expander>
