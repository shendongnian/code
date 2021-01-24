    public class MyTextElement : Button
    {
        public MyTextElement() : base()
        {
        }
    }
    public class MyRichTextBox : RichTextBox
    {
        public static DependencyProperty ItemContainerStyleProperty = DependencyProperty.Register("ItemContainerStyle", 
            typeof(Style), typeof(MyRichTextBox), new FrameworkPropertyMetadata(default(Style), 
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnItemContainerStyleChanged));
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
                Resources.Add(NewValue.TargetType, new Style(NewValue.TargetType, NewValue));
            }
        }
    }
----------
    <Controls:MyRichTextBox IsDocumentEnabled="True">
        <Controls:MyRichTextBox.ItemContainerStyle>
            <Style TargetType="{x:Type Controls:MyTextElement}">
                <Setter Property="Foreground" Value="Red" />
            </Style>
        </Controls:MyRichTextBox.ItemContainerStyle>
        <FlowDocument>
            <Paragraph>
                <InlineUIContainer>
                    <Controls:MyTextElement Content="My Content"/>
                </InlineUIContainer>
            </Paragraph >
        </FlowDocument>
    </Controls:MyRichTextBox>
