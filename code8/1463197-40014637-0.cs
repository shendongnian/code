    using (myDataContext sls = new myDataContext())
    {
     IQueryable<tblNVRChannel> channels= (from channel in sls.tblNVRChannels
                                      where kanal.fltNVR == 75
                                      select channel);
     tblNVRChannel[] kanArray = channels.ToArray();
	 
			// Do whatever you want to do with your textbox.
			foreach (var item in channelArray)
			 {
				 foreach(Control c in Page.Controls)
				{
					if (c is TextBox)
					{ 
						if(string.isNullOrEmpty(c.Text))
						{
							c.Text = item.fltNamn;
							break;
						}
					}
				}
			}
	
    }
