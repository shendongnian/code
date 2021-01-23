			protected override void OnShown(EventArgs e)
			{
				base.OnShown(e);
				var task = Task.Factory.StartNew(doWork)
					.ContinueWith
					(
						antecedent => { this.Close(); },
						CancellationToken.None,
						TaskContinuationOptions.OnlyOnRanToCompletion,
						TaskScheduler.FromCurrentSynchronizationContext()
					)
					.ContinueWith
					(
						antecedent => { 
							throw antecedent.Exception;
						},
						CancellationToken.None,
						TaskContinuationOptions.OnlyOnFaulted,
						TaskScheduler.FromCurrentSynchronizationContext()
					);
                // this is where magic happens.
				task.Wait();
			}
