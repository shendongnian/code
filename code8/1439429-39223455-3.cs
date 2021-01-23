    <Style TargetType="anal:ButtonAnalysisControl">
        ...    
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="anal:ButtonAnalysisControl">
                    <Grid Background="Transparent" Tag="{Binding ChildCommands,RelativeSource={RelativeSource TemplatedParent}}">
                        <Grid.ContextMenu>
                            <ContextMenu ItemsSource="{Binding Path=PlacementTarget.Tag, RelativeSource={RelativeSource Self}}">
        ...
