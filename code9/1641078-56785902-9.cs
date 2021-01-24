    <UserControl x:Class="WPFTestControlMoveMouse.VisualBlock"
                 xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                 xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                 xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
                 xmlns:d="http://schemas.microsoft.com/expression/blend/2008" 
                 xmlns:local="clr-namespace:WPFTestControlMoveMouse"
                 mc:Ignorable="d" 
                 Width="300" Height="200" MouseDown="UserControl_MouseDown" MouseUp="UserControl_MouseUp" MouseMove="UserControl_MouseMove">
        <Grid>
            <Border BorderBrush="Black" BorderThickness="1" Background="Silver" />
            <TextBlock FontSize="48" HorizontalAlignment="Center" VerticalAlignment="Center">Hi there!!</TextBlock>
        </Grid>
    </UserControl>
---
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    namespace WPFTestControlMoveMouse
    {
        /// <summary>
        /// Interaction logic for VisualBlock.xaml
        /// </summary>
        public partial class VisualBlock : UserControl
        {
            private Point _positionInBlock;
            public VisualBlock()
            {
                InitializeComponent();
            }
            private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
            {
                // when the mouse is down, get the position within the current control. (so the control top/left doesn't move to the mouse position)
                _positionInBlock = Mouse.GetPosition(this);
                // capture the mouse (so the mouse move events are still triggered (even when the mouse is not above the control)
                this.CaptureMouse();
            }
            private void UserControl_MouseMove(object sender, MouseEventArgs e)
            {
                // if the mouse is captured. you are moving it. (there is your 'real' boolean)
                if (this.IsMouseCaptured)
                {
                    // get the parent container
                    var container = VisualTreeHelper.GetParent(this) as UIElement;
                    // get the position within the container
                    var mousePosition = e.GetPosition(container);
                    // move the usercontrol.
                    this.RenderTransform = new TranslateTransform(mousePosition.X - _positionInBlock.X, mousePosition.Y - _positionInBlock.Y);
                }
            }
            private void UserControl_MouseUp(object sender, MouseButtonEventArgs e)
            {
                // release this control.
                this.ReleaseMouseCapture();
            }
        }
    }
