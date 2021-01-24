    <Button>
        <Button.Style>
            <Style TargetType="Button">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding Items.Count, ElementName=listViewOne}" Value="0">
                        <Setter Property="IsEnabled" Value="False" />
                    </DataTrigger>
                    <DataTrigger Binding="{Binding Items.Count, ElementName=listViewTwo}" Value="0">
                        <Setter Property="IsEnabled" Value="False" />
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </Button.Style>
    </Button>
