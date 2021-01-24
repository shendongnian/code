         Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    new Action(() =>
                    {
                        Data.Rows.Add(percentFinished.ToString(), percentFinished.ToString());
                    }
                    ));
