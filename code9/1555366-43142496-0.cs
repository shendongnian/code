    try
    {
        var realm = Realm.GetInstance();
        await realm.WriteAsync(temp => temp.Add(company));
        // if control reaches this line the transaction executed successfully.
        notifier.NotifySuccess();
    }
    catch (Exception ex)
    {
        // The transaction failed - handle the exception
        notifier.NotifyError(ex.Message);
    }
