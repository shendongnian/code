	public sealed partial class SynchProcess : BasePage
	{
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			Task.Run(async ()=>{
				var result = await SynchTables();
			});
		}
		private async Task<bool> SynchTables()
		{
			Bool bRet = true;
			List<Task> tasks = new List<Task>();
			Try
			{
				// Refresh 1
				tasks.Add(Task.Run(async () => 
				{
					// Update UI
					await DisplayProgress(“Cars refresh…running”); 
					List<Car> cars = await _dataService.GetCarsData();
					DataAccessSQLite.DeleteAll<Car>();
					DataAccessSQLite.InsertCars(cars);
					// Update UI
					await DisplayProgress(“Cars refresh…completed”); 
				}));
				// Refresh 2
				// Refresh 3
				// Refresh 4
				…
				…                
				Task.WaitAll(tasks.ToArray());
			}
			Catch(AggreggateException agEx)
			{
				bRet = false;
			}
			return bRet;
		}
		private async Task  DisplayProgess(string message)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {                
                lsvInvSynchProgress.Items.Add($"{message} - {DateTime.Now}");
            });
        }
	}
