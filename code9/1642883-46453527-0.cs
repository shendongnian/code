    <DataTemplate DataType="{x:Type commmon:BuildConfiguration}">
        <TextBlock x:Name="ConfigBlock">
            <Run Text="{Binding Name, Mode=OneWay}"/>
            <TextBlock.InputBindings>
                <MouseBinding MouseAction="LeftClick" 
                              Command="{Binding DataContext.BuildCommand, 
                              RelativeSource={RelativeSource AncestorLevel=2, 
                              AncestorType={x:Type MenuItem}}}">
                </MouseBinding>
            </TextBlock.InputBindings>
        </TextBlock>
    </DataTemplate>
