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
    
    
