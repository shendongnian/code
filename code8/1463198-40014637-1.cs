    using (myDataContext sls = new myDataContext())
    {
     IQueryable<tblNVRChannel> channels= (from channel in sls.tblNVRChannels
                                      where kanal.fltNVR == 75
                                      select channel);
     tblNVRChannel[] kanArray = channels.ToArray();
	 var textbox = GetAll(this, typeof(TextBox));
			// Do whatever you want to do with your textbox.
			foreach (var item in channelArray)
			 {
				 foreach(Control c in textbox)
				{
					if (c is TextBox)
					{ 
                        var tx = ((TextBox) x);
						if (string.IsNullOrEmpty(tx.Text))
						{
							tx.Text = item.fltNamn;
							break;
						}
					}
				}
			}
	
    }
    public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }
