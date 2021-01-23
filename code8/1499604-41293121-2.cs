    private void ModelViewport_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (_mainViewModel.AppState.IsInState(States.CreatingShape))
            {
                // retrieve mouse position
                
                // Execute command with retrieved position
                _CreateShapeViewModel.CreateShapeGraphicallyCommand.Execute(Position);
            }
        }
