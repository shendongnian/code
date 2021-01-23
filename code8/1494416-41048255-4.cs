    <DataGrid x:Name="quizDatagrid" CanUserAddRows="False" Margin="10,90,0,10" ClipboardCopyMode="None" AutoGenerateColumns="False" HorizontalAlignment="Left" Width="698">
        <DataGrid.Columns>
            <DataGridTextColumn Binding="{Binding id}" Header="Category ID" />
            <DataGridTextColumn Binding="{Binding name}" Header="Category Name" />
            <DataGridTextColumn Binding="{Binding question[0].id}" Header="Question ID" />
            <DataGridTextColumn Binding="{Binding question[0].description}" Header="Question Description" />
            <DataGridTextColumn Binding="{Binding question[0].answer.id}" Header="Answer ID" />
            <DataGridTextColumn Binding="{Binding question[0].answer.description}" Header="Answer Description" />
            <DataGridTextColumn Binding="{Binding question[0].answer.isCorrect}" Header="Is Correct" />
            <DataGridTextColumn Binding="{Binding question[0].answer.pointAmount}" Header="Point Amount" />
        </DataGrid.Columns>
    </DataGrid>
