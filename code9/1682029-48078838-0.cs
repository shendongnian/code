    <StackPanel>
        <RadioButton GroupName="a" IsChecked="{Binding R1}">123</RadioButton>
        <RadioButton GroupName="a" IsChecked="{Binding R2}">456</RadioButton>
        <RadioButton GroupName="a" IsChecked="{Binding R3}">789</RadioButton>
    </StackPanel>
    <Button Grid.Row="1" IsEnabled="{Binding SubmitEnabled}">Sumit</Button>
