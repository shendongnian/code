    <DataGrid DataContext="{Binding Path=DataContext, ElementName=expander}" ItemsSource="{Binding Items}" 
                                  CanUserAddRows="True" AutoGenerateColumns="False">
        <DataGrid.Resources>
            <Style x:Key="PlusColumnStyle" TargetType="ComboBox">
                <Setter Property="ItemsSource">
                    <Setter.Value>
                        <MultiBinding Converter="{StaticResource Converter}">
                            <!--<Binding Path="Test.Types" Source="{x:Static viewmodels:ApplicationVM.Instance}" />-->
                            <Binding Path="Header" RelativeSource="{RelativeSource AncestorType=Expander}" />
                        </MultiBinding>
                    </Setter.Value>
                </Setter>
            </Style>
        </DataGrid.Resources>
        <DataGrid.Columns>
            <DataGridComboBoxColumn Header="+" DisplayMemberPath="ID" SelectedValuePath="Number" 
                                                        SelectedValueBinding="{Binding Path=End,Mode=TwoWay}"
                                                        ElementStyle="{StaticResource PlusColumnStyle}" EditingElementStyle="{StaticResource PlusColumnStyle}"/>
            <!-- + the other columns...-->
        </DataGrid.Columns>
    </DataGrid>
