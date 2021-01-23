               <Style x:Key="GroupingNcpCheckStyleRoot" TargetType="{x:Type GroupItem}" BasedOn="{StaticResource GroupingBaseRoot}">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate>
                            <Expander Background="{TemplateBinding Background}" BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" IsExpanded="{Binding IsExpandedData, RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type UserControl}}, Mode=OneTime}" Margin="2">
                                <Expander.Header>
                                    <StackPanel Orientation="Horizontal">
                                        <CheckBox x:Name="HeaderCheckBox" Margin="0,0,6,0" IsChecked="True"></CheckBox>
                                        <TextBlock Text=" # "/>
                                        <TextBlock Text="{Binding Name}"/>
                                    </StackPanel>
                                </Expander.Header>
                                <StackPanel Orientation="Vertical">
                                    <GridViewHeaderRowPresenter Margin="15,0,0,0"
                                                    
                                                    DataContext="{Binding View, RelativeSource={RelativeSource FindAncestor, ListView, 1}}" 
                                                    SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}"
                                                    Visibility="Visible"   >
                                        <GridViewHeaderRowPresenter.Columns>
                                        <!--NOTE: must explicitly create the collection-->
                                        <GridViewColumnCollection>
                                                <GridViewColumn Header=" " Width="60" >
                                                    <GridViewColumn.HeaderContainerStyle>
                                                        <Style TargetType="{x:Type GridViewColumnHeader}" BasedOn="{StaticResource GridViewColumnHeaderStyleTEST1}">
                                                            <Setter Property="Background" Value="{StaticResource TargetHeaderColor}" />
                                                            <Setter Property="Foreground" Value="White" />
                                                            <Setter Property="BorderThickness" Value="0" />
                                                            <Setter Property="Margin" Value="-1,0,-1,0" />
                                                        </Style>
                                                    </GridViewColumn.HeaderContainerStyle>
                                                    <GridViewColumn.CellTemplate>
                                                    <DataTemplate >
                                                        <TextBlock HorizontalAlignment="Left" Text="{Binding Path=Id, StringFormat='# {0}'}"/>
                                                    </DataTemplate>
                                                </GridViewColumn.CellTemplate>
                                            </GridViewColumn>
                                                <GridViewColumn Header=" Show " >
                                                    <GridViewColumn.HeaderContainerStyle>
                                                        <Style TargetType="{x:Type GridViewColumnHeader}" BasedOn="{StaticResource GridViewColumnHeaderStyleTEST1}">
                                                            <Setter Property="Background" Value="{StaticResource DifferentHeaderColor}" />
                                                            <Setter Property="Foreground" Value="White" />
                                                            <Setter Property="BorderThickness" Value="0" />
                                                            <Setter Property="Margin" Value="-1,0,-1,0" />
                                                        </Style>
                                                    </GridViewColumn.HeaderContainerStyle>
                                                    <GridViewColumn.CellTemplate>
                                                        <DataTemplate >
                                                            <CheckBox IsChecked="{Binding Path=IncludeInReport}" HorizontalAlignment="center"></CheckBox>
                                                        </DataTemplate>
                                                    </GridViewColumn.CellTemplate>
                                                </GridViewColumn>
