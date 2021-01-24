    if (!this.Detached) {
        Oid contentType = PkcsUtils.GetContentType(m_safeCryptMsgHandle);
        byte[] content = PkcsUtils.GetContent(m_safeCryptMsgHandle);
        m_contentInfo = new ContentInfo(contentType, content); 
    }
