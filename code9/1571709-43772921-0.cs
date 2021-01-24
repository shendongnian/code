     public enum InteractionMode
     {
      None,
      Initiative,
      Passive
     }
     public sealed partial class CustomUserControl : UserControl
     {
         public CustomUserControl()
         {
             this.InitializeComponent();
         }
     public InteractionMode ActiveInteractionMode
     {
         get { return (InteractionMode)GetValue(ActiveInteractionModeProperty); }
         set { SetValue(ActiveInteractionModeProperty, value); }
     }
     public static readonly DependencyProperty ActiveInteractionModeProperty =
         DependencyProperty.Register("ActiveInteractionMode", typeof(InteractionMode), typeof(CustomUserControl), new PropertyMetadata(InteractionMode.None, CanvasMapControl_InteractionModeChanged));
     private static void CanvasMapControl_InteractionModeChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
     {
         if (args.OldValue != args.NewValue)
         {
             ((CustomUserControl)obj).InteractionModeInternal = (InteractionMode)args.NewValue;
         }
     }
     private InteractionMode _interactionModeInternal;
     private InteractionMode InteractionModeInternal
     {
         get
         {
             return _interactionModeInternal;
         }
         set
         {
             _interactionModeInternal = value;
             OnInteractionModeInternalChanged(value);
         }
     }
     private void OnInteractionModeInternalChanged(InteractionMode interactionMode)
     {
         System.Diagnostics.Debug.WriteLine($"InternalInteractionMode changed to {interactionMode}");
     }
 
