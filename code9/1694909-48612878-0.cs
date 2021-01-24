    public class ContrastControlViewModel : ViewModelBase, IContrastControlViewModel
	{
		private IUpdateContrastCurveService _updateContrastCurveService;
	  
		public ContrastControlViewModel(IUpdateContrastCurveService updateContrastCurveService)
		{
			_updateContrastCurveService = updateContrastCurveService;
		}
	  
		public void UpdateCompositePropertyValues(String propertyName)
		{
			if (SelectedVideoProcessingSubstream != null)
			{
				switch (propertyName)
				{
					case "ContrastCurve":
						if (_enableContrastControlUpdate)
						{
							_updateContrastCurveService.UpdateContrastCurve();  // Only updates the local line graph display of the contrast controls
							_enableContrastControlUpdate = false;
						}
						break;
					default:
						break;
				}
			}
		}
		public IVideoProcessingSubstreamViewModel SelectedVideoProcessingSubstream {get;set;}
	}
