    public void LiveAnalysisIsDone()
            {
    			string LiveAnalysisCompleteText = System.Windows.Application.Current.TryFindResource("LiveAnalysisComplete").ToString();
    			if (CustomControlContent != null)      			{
    				//Remove Children from UserControl
    				if (CustomControlContent.GetType() != typeof(BioRad.ddPCR.UI.Views.Analysis.Reports.ReportGeneratorUserControl))
    				{
    					this.Dispatcher.BeginInvoke((Action)(() =>
    					{
    						var content = CustomControlContent.Content as Grid;
    						if (content != null)
    						{
    							var Panel = content.Children[1] as StackPanel;
    							(Panel.Children[0] as TextBlock).Text = LiveAnalysisCompleteText;
    						}
    					}));
    					
    					
    				}
    			}
    		}
