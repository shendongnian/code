    <UserControl.Resources>
        <Style x:Key="MyStyle" TargetType="ListViewItem">
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="ListViewItem">
                        <Grid Background="{TemplateBinding Background}">
                            <ContentPresenter HorizontalAlignment="{TemplateBinding HorizontalAlignment}"
                        />
                        </Grid>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
    </UserControl.Resources>
