                cts.Cancel();
                cts.Dispose();
                Task.WaitAll(tasks.ToArray());
                tasks.Clear();
                cts = new CancellationTokenSource();
                ct = cts.Token;
                // Result.Clear();
                // Workaround see: https://stackoverflow.com/questions/48491781/xamarin-forms-ios-build-list-view-items-dynamically-observablecollection-and/48505622#48505622
                // Bug: https://bugzilla.xamarin.com/show_bug.cgi?id=59896
                Result = new ObservableCollection<T>();
                // Create background task
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    var validItems = Source.Where(c => ((ISearchQueryViewModel)c).SearchData.RegexContains(Query)).OrderByDescending(c => ((ISearchQueryViewModel)c).Aktive).ToList();
                    if (ct.IsCancellationRequested)
                        return;
                    for (int i = 0; i < validItems.Count; i++)
                    {
                        if (ct.IsCancellationRequested)
                            return;
                        Result.Add(validItems[i]);
                        Thread.Sleep(25);
                    }
                }, ct));
