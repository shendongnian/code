    public class PopoverDelegate : UIPopoverPresentationControllerDelegate
    {
        public delegate void DatePicked(NSDate date);
        UIDatePicker datePicker;
        DatePicked datePicked;
        public PopoverDelegate(UIDatePicker datePicker, DatePicked datePicked)
        {
            this.datePicked = datePicked;
            this.datePicker = datePicker;
        }
        public override UIModalPresentationStyle GetAdaptivePresentationStyle(UIPresentationController forPresentationController)
        {
            return UIModalPresentationStyle.None;
        }
        public override void DidDismissPopover(UIPopoverPresentationController popoverPresentationController)
        {
            datePicked(datePicker.Date);
        }
    }
