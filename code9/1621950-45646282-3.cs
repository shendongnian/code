    public class WindowService
    {
        public async Task<bool> ShowModalAsync(AwaitableViewModelBase viewModel, string dataTemplateKey = null)
        {
            var tcs = new TaskCompletionSource<bool>();
            viewModel.RegisterTaskCompletionSource(tcs);
            Application.Current.Dispatcher.Invoke(() =>
            {
                var currentWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive) ?? Application.Current.MainWindow;
                var window = new PopupHost(currentWindow, viewModel, dataTemplateKey);
                window.ShowDialog();
            });
            return await viewModel.Task;
        }
    }
