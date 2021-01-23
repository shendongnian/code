    <Style TargetType="anal:ButtonAnalysisControl">
        ...    
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="anal:ButtonAnalysisControl">
                    <Grid Background="Transparent" Tag="{Binding}">
                        <Grid.ContextMenu>
                            <ContextMenu ItemsSource="{Binding Path=PlacementTarget.Tag.ChildCommands, RelativeSource={RelativeSource Self}}">
        ...
