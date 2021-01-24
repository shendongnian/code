    [TemplatePart(Name = PartBubbleText, Type = typeof(TextBlock))]
    public sealed partial class SpeechBubbleControl : Control
    {
    	private const string PartBubbleText = "BubbleText";
    	public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof(Text), typeof(string), typeof(SpeechBubbleControl), new PropertyMetadata(""));
    
    	public SpeechBubbleControl()
    	{
    		DefaultStyleKey = typeof(SpeechBubbleControl);
    	}
    
    	public string Text
    	{
    		get { return GetValue(TextProperty).ToString(); }
    		set { SetValue(TextProperty, value); }
    	} 
    }
