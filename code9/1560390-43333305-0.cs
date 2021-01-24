    using NetOffice.OfficeApi.Enums;
    using NetOffice.PowerPointApi.Enums;
    using System;
    using PowerPoint = NetOffice.PowerPointApi;
    namespace ExportSlides
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (var app = PowerPoint.Application.GetActiveInstance())
                {
                    SelectSlideMasterLayoutOfActiveSlide(app);
                    ActiveSlideMasterLayoutByIndex(app.ActivePresentation, 4);
                }
            }
            private static void ActiveSlideMasterLayoutByIndex(PowerPoint.Presentation activePresentation, int customLayoutIndex)
            {
                activePresentation.Windows[1].ViewType = PpViewType.ppViewSlideMaster; //PpViewType.ppViewMasterThumbnails doesn't work for me for some reason
                activePresentation.SlideMaster.CustomLayouts[customLayoutIndex].Select();
            }
            private static void SelectSlideMasterLayoutOfActiveSlide(PowerPoint.Application app)
            {
                var activeWindow = app.ActiveWindow;
                var slideObj = activeWindow.View.Slide;
                if (slideObj.GetType() == typeof(PowerPoint.Slide))
                {
                    var slide = (PowerPoint.Slide)slideObj;
                    activeWindow.ViewType = PpViewType.ppViewSlideMaster; //PpViewType.ppViewMasterThumbnails doesn't work for me for some reason
                    slide.CustomLayout.Select();
                }
            }
        }
    }
