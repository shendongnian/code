    		internal void remLock()
        {
            vstoDocument = Globals.Factory.GetVstoObject(this.Application.ActiveDocument);
            
            Word.Selection selection = this.Application.Selection;
			
			String s; = selection.ParentContentControl.Tag.ToString();
			
			remByTag(s);
        }
        private void remByTag(String ccTag)
        {
            if (vstoDocument.ContentControls.Count != 0)
            {
                foreach (Word.ContentControl cc in vstoDocument.ContentControls)
                {
                    if (cc.Type == Word.WdContentControlType.wdContentControlRichText)
                    {
                        if (cc.Tag.ToString() == ccTag)
                        {
                            cc.LockContentControl = false;
                            cc.LockContents = false;
							
                            MessageBox.Show("Lock has been removed");
                            return;
                        }
                    }
                }
            }
        }
