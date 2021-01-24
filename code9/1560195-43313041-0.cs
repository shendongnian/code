        Stack context = new Stack();
        private void BtnForward_Click(object sender, RoutedEventArgs e)
        {
            // Here you would need to set the value of the Abcd based on your business logic
            context.Push(Abcd);
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                context.Pop();
                TextBoxText.Text = context.Peek(); // gets the most recently entered value of the stack that has not been removed (popped)
            }
            catch (InvalidOperationException exc)
            {
                // Nothing to go back to
            }
        }
