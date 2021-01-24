    <Button x:Name="btnSave" Command="{Binding SaveCommand}" Grid.Column="2">
        <Image Source="Resources/icons/save-icon.png"></Image>
        <Button.Style>
            <Style TargetType="Button">
                <Setter Property="IsEnabled" Value="False" />
                <Style.Triggers>
                    <DataTrigger Binding="{Binding Items.Count, ElementName=listBox}" Value="0">
                        <Setter Property="IsEnabled" Value="True" />
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </Button.Style>
    </Button>
