    internal static async System.Threading.Task<ProgressDialogResult> Execute(Window owner, string label, Func<System.Threading.Task> operation, ProgressDialogSettings settings)
    {
        return await ExecuteInternal(owner, label, (object)operation, settings);
    }
    internal static async System.Threading.Task<ProgressDialogResult> ExecuteInternal(Window owner, string label, Func<System.Threading.Task> operation, ProgressDialogSettings settings)
    {
        // do whatever
        await operation();
        return //whatever;
    }
