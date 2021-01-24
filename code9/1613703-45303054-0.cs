    try 
    {
       LoginInner(); // here you call service and update UI
    }
    catch (Exception ex)
    {
        InvokeOnMainThread(() =>
        {
            // Add action button "Retry" to snackBar
            _snackBar = new TTGSnackbar("ex.Message", TTGSnackbarDuration.Forever, "Retry", (obj) => {
                // **Retry all tasks**
                Parallel.ForEach(_taskList, LoginInner); // ** call again loginInner **
            });
            _snackBar.Show();
        });
    }
}
`
