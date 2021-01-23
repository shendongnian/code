using System;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
#if !NETSTANDARD
using System.Windows.Controls;
#else
using Xamarin.Forms;
#endif
public static class ButtonExtensions
{
    public static void PerformClick(this Button sourceButton)
    {
        // Check parameters
        if (sourceButton == null)
            throw new ArgumentNullException(nameof(sourceButton));
        // 1.) Raise the Click-event
#if !NETSTANDARD
        sourceButton.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
#else
        sourceButton.RaiseEventViaReflection(nameof(sourceButton.Clicked), EventArgs.Empty);
#endif
        // 2.) Execute the command, if bound and can be executed
        ICommand boundCommand = sourceButton.Command;
        if (boundCommand != null)
        {
            object parameter = sourceButton.CommandParameter;
            if (boundCommand.CanExecute(parameter) == true)
                boundCommand.Execute(parameter);
        }
    }
#if NETSTD
    private static void RaiseEventViaReflection<TEventArgs>(this object source, string eventName, TEventArgs eventArgs) where TEventArgs : EventArgs
    {
        var eventDelegate = (MulticastDelegate)source.GetType().GetField(eventName, BindingFlags.Instance | BindingFlags.NonPublic).GetValue(source);
        if (eventDelegate == null)
            return;
        foreach (var handler in eventDelegate.GetInvocationList())
        {
#if !(NETSTANDARD1_6 || NETSTANDARD1_5 || NETSTANDARD1_4 || NETSTANDARD1_3 || NETSTANDARD1_2 || NETSTANDARD1_1 || NETSTANDARD1_0)
            handler.Method?.Invoke(handler.Target, new object[] { source, eventArgs });
#else
            handler.GetMethodInfo()?.Invoke(handler.Target, new object[] { source, eventArgs });
#endif
        }
    }
#endif
}
