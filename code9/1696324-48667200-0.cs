    foreach (var attachment in message.Attachments.OfType<MimePart> ()) {
        using (var memory = new MemoryStream ()) {
            attachment.Content.DecodeTo (memory);
            var data = memory.ToArray ();
            var text = Encoding.UTF8.GetString (data);
        }
    }
