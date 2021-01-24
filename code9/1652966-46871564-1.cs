    var viewModel = new ViewModel();
    _textBlock.DataContext = viewModel; //// Here you bind your viewmodel to the TextBlock
    viewModel.SomeVariableChanged += (s, e) =>
    {
         if(viewModel.SomeVariable == true)
         {
             PrevStoryBoardIn.Begin();
         }
         else
         {
             PrevStoryBoardOut.Begin();
         }
    }
