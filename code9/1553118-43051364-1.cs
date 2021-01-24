    xmlns:i="http://schemas.microsoft.com/expression/2010/interactivity"
    xmlns:behaviour="clr-namespace:WpfApplication.Behaviour" 
    <!-- ... --->
        <Grid >
            <Grid.ColumnDefinitions>
                <ColumnDefinition MinWidth="30"/>
                <ColumnDefinition />
                <ColumnDefinition/>
                <ColumnDefinition/>
            </Grid.ColumnDefinitions>
            <TextBox Text="{Binding Comment,Mode=TwoWay,UpdateSourceTrigger=PropertyChanged}" Grid.Column="0" Grid.ColumnSpan="3" ></TextBox>
            <TextBlock Text="{Binding Text1,Mode=TwoWay,UpdateSourceTrigger=PropertyChanged}" Grid.Column="1" Grid.ColumnSpan="2"/>
            <Label  Content="{Binding Text2,Mode=TwoWay,UpdateSourceTrigger=PropertyChanged}" Grid.Column="2" HorizontalAlignment="Right" />
            <CheckBox IsChecked="{Binding IsChecked,Mode=TwoWay,UpdateSourceTrigger=PropertyChanged}" Grid.Column="3" HorizontalAlignment="Center" IsThreeState="True"/>
            <Path />
            <i:Interaction.Behaviors>
                <behaviour:SelectedCheckBoxBehaviour />
            </i:Interaction.Behaviors>
            
        </Grid>
