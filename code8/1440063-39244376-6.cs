     <CheckBox Grid.Column="2" IsChecked="{Binding ExpanderEnable, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}">Enalble Expander</CheckBox>
     <Expander Grid.Column="3"
               IsEnabled="{Binding ExpanderEnable, Mode=OneWay, UpdateSourceTrigger=PropertyChanged}">
         <TextBlock>kdshfkjlsdhf</TextBlock>
     </Expander>
