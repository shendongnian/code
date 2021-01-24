    <Button x:Name="closeorderbtn" Content="" Click="CloseOrder" Background="#FF5890BF" Foreground="#FFBFBCBC">
        <Button.Style>
            <Style TargetType="Button">
                <Setter Property="Content" Value="Open Order" />
                <Style.Triggers>
                    <DataTrigger Binding="{Binding Status}" Value="Accepted">
                        <Setter Property="Content" Value="Close Order" />
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </Button.Style>
    </Button>
