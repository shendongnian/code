    <ContentControl
        Content="{Binding Model}"
        >
        <ContentControl.Style>
            <Style TargetType="ContentControl">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding Model.Foo}" Value="foo">
                        <Setter 
                            Property="ContentTemplate" 
                            Value="{StaticResource Foo}" 
                            />
                    </DataTrigger>
                    <DataTrigger Binding="{Binding Model.Foo}" Value="bar">
                        <Setter 
                            Property="ContentTemplate" 
                            Value="{StaticResource Bar}" 
                            />
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </ContentControl.Style>
    </ContentControl>
