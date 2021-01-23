    public interface IPlatformProvider {
        /// <summary>
        ///  Executes the action on the UI thread asynchronously.
        /// </summary>
        /// <param name = "action">The action to execute.</param>
        System.Threading.Tasks.Task OnUIThreadAsync(Action action);    
    }
