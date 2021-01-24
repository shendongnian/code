        private void this_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox)
            {
                var textb = sender as TextBox;
                if (textb.LineCount > 1)
                {
                    foreach (var change in e.Changes.Where(x=>x.RemovedLength == 0))
                    {
                        for (int index = change.AddedLength; index > 0; index--)
                        {
                            textb.Text = textb.Text.Remove(change.Offset, 1);
                            textb.UpdateLayout();
                            if (textb.LineCount == 1)
                                break;
                        }
                        if (textb.LineCount == 1)
                            break;
                    }
                }
            }
        }
