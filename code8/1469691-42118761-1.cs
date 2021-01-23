    /// <summary>
    /// Show a snackbar notification on screen
    /// </summary>
    /// <param name="view">this is the parent container</param>
    /// <param name="msg">message to show in the snackbar</param>
    public static void ShowSnack(View view, string msg)
    {            
        if(view != null)
        {
            try
            {
                Snackbar snackBar = Snackbar.Make(view, msg, Snackbar.LengthLong);
                snackBar.SetAction("Ok", (v) =>
                {
                    Log.Info(TAG, "Action in view clicked");
                });
                snackBar.Show();
            }
            catch(Exception ex)
            {
                Log.Error(TAG, "Error occured when showing snackbar: " + ex.Message); 
            }                
        }
    }
