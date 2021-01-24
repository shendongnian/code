        Outlook.MailItem mail = null;
        Outlook.Inspector inspector = null;
        private void Inspectors_NewInspector(Outlook.Inspector Inspector)
        {
            inspector = Inspector;
            object oMail = inspector.CurrentItem;
            if (oMail is Outlook.MailItem)
            {
                    mail = (Outlook.MailItem)oMail.CurrentItem;               
                    inspector.AttachmentSelectionChange += Inspector_AttachmentSelectionChange;
                    Application.AttachmentContextMenuDisplay += Application_AttachmentContextMenuDisplay;
                    mail.BeforeAttachmentAdd += Mail_BeforeAttachmentAdd;
                    mail.AttachmentAdd += Mail_AttachmentAdd;
                    mail.BeforeAttachmentWriteToTempFile += Mail_BeforeAttachmentWriteToTempFile;
                    mail.BeforeAttachmentSave += Mail_BeforeAttachmentSave;
            }
        }
