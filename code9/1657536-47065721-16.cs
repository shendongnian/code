    using System;
    using System.IO;
    using System.Text;
    using System.Windows.Controls;
    namespace ManageScreenSaver.MediaElementWpf
    {
        public class TextBoxWriter : TextWriter
        {
            private TextBox _TextBox;
            private string _NewLine = "\n";
            public TextBoxWriter(TextBox target)
            {
                if (target == null)
                    throw new ArgumentNullException(nameof(target));
                _TextBox = target;
            }
            public override Encoding Encoding => new UTF8Encoding(false);
            public override string NewLine { get => _NewLine; set => _NewLine = value; }
            public override void Write(string value)
            {
                _TextBox.Dispatcher.InvokeAsync(
                    () => _TextBox.AppendText(value)
                    );
            }
            public override void WriteLine(string value)
            {
                _TextBox.Dispatcher.InvokeAsync(
                    () => _TextBox.AppendText(value + NewLine)
                    );
            }
        }
    }
