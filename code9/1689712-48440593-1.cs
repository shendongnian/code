    <telerik:GridViewDataColumn Header="MyColumn1" DataMemberBinding="{Binding MyColumn1Binding}" Width="150" >
        <telerik:GridViewDataColumn.CellStyle>
            <Style TargetType="{x:Type telerik:GridViewCell}">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="telerik:GridViewCell">
                            <Border BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" Background="{TemplateBinding Background}">
                                <ContentPresenter  Content="{TemplateBinding Content}" ContentTemplate="{TemplateBinding ContentTemplate}" ToolTip="{TemplateBinding ToolTip}" VerticalAlignment="Center" Margin="3,0"/> 
                            </Border>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
                <Setter Propert="BorderBrush" Value="Red" />
                <Setter Propert="BorderThickness" Value="2,2,2,2" />
            </Style>
        </telerik:GridViewDataColumn.CellStyle>
    </telerik:GridViewDataColumn
