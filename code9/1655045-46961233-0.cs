    public class ShellViewModel : BindableBase
    {
        public string Title => "Sample";
        public ICommand SelectionCommand => new DelegateCommand<byte[]>(buffer =>
        {
            var path = @"C:\temp\output.bmp";
            File.WriteAllBytes(path, buffer);
            Process.Start(path);
        });
    }
