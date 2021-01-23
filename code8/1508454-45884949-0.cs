    private void chartControl_CustomDrawSeriesPoint(object sender, CustomDrawSeriesPointEventArgs e)
    		{
    			MyClass point = e.SeriesPoint.Tag as MyClass;
    			if (point != null)
    			{
    				e.LabelText = point.z;
    			}
    		}
