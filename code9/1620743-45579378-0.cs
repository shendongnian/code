        // Try catch attempt to catch all errors, the error dialog thrown within 
        //the catch is fairly simple 
        try
            {
                //Start loading spinner
                var LoadingProgressDialog = ProgressDialog.Show(this, "Loading", "Loading", false);
                //Start loading thread, this thread will carry out the functions 
                // in the order you requested
                Thread LoadingThread = new Thread(() =>
                {
                    //Line below only relevant to my code
                    StartMonday.Text = "Week Commencing On " + TodaysDate.ToLongDateString();
                    // Call this method first
                    SetData(TodaysDate);
                    // call this method second
                    FindNotesForWeek(TodaysDate, 7);
                    //Update the UI on the main thread but call third this will close the loading dialog message
                    RunOnUiThread(() => LoadingProgressDialog.Hide());
                // End of thread
                });
                //Run the thread
                LoadingThread.Start();
            }
            catch (Exception e)
            {
                var ErrorMessageDialog = ProgressDialog.Show(this, "Loading", e.ToString(), false);
            }
