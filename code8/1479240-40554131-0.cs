     var context = TaskScheduler.FromCurrentSynchronizationContext();
                var parent = Task.Factory.StartNew(() => {
    
                Task.Delay(40000);
                    MessageBox.Show("From Parent");
                var child = Task.Factory.StartNew(() =>{
                    MessageBox.Show("From Child");
                    Task.Delay(30000);
                    Text = "Title change from Child";
                });
                }, CancellationToken.None, TaskCreationOptions.AttachedToParent, context);
