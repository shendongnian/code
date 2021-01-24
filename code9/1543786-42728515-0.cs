    static void ExtractAttachments (MimePart attachment, IList<MimeEntity> attachments)
    {
        using (var reader = new TnefReader (attachment.ContentObject.Open (), 0, TnefComplianceMode.Loose)) {
            // skip past the non-attachment tnef content...
            while (reader.ReadNextAttribute ()) {
                if (reader.AttributeLevel == TnefAttributeLevel.Attachment)
    			    break;
            }
    
            if (reader.AttributeLevel == TnefAttributeLevel.Attachment)
    	        ExtractAttachments (reader, attachments);
        }
    }
    static void ExtractAttachments (TnefReader reader, IList<MimeEntity> attachments)
    {
        var attachMethod = TnefAttachMethod.ByValue;
        var filter = new BestEncodingFilter ();
        var prop = reader.TnefPropertyReader;
        MimePart attachment = null;
        int outIndex, outLength;
        TnefAttachFlags flags;
        string[] mimeType;
        byte[] attachData;
        string text;
    
        do {
            if (reader.AttributeLevel != TnefAttributeLevel.Attachment)
                break;
    
            switch (reader.AttributeTag) {
            case TnefAttributeTag.AttachRenderData:
                attachMethod = TnefAttachMethod.ByValue;
                attachment = new MimePart ();
                break;
            case TnefAttributeTag.Attachment:
                if (attachment == null)
                    break;
    
                while (prop.ReadNextProperty ()) {
                    switch (prop.PropertyTag.Id) {
                    case TnefPropertyId.AttachLongFilename:
                        attachment.FileName = prop.ReadValueAsString ();
                        break;
                    case TnefPropertyId.AttachFilename:
                        if (attachment.FileName == null)
                            attachment.FileName = prop.ReadValueAsString ();
                        break;
                    case TnefPropertyId.AttachContentLocation:
                        text = prop.ReadValueAsString ();
                        if (Uri.IsWellFormedUriString (text, UriKind.Absolute))
                            attachment.ContentLocation = new Uri (text, UriKind.Absolute);
                        else if (Uri.IsWellFormedUriString (text, UriKind.Relative))
                            attachment.ContentLocation = new Uri (text, UriKind.Relative);
                        break;
                    case TnefPropertyId.AttachContentBase:
                        text = prop.ReadValueAsString ();
                        attachment.ContentBase = new Uri (text, UriKind.Absolute);
                        break;
                    case TnefPropertyId.AttachContentId:
                        attachment.ContentId = prop.ReadValueAsString ();
                        break;
                    case TnefPropertyId.AttachDisposition:
                        text = prop.ReadValueAsString ();
                        if (attachment.ContentDisposition == null)
                            attachment.ContentDisposition = new ContentDisposition (text);
                        else
                            attachment.ContentDisposition.Disposition = text;
                        break;
                    case TnefPropertyId.AttachData:
                        var stream = prop.GetRawValueReadStream ();
                        var content = new MemoryStream ();
                        var guid = new byte[16];
    
                        if (attachMethod == TnefAttachMethod.EmbeddedMessage) {
                            var tnef = new TnefPart ();
    
                            foreach (var param in attachment.ContentType.Parameters)
                                tnef.ContentType.Parameters[param.Name] = param.Value;
    
                            if (attachment.ContentDisposition != null)
                                tnef.ContentDisposition = attachment.ContentDisposition;
    
                            attachment = tnef;
                        }
    
                        // read the GUID
                        stream.Read (guid, 0, 16);
    
                        // the rest is content
                        using (var filtered = new FilteredStream (content)) {
                            filtered.Add (filter);
                            stream.CopyTo (filtered, 4096);
                            filtered.Flush ();
                        }
    
                        content.Position = 0;
    
                        attachment.ContentTransferEncoding = filter.GetBestEncoding (EncodingConstraint.SevenBit);
                        attachment.ContentObject = new ContentObject (content);
                        filter.Reset ();
    
                        attachments.Add (attachment);
                        break;
                    case TnefPropertyId.AttachMethod:
                        attachMethod = (TnefAttachMethod) prop.ReadValueAsInt32 ();
                        break;
                    case TnefPropertyId.AttachMimeTag:
                        mimeType = prop.ReadValueAsString ().Split ('/');
                        if (mimeType.Length == 2) {
                            attachment.ContentType.MediaType = mimeType[0].Trim ();
                            attachment.ContentType.MediaSubtype = mimeType[1].Trim ();
                        }
                        break;
                    case TnefPropertyId.AttachFlags:
                        flags = (TnefAttachFlags) prop.ReadValueAsInt32 ();
                        if ((flags & TnefAttachFlags.RenderedInBody) != 0) {
                            if (attachment.ContentDisposition == null)
                                attachment.ContentDisposition = new ContentDisposition (ContentDisposition.Inline);
                            else
                                attachment.ContentDisposition.Disposition = ContentDisposition.Inline;
                        }
                        break;
                    case TnefPropertyId.AttachSize:
                        if (attachment.ContentDisposition == null)
                            attachment.ContentDisposition = new ContentDisposition ();
    
                        attachment.ContentDisposition.Size = prop.ReadValueAsInt64 ();
                        break;
                    case TnefPropertyId.DisplayName:
                        attachment.ContentType.Name = prop.ReadValueAsString ();
                        break;
                    }
                }
                break;
            case TnefAttributeTag.AttachCreateDate:
                if (attachment != null) {
                    if (attachment.ContentDisposition == null)
                        attachment.ContentDisposition = new ContentDisposition ();
    
                    attachment.ContentDisposition.CreationDate = prop.ReadValueAsDateTime ();
                }
                break;
            case TnefAttributeTag.AttachModifyDate:
                if (attachment != null) {
                    if (attachment.ContentDisposition == null)
                        attachment.ContentDisposition = new ContentDisposition ();
    
                    attachment.ContentDisposition.ModificationDate = prop.ReadValueAsDateTime ();
                }
                break;
            case TnefAttributeTag.AttachTitle:
                if (attachment != null && string.IsNullOrEmpty (attachment.FileName))
                    attachment.FileName = prop.ReadValueAsString ();
                break;
            case TnefAttributeTag.AttachMetaFile:
                if (attachment == null)
                    break;
    
                // TODO: what to do with the meta data?
                break;
            case TnefAttributeTag.AttachData:
                if (attachment == null || attachMethod != TnefAttachMethod.ByValue)
                    break;
    
                attachData = prop.ReadValueAsBytes ();
                filter.Flush (attachData, 0, attachData.Length, out outIndex, out outLength);
                attachment.ContentTransferEncoding = filter.GetBestEncoding (EncodingConstraint.EightBit);
                attachment.ContentObject = new ContentObject (new MemoryStream (attachData, false));
                filter.Reset ();
    
                attachments.Add (attachment);
                break;
            }
        } while (reader.ReadNextAttribute ());
    }
