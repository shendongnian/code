    public partial class EditableTextBlock : UserControl
    {
        [Bindable(true)]
        public TextAlignment TextAlignment
        {
            get { return (TextAlignment)GetValue(TextAlignmentProperty); }
            set { SetValue(TextAlignmentProperty, value); }
        }
        public static readonly DependencyProperty TextAlignmentProperty =
            DependencyProperty.Register(
            ((EditableTextBlock)null).GetMemberName(x => x.TextAlignment),
            typeof(TextAlignment),
            typeof(EditableTextBlock),
            new FrameworkPropertyMetadata()
            {
                DefaultValue = TextAlignment.Center,
                Inherits = true
            });
     //....
    }
.
     <TextBlock TextAlignment="{Binding RelativeSource={RelativeSource AncestorType=local:EditableTextBlock}, Path=TextAlignment}" />
