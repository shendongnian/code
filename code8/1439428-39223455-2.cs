    <Style TargetType="anal:ButtonAnalysisControl">
        ...    
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="anal:ButtonAnalysisControl">
                    <Grid Background="Transparent">
                        <Grid.ContextMenu>
                            <ContextMenu ItemsSource="{Binding Path=PlacementTarget.DataContext.ChildCommands, RelativeSource={RelativeSource Self}}">
        ...
