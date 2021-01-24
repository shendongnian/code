            try
            {
                var recipients = OLitem.Recipients;
                string parent = string.Empty;
                foreach (Microsoft.Office.Interop.Outlook.Recipient recipient in recipients)
                {
                    switch (recipient.Type)
                    {
                        case (int)Microsoft.Office.Interop.Outlook.OlMailRecipientType.olTo:
                            toStringBuilder.Append(recipient.Address + ", ");
                            if (parent == string.Empty)
                            {
                                parent = recipient.Address;
                            }
                            break;
                        case (int)Microsoft.Office.Interop.Outlook.OlMailRecipientType.olCC:
                            ccStringBuilder.Append(recipient.Address + ", ");
                            break;
                        case (int)Microsoft.Office.Interop.Outlook.OlMailRecipientType.olBCC:
                            bccStringBuilder.Append(recipient.Address + ", ");
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                // do something with error
            }
        }`
