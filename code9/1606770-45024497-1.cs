    for (int i = 0; i < count; i++) {
        grid.RowDefinitions.Add(rowCollection[i]);
        AnimatedButton button = new AnimatedButton(menuOptions.ItemDataList[i].TitleText) { ButtonIndex = i+1};
        button.ClickedAnimationCompleted += (s, e) => {
            RefreshGrid(button.ButtonIndex);
        };
        grid.Children.Add(button, 0, i + 1);
    }
