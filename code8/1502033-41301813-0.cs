    <TextBox Name="TextBox" Text="{Binding MVFieldToBindTo, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" >
        <i:Interaction.Triggers>
            <i:EventTrigger EventName="DragEnter">
                <i:InvokeCommandAction 
                    Command="{Binding BoundCommand}" 
                    CommandParameter="{Binding Text, ElementName=TextBox}"/>
            </i:EventTrigger>
        </i:Interaction.Triggers>
    </TextBox>
