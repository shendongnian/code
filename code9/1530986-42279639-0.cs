    <wpfQuestionnaire:BinaryQuestion
        AnswerRequired="{Binding IsYoungerThanSeventy
            , Mode=TwoWay                                          
            , NotifyOnTargetUpdated=True}" TargetUpdated="BinaryQuestion_TargetUpdated">
    </wpfQuestionnaire:BinaryQuestion>
----------
    private void BinaryQuestion_TargetUpdated(object sender, DataTransferEventArgs e)
    {
        BinaryQuestion bq = sender as BinaryQuestion;
        ViewModel vm = bq.DataContext as ViewModel;
        if (vm != null)
        {
            YourCustomCompositeCommandArgumentType param = new YourCustomCompositeCommandArgumentType() { Source = bq, Parameter = vm.IsYoungerThanSeventy };
            vm.PropertyBoundToAnswerRequiredChangedCommand.Execute(param);
        }
    }
