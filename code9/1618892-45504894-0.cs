    public static class BitmapExtensions
    {
        public static BitmapImage ToBitmapImage(this Bitmap bitmap)
        {
            using (var stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Png);
                stream.Position = 0;
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.DecodePixelHeight = 18;
                image.DecodePixelWidth = 18;
                image.StreamSource = stream;
                image.EndInit();
                image.Freeze();
                return image;
            }
        }
    }
    public class Emoticon
    {
        public Emoticon(string key, Bitmap bitmap)
        {
            Key = key;
            Bitmap = bitmap;
            BitmapImage = bitmap.ToBitmapImage();
        }
        public string Key { get; }
        public Bitmap Bitmap { get; }
        public BitmapImage BitmapImage { get; }
    }
    public class EmoticonTextBox : TextEditor
    {
        public EmoticonTextBox()
        {
            HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
            VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
            TextArea.TextView.ElementGenerators.Add(new ImageElementGenerator());
        }
    }
    public class ImageElementGenerator : VisualLineElementGenerator
    {
        // To use this class:
        // textEditor.TextArea.TextView.ElementGenerators.Add(new ImageElementGenerator());
        private static readonly Regex ImageRegex = new Regex(@":D", RegexOptions.IgnoreCase);
        private readonly List<Emoticon> _emoticons;
        public ImageElementGenerator()
        {
            _emoticons = new List<Emoticon>
            {
                new Emoticon(":D", Properties.Resources.grinning_face)
            };
        }
        private Match FindMatch(int startOffset)
        {
            var endOffset = CurrentContext.VisualLine.LastDocumentLine.EndOffset;
            var relevantText = CurrentContext.Document.GetText(startOffset, endOffset - startOffset);
            return ImageRegex.Match(relevantText);
        }
        public override int GetFirstInterestedOffset(int startOffset)
        {
            var match = FindMatch(startOffset);
            return match.Success ? startOffset + match.Index : -1;
        }
        public override VisualLineElement ConstructElement(int offset)
        {
            var match = FindMatch(offset);
            if (!match.Success || match.Index != 0)
                return null;
            var key = match.Groups[0].Value;
            var emoticon = _emoticons.FirstOrDefault(x => x.Key.Equals(key));
            var bitmap = emoticon?.BitmapImage;
            if (bitmap == null)
                return null;
            var image = new System.Windows.Controls.Image
            {
                Source = bitmap,
                Width = bitmap.PixelWidth,
                Height = bitmap.PixelHeight
            };
            return new InlineObjectElement(match.Length, image);
        }
    }
