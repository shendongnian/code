    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace YourNamespace
    {
        /// <summary>
        /// Adjust parent control when child control got focus and virtual keyboard shown
        /// </summary>
        public class VirtualKeyboardHelper
        {
            bool _isParentAdjusted = false;
    
            const int DefaultShiftSize = 300;
            public int ShiftSize { get; set; } = DefaultShiftSize;
    
            [DllImport("user32.dll")]
            private static extern IntPtr FindWindow(String sClassName, String sAppName);
    
            static bool IsVirtualKeyboardShown()
            {
                var iHandle = (int)FindWindow("IPTIP_Main_Window", "");
                return (iHandle > 0);
            }
    
            private void DoSetAdjustmentOnFocus(UserControl owner, UIElement child)
            {            
                child.GotFocus += delegate
                {
                    var m = owner.Margin;
                    if (IsVirtualKeyboardShown())
                    {
                        owner.Margin = new Thickness(m.Left, m.Top - ShiftSize, m.Right, m.Bottom);
                        _isParentAdjusted = true;
                    }
                };
    
                child.LostFocus += delegate
                {
                    var m = owner.Margin;
                    if (_isParentAdjusted)
                        owner.Margin = new Thickness(m.Left, m.Top + ShiftSize, m.Right, m.Bottom);
                };
            }
    
            public static void SetAdjustmentOnFocus(UserControl owner, UIElement child, int shiftSize = DefaultShiftSize) 
                => new VirtualKeyboardHelper() { ShiftSize = shiftSize }.DoSetAdjustmentOnFocus(owner, child);
    
            public static void SetAdjustmentOnFocus(UserControl owner, List<UIElement> children)
            {
                foreach (var c in children)
                    SetAdjustmentOnFocus(owner, c);
            }
        }
    }
