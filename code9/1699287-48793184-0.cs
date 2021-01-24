    public class CustomDataGridView : DataGridView
    {
        //TODO come up with meaningful name to represent the action that's taking place, 
        //and to differentiate it from CellClick
        public event Action<string> YourNewEvent;
        public CustomDataGridView()
        {
            CellClick += (sender, args) =>
            {
                if (args.RowIndex >= 1)
                {
                    string text = GenerateTextToSendOnClick();
                    YourNewEvent?.Invoke(text);
                }
            };
        }
        private string GenerateTextToSendOnClick()
        {
            throw new NotImplementedException();
        }
    }
