        public void DoSomething(Grid lessonGrid)
        {
            var invisibleButton = new Button();
            lessonGrid.Children.Add(invisibleButton);
            var contentGrid = new Grid();
            var buttonInFlyOut = new Button { Content = "Click" };
            buttonInFlyOut.Click += (o, args) =>
                {
                    this.OnButtonClicked(lessonGrid);
                };
            contentGrid.Children.Add(buttonInFlyOut);
            var flyout = new Flyout { Content = contentGrid };
            flyout.Closed += (f, h) => { lessonGrid.Children.Remove(invisibleButton); };
            flyout.ShowAt(invisibleButton); // i want to acces a owner from parent of invisible Button -> lessonGrid
        }
        private void OnButtonClicked(Grid lessonGrid)
        {
            // Do something here
        }
