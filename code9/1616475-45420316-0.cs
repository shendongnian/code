    var cts = new CancellationTokenSource();
    var A = Usermanager.FindAsync(email.ToString(), password.ToString());
    var B = db.Table.AnyAsync(r=> r.email == email.Tostring(), cts.Token) //simplified action
    var C = A.ContinueWith(t => { if (t.Result == null) { cts.Cancel(); } }, TaskContinuationOptions.OnlyOnRanToCompletion);
    await Task.WhenAll(C,B);
