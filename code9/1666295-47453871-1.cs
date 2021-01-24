    <UserControl
            ....
            x:Name="uc1">
        <UserControl.Resources>
    
            <local:SelectedCalcDataConverter x:Key="calcDataSelector"/>
            
            <DataTemplate DataType="{x:Type local:TagClass }" >
                <Border BorderBrush="Black" BorderThickness="1">
                    <StackPanel Orientation="Horizontal" >
                        <Label Content="Tag Class" />
                    </StackPanel>
                </Border>
            </DataTemplate>
            <DataTemplate DataType="{x:Type local:ConnectionClass }">
                <Border CornerRadius="4" Background="White" BorderThickness="2" BorderBrush="{DynamicResource NormalBorderBrush}" >
                    <StackPanel Orientation="Vertical">
                        <StackPanel.DataContext>
                            <MultiBinding Converter="{StaticResource calcDataSelector}" Mode="OneWay">
                                <Binding Path="CalcData"/>
                                <Binding ElementName="uc1" Path="SelectedConditionId"/>
                            </MultiBinding>
                        </StackPanel.DataContext>
                        <Label Content="Connection Class" />
    
                        <!--Label Content="HERE I WANT TO DISPLAY related CalcData.Name" /-->
                        <Label Content="{Binding Name}"/>
                    </StackPanel>
                </Border>
            </DataTemplate>
    
        </UserControl.Resources>
        <Grid>
            <StackPanel Orientation="Horizontal"  >
                <Label Content="This is Holder Class" FontWeight="Bold" />
                <ContentControl Content="{Binding Path=Content}" />
            </StackPanel>
        </Grid>
    </UserControl>
