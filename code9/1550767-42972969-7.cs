        using System.Runtime.Serialization;
        ..
        pi = (PropertyItem)FormatterServices
            .GetUninitializedObject(typeof(PropertyItem));
        pi.Id = 0x0112;   // orientation
        pi.Len = 2;
        pi.Type = 3;
        pi.Value = new byte[2] { 1, 0 };
        pi.Value[0] = yourOrientationByte;
        yourImage.SetPropertyItem(pi);
