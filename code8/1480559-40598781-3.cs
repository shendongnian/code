    using System;
    using System.Drawing;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    [Serializable]
    public partial class MyData
    {
        public string Label { get; set; }
        byte[] bytes;
        [NonSerialized]
        Image image;
        public Image Image
        {
            get
            {
                if (image == null && bytes != null)
                    image = (Image)((new ImageConverter()).ConvertFrom(bytes));
                return image;
            }
            set
            {
                image = value;
                bytes = (byte[])new ImageConverter().ConvertTo(value, typeof(byte[]));
            }
        }
    }
