    public class MyTextElement : Run { }
    public class MyRichTextBox : RichTextBox
    {
        public static DependencyProperty ItemContainerStyleProperty = DependencyProperty.Register("ItemContainerStyle", typeof(Style), typeof(MyRichTextBox), new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnItemContainerStyleChanged));
        public Style ItemContainerStyle
        {
            get
            {
                return (Style)GetValue(ItemContainerStyleProperty);
            }
            set
            {
                SetValue(ItemContainerStyleProperty, value);
            }
        }
        static void OnItemContainerStyleChanged(DependencyObject Object, DependencyPropertyChangedEventArgs e)
        {
            (Object as MyRichTextBox).OnItemContainerStyleChanged((Style)e.OldValue, (Style)e.NewValue);
        }
        protected virtual void OnItemContainerStyleChanged(Style OldValue, Style NewValue)
        {
            //Make sure the old style is gone
            if (OldValue != null)
                Resources.Remove(OldValue.TargetType);
            if (NewValue != null)
            {
                //This line does not attempt to utilize the specified style, but is stable
                //Resources.Add(NewValue.TargetType, new Style(NewValue.TargetType));
                //This line attempts to utilize the specified style, but is unstable
                Resources.Add(NewValue.TargetType, new Style(NewValue.TargetType, NewValue));
            }
        }
    }
----------
    <Controls:MyRichTextBox>
        <Controls:MyRichTextBox.ItemContainerStyle>
            <Style TargetType="{x:Type Controls:MyTextElement}">
                <Setter Property="Foreground" Value="Red" />
            </Style>
        </Controls:MyRichTextBox.ItemContainerStyle>
        <FlowDocument>
            <Paragraph>
                <Run Text="default" />
                <Controls:MyTextElement Text="red" />
            </Paragraph>
        </FlowDocument>
    </Controls:MyRichTextBox>
