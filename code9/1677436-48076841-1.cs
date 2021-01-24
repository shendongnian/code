	public class VisualStateCondition
    {
        /// <summary>
        /// The PropertyName to look for in the associated object's <see cref="FrameworkElement.DataContext"/>.
        /// </summary>
        public string PropertyName { get; set; }
        /// <summary>
        /// The Value to check for equality.
        /// </summary>
        public object Value { get; set; }
        /// <summary>
        /// The <see cref="VisualState.Name"/> that is desired for the condition.
        /// </summary>
        public string DesiredState { get; set; }
    }
