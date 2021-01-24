    private void DesignScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
    {
	  if (e.VerticalOffset > OffsetValue)
	   {
		 OffsetValue = e.VerticalOffset;
		 if (TempCanvasRowCount < DesignCanvas.RowCount && (e.VerticalOffset/48) > prevCanvasRowCount)
		  {
			TempCanvasRowCount += 12;
			prevCanvasRowCount += 12;
			var _backGroundWorker = new BackgroundWorker { }
			_backGroundWorker.DoWork += (obj, args) =>
	 		 {
  			   RenderingWidgets(window.DashboardDesigner);
			  };
			_backGroundWorker.RunWorkerCompleted += (obj, args) =>
			 {
				if (TempCanvasRowCount > DesignCanvas.RowCount)
					TempCanvasRowCount = DesignCanvas.RowCount;	
			  };
					_backGroundWorker.RunWorkerAsync(this);				
			}
		}           
    }
