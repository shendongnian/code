    <ComboBox Grid.Column="0" Width="150" Height="32" IsSynchronizedWithCurrentItem="True"
                  ItemsSource="{Binding OptimizationTypes}" DisplayMemberPath="TypeName"
                  SelectedIndex="{Binding SomeSelectedItem, UpdateSourceTrigger=PropertyChanged}"
                  Margin="12,11,-162,-43">
            <ComboBox.DataContext>
                <local:MyViewModel />
            </ComboBox.DataContext>
            <ComboBox.ItemContainerStyle>
                <Style TargetType="{x:Type ComboBoxItem}">
                    <Setter Property="IsEnabled" Value="{Binding Path=IsItemEnabled}" />
                </Style>
            </ComboBox.ItemContainerStyle>
        </ComboBox>
