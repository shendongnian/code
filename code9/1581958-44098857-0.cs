    xmlns:i="clr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity" 
    <TextBox Text="MyText">
        <i:Interaction.Behaviors>
            <i:BehaviorCollection>
                <EventToCommand EventName="TextChanged" Command="{Binding ViewModelCommand}">
            <i:BehaviorCollection>
        </i:Interaction.Behaviors>
    </TextBox>
