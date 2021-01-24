    public interface IOpenFileDialog {
        string Filter { get; set; }
        bool? ShowDialog();
        string FileName { get; set; }
    }
    public interface IFile {
        string ReadAllText(string path, Encoding encoding = Encoding.UTF8);
    }
