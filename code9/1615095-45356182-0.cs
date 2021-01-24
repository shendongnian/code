        private void OnPaste(object sender, DataObjectPastingEventArgs e)
        {
            var isText = e.SourceDataObject.GetDataPresent(DataFormats.UnicodeText, true);
            if (!isText) return;
            var text = e.SourceDataObject.GetData(DataFormats.UnicodeText) as string;
            HandlePaste(text);
            e.Handled = true;
        }
        private void HandlePaste(string text)
        {
            var letters = text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            if (letters.Length == 4)
            {
                for (var i = 0; i < 4; i++)
                {
                    Letterbox[0, i].Text = letters[i];
                }
            }
        }
