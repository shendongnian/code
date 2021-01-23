    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Shapes;
    using System.Windows.Threading;
    
    namespace WpfStackOverflow.MenuAsTreeView2
    {
        /// <summary>
        /// Interaction logic for TreeViewFloatingDisplay.xaml
        /// </summary>
        public partial class TreeViewFloatingDisplay : Menu
        {
            public TreeViewFloatingDisplay()
            {
                InitializeComponent();
            }
    
            protected override DependencyObject GetContainerForItemOverride()
            {
                return new MenuItemNew();
            }
        }
    
        public class MenuItemNew : MenuItem
        {
            #region Constructors
            static MenuItemNew()
            {
                MenuItem.IsSubmenuOpenProperty.OverrideMetadata(typeof(MenuItemNew),
                    new FrameworkPropertyMetadata(false, MenuItem.IsSubmenuOpenProperty.DefaultMetadata.PropertyChangedCallback, CoerceIsSubmenuOpen));           
            }      
    
            public MenuItemNew()
            {
                this.PreviewMouseLeftButtonDown += MenuItemNew_PreviewMouseLeftButtonDown;
            }
            #endregion
    
            #region Event Handlers
           
            void MenuItemNew_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                MenuItemNew curItem = sender as MenuItemNew;
                System.Diagnostics.Debug.WriteLine("Role = " + curItem.Role);
    
                Path pth = e.OriginalSource as Path;
                if (pth == null) return;
    
                DependencyObject parent = VisualTreeHelper.GetParent(pth);
                while (parent as MenuItemNew == null)
                    parent = VisualTreeHelper.GetParent(parent);
    
                MenuItemNew actualSource = parent as MenuItemNew;
    
                if (actualSource.Role == MenuItemRole.TopLevelHeader)
                {
                    IsExpanderClicked = !IsExpanderClicked;
                    actualSource.CoerceValue(MenuItemNew.IsSubmenuOpenProperty);
                }
    
                if (curItem.Role == MenuItemRole.SubmenuHeader)
                {
                    IsExpanderClicked = !IsExpanderClicked;
                    curItem.CoerceValue(MenuItemNew.IsSubmenuOpenProperty);
                }
            }
    
            #endregion
    
            #region IsExpanderClicked Dependency Property
    
            public bool IsExpanderClicked
            {
                get { return (bool)GetValue(IsExpanderClickedProperty); }
                set { SetValue(IsExpanderClickedProperty, value); }
            }
    
            // Using a DependencyProperty as the backing store for IsExpanderClicked.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty IsExpanderClickedProperty =
                DependencyProperty.Register("IsExpanderClicked", typeof(bool), typeof(MenuItemNew), new PropertyMetadata(false));
    
            #endregion
    
            #region Overrides
            protected override DependencyObject GetContainerForItemOverride()
            {
                return new MenuItemNew();
            }
            #endregion
    
            #region Dependency Property Callbacks
            private static object CoerceIsSubmenuOpen(DependencyObject d, object value)
            {
                MenuItemNew item = (MenuItemNew)d;
                
                if ((bool)value)
                {
                    if (item.IsMouseOver)
                    {
                        System.Diagnostics.Debug.WriteLine(item.IsExpanderClicked.ToString());
                        return item.IsExpanderClicked;
                    }
    
                    if (!item.IsLoaded)
                    {
                        item.Loaded += (s, e) =>
                        {
                            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Input, new DispatcherOperationCallback(delegate(object param)
                            {
                                item.CoerceValue(MenuItemNew.IsSubmenuOpenProperty);
                                return null;
                            }), null);
                        };
                        return false;
                    }
                }
                if (item.IsExpanderClicked)
                    return true;
    
                return value;
            }
            #endregion
        }
    }
