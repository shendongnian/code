    public void RunThing(Action<RecurringTaskRunResult> action, RecurringTaskRunResult result, params object[] list) {
        try {
            action(result);
            foreach(var item in list)
            {
                // Do action with your additional parameter
            }
        }
        catch (Exception e) {
            result.Succeeded = false;
            result.Results += e.ToString();
            db.SaveChanges();
        }
    }
