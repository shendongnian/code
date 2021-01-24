    public class MessageContainerStyleSelector : StyleSelector
    {
        public Style SentStyle { get; set; }
        public Style ReceivedStyle { get; set; }
        public string Sender { get; set; }
        protected override Style SelectStyleCore(object item, DependencyObject container)
        {
            var message = item as Message;
            if (message != null)
            {
                return message.UserFrom.Equals(this.Sender, StringComparison.CurrentCultureIgnoreCase)
                           ? this.SentStyle
                           : this.ReceivedStyle;
            }
            return base.SelectStyleCore(item, container);
        }
    }
