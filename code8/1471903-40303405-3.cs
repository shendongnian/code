			protected async override void OnShown(EventArgs e)
			{
				base.OnShown(e);
				await Task.Factory.StartNew(() => 
				{
					Thread.Sleep(1000); // Simulate work.
					throw new InvalidOperationException("TEST");
				})
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
			   
			}
