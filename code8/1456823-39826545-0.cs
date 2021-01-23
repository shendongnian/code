    StringBuilder buf = new StringBuilder();
    buf.Append("Digitally signed by ");
    String name = null;
    CertificateInfo.X509Name x500name = CertificateInfo.GetSubjectFields((X509Certificate)signCertificate);
    if (x500name != null) {
        name = x500name.GetField("CN");
        if (name == null)
            name = x500name.GetField("E");
    }
    if (name == null)
        name = "";
    buf.Append(name).Append('\n');
    buf.Append("Date: ").Append(signDate.ToString("yyyy.MM.dd HH:mm:ss zzz"));
    if (reason != null)
        buf.Append('\n').Append(reasonCaption).Append(reason);
    if (location != null)
        buf.Append('\n').Append(locationCaption).Append(location);
    text = buf.ToString(); 
