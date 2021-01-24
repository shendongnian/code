          Window.isHitTestVisible = false;
		  alertBox.AbortButton.Click += (obj, args) =>
            {
				Window.IsHitTestVisible = true;
                source.Cancel();
                backGroundWorker.CancelAsync();
                backGroundWorker.Abort();
                backGroundWorker.Dispose();
                GC.Collect();
            };
            backGroundWorker.DoWork += (obj, args) =>                 
            { 
                    table = GetData((CancellationToken)args.Argument);
                    if (source.Token != default(CancellationToken))
                        if (source.Token.IsCancellationRequested)
                            return;
             };
            backGroundWorker.RunWorkerCompleted += (obj, args) =>
            {
			    Window.IsHitTestVisible = true;
                alertBox.IsBusy = false;
            };
