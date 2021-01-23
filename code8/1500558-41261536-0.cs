        private void OnDragComplete()
        {
            _isDragCompleted = true;
            if (_isDragCompleted && _isConditionChanged)
            {
                CollapseStackPanel();
            }
        }
        private void OnChangeCondition()
        {
            _isConditionChanged = true;
            if (_isDragCompleted && _isConditionChanged)
            {
                CollapseStackPanel();
            }
        }
        private void CollapseStackPanel()
        {
            _isDragCompleted = false;
            _isConditionChanged = false;
            StackPanel.Visibility = Visibility.Collapsed;
        }
