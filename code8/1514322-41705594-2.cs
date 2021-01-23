    private bool InProg;
    internal void TBTextChanged(object sender, TextChangedEventArgs e)
                {
                var change = e.Changes.FirstOrDefault();
                if ( !InProg )
                    {
                    InProg = true;
                    var culture = new CultureInfo(CultureInfo.CurrentCulture.Name);
                    var source = ( (TextBox)sender );
                    if ( ( ( change.AddedLength - change.RemovedLength ) > 0 || source.Text.Length > 0 ) && !DelKeyPressed )
                        {
                        if ( Files.Where(x => x.IndexOf(source.Text, StringComparison.CurrentCultureIgnoreCase) > -1).Count() > 0 )
                            {
                            var _appendtxt = Files.FirstOrDefault(ap => ( culture.CompareInfo.IndexOf(ap, source.Text, CompareOptions.IgnoreCase) >= 0 ));
                            _appendtxt.Remove(0, change.Offset + 1);
                            source.Text = _appendtxt;
                            source.SelectionStart = change.Offset + 1;
                            source.SelectionLength = source.Text.Length;
                            }
                        }
                    InProg = false;
                    }
                }
