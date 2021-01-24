        <ContentControl Content="{Binding}">
            <ContentControl.Style>
                <Style TargetType="{x:Type ContentControl}">
                    <Setter Property="ContentTemplate" Value="{StaticResource NotResizableContent}" />
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding Path=IsResizable}" Value="True">
                            <Setter Property="ContentTemplate" Value="{StaticResource ResizableContent}" />
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </ContentControl.Style> 
        </ContentControl>
