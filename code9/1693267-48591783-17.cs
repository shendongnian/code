    using System.Linq;
    
    using Xamarin.Forms;
    
    namespace CustomStepper
    {
        public static class StepperColorEffect
        {
            public static readonly BindableProperty ColorProperty =
                BindableProperty.CreateAttached(nameof(Color),
                    typeof(Color),
                    typeof(Stepper),
                    Color.Gray,
                    propertyChanged: OnStepperColorChanged);
    
            public static Color GetColor(BindableObject view) => (Color)view.GetValue(ColorProperty);
    
            public static void SetColor(BindableObject view, Color value) => view.SetValue(ColorProperty, value);
    
            static void OnStepperColorChanged(BindableObject bindable, object oldValue, object newValue) => UpdateEffect(bindable);
    
            static void UpdateEffect(BindableObject bindable)
            {
                var stepper = (Stepper)bindable:
                RemoveEffect(stepper);
                stepper.Effects.Add(new StepperColorRoutingEffect());
            }
    
            static void RemoveEffect(Stepper entry)
            {
                var effectToRemoveList = entry.Effects.OfType<StepperColorRoutingEffect>();
    
                foreach (var entryReturnTypeEffect in effectToRemoveList)
                    entry.Effects.Remove(entryReturnTypeEffect);
            }
        }
    
        class StepperColorRoutingEffect : RoutingEffect
        {
            public StepperColorRoutingEffect() : base("CustomStepper.StepperColorEffect")
            {
            }
        }
    }
