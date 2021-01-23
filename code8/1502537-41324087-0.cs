    What you can do is to write a style for "DataGridRow" as
    <Style x:Type="DataGridRow">
    <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="{x:Type DataGridRow}">
                        <Grid Background="{TemplateBinding Background}">
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="*"/>
                                <ColumnDefinition Width="auto"/>
                            </Grid.ColumnDefinitions>
                            <ContentPresenter Grid.Column="0" />
                            <Button Visibility = "{Binding IsLastRow}"/>!--can set converter to convert boolean to visibilty as well.
                        </Grid>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
    </Style>
    
    So the binded property basically check the logic of the last row.(I am not sure wpf datagrid by itself provides some kind of property like "IsLastRow" or not. But if not anytime you can write your own logic).
    
    In ContentTemplate you can define your button handler or command object.
    Hope this well help.
