    public void RunThing(Action action, RecurringTaskRunResult result) {
        try {
            action();
        }
        catch (Exception e) {
            result.Succeeded = false;
            result.Results += e.ToString();
            db.SaveChanges();
        }
    }
    RunThing(() => DoParticularThing(result), result);
    RunThing(() => DoSomethingElse(result, list), result);
