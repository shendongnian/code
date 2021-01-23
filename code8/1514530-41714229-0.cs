    class VirtualizingTilePanel : VirtualizingPanel, IScrollInfo,    INotifyPropertyChanged
    {
        private readonly Logger _log = LogManager.GetCurrentClassLogger();
        public VirtualizingTilePanel()
        {
            // For use in the IScrollInfo implementation
            this.RenderTransform = _trans;
        }
        // Dependency property that controls the size of the child elements
        public static readonly DependencyProperty ChildSizeProperty
           = DependencyProperty.RegisterAttached("ChildSize", typeof(double), typeof(VirtualizingTilePanel),
              new FrameworkPropertyMetadata(Double.PositiveInfinity, FrameworkPropertyMetadataOptions.AffectsMeasure |
              FrameworkPropertyMetadataOptions.AffectsArrange));
        public static readonly DependencyProperty ItemHeightProperty = DependencyProperty.Register("ItemHeight", typeof(double), typeof(VirtualizingTilePanel), new FrameworkPropertyMetadata(double.PositiveInfinity));
        public static readonly DependencyProperty ItemWidthProperty = DependencyProperty.Register("ItemWidth", typeof(double), typeof(VirtualizingTilePanel), new FrameworkPropertyMetadata(double.PositiveInfinity));
        public static readonly DependencyProperty OrientationProperty = StackPanel.OrientationProperty.AddOwner(typeof(VirtualizingTilePanel), new FrameworkPropertyMetadata(Orientation.Horizontal));
        public static readonly DependencyProperty HorizontalContentAlignmentProperty = ListBox.HorizontalContentAlignmentProperty.AddOwner(typeof(VirtualizingTilePanel), new FrameworkPropertyMetadata(HorizontalAlignment.Center));
        // Accessor for the child size dependency property
        public double ChildSize
        {
            get { return (double)GetValue(ChildSizeProperty); }
            set { SetValue(ChildSizeProperty, value); }
        }
        // Accessor for the child size dependency property
        private double _childDesiredWidth = double.PositiveInfinity;
        public double ChildDesiredWidth
        {
            get { return _childDesiredWidth; }
            set { _childDesiredWidth = value; }
        }
        // Accessor for the child size dependency property
        private double _childDesiredHeigth = double.PositiveInfinity;
        public double ChildDesiredHeigth
        {
            get { return _childDesiredHeigth; }
            set { _childDesiredHeigth = value; }
        }
        // Current First visible item
        private int _firstVisibleItem = 0;
        public int FirstVisibleItem
        {
            get { return _firstVisibleItem; }
            set
            {
                _firstVisibleItem = value;
                OnPropertyChanged("FirstVisibleItem");
            }
        }
        // Current Last visible item
        private int _lastVisibleItem = 0;
        public int LastVisibleItem
        {
            get { return _lastVisibleItem; }
            set
            {
                _lastVisibleItem = value;
                OnPropertyChanged("LastVisibleItem");
            }
        }
        /// <summary>
        /// Measure the children
        /// </summary>
        /// <param name="availableSize">Size available</param>
        /// <returns>Size desired</returns>
        protected override Size MeasureOverride(Size availableSize)
        {
            UpdateScrollInfo(availableSize);
            // Figure out range that's visible based on layout algorithm
            int firstVisibleItemIndex, lastVisibleItemIndex;
            GetVisibleRange(out firstVisibleItemIndex, out lastVisibleItemIndex);
            FirstVisibleItem = firstVisibleItemIndex;
            LastVisibleItem = lastVisibleItemIndex;
            // We need to access InternalChildren before the generator to work around a bug
            UIElementCollection children = this.InternalChildren;            
            IItemContainerGenerator generator = this.ItemContainerGenerator;
            if (children == null)
                throw new ArgumentNullException("InternalChildren");
            else if (generator == null)
                throw new ArgumentNullException("ItemContainerGenerator");
            // Get the generator position of the first visible data item
            GeneratorPosition startPos = generator.GeneratorPositionFromIndex(firstVisibleItemIndex);
            if (startPos == null)
                throw new ArgumentNullException("GeneratorPositionFromIndex");
            // Get index where we'd insert the child for this position. If the item is realized
            // (position.Offset == 0), it's just position.Index, otherwise we have to add one to
            // insert after the corresponding child
            int childIndex = (startPos.Offset == 0) ? startPos.Index : startPos.Index + 1;
            this.IsItemsHost = true;
            ItemsControl itemsControl = ListBox.GetItemsOwner(this);
            if (itemsControl == null)
            {
                _log.Error("class VirtualizingTilePanel, method MeasureOverride ->ListBox.GetItemsOwner(this) returned null");
                return availableSize;
            }
            int itemCount = itemsControl.HasItems ? itemsControl.Items.Count : 0;
            int current = firstVisibleItemIndex;
            using (generator.StartAt(startPos, GeneratorDirection.Forward, true))
            {
                bool stop = false;
                double currentX = 0;
                double currentY = 0;
                double maxItemSize = 0;
                while (current < itemCount)
                {
                    bool newlyRealized;
                    // Get or create the child
                    UIElement child = generator.GenerateNext(out newlyRealized) as UIElement;
                    if (newlyRealized)
                    {
                        // Figure out if we need to insert the child at the end or somewhere in the middle
                        if (childIndex >= children.Count)
                        {
                            base.AddInternalChild(child);
                        }
                        else
                        {
                            base.InsertInternalChild(childIndex, child);
                        }
                        generator.PrepareItemContainer(child);
                    }
                    else
                    {
                        // The child has already been created, let's be sure it's in the right spot
                        Debug.Assert(child == children[childIndex], "Wrong child was generated");
                        //_log.Warn("Wrong child was generated: {0}", childIndex);
                    }
                    // Measurements will depend on layout algorithm
                    child.Measure(GetChildSize());
                    var childDesiredSize = child.DesiredSize;
                    ChildDesiredHeigth = childDesiredSize.Height;
                    ChildDesiredWidth = childDesiredSize.Width;
                    Rect childRect = new Rect(new Point(currentX, currentY), childDesiredSize);
                    maxItemSize = Math.Max(maxItemSize, childRect.Height);
                    if (childRect.Right > availableSize.Width) //wrap to a new line
                    {
                        currentY = currentY + maxItemSize;
                        currentX = 0;
                        maxItemSize = childRect.Height;
                        childRect.X = currentX;
                        childRect.Y = currentY;
                    }
                    if (currentY > (availableSize.Height + ChildDesiredHeigth))
                        stop = true;
                    currentX = childRect.Right;
                    if (stop)
                        break;
                    current++;
                    childIndex++;
                }
            }
            // Note: this could be deferred to idle time for efficiency
            CleanUpItems(firstVisibleItemIndex, current - 1);
            return availableSize;
        }
        /// <summary>
        /// Arrange the children
        /// </summary>
        /// <param name="finalSize">Size available</param>
        /// <returns>Size used</returns>
        protected override Size ArrangeOverride(Size finalSize)
        {
            IItemContainerGenerator generator = this.ItemContainerGenerator;
            UpdateScrollInfo(finalSize);
            for (int i = 0; i < this.Children.Count; i++)
            {
                UIElement child = this.Children[i];
                // Map the child offset to an item offset
                int itemIndex = generator.IndexFromGeneratorPosition(new GeneratorPosition(i, 0));
                ArrangeChild(itemIndex, child, finalSize);
            }
            return finalSize;
        }
        /// <summary>
        /// Revirtualize items that are no longer visible
        /// </summary>
        /// <param name="minDesiredGenerated">first item index that should be visible</param>
        /// <param name="maxDesiredGenerated">last item index that should be visible</param>
        private void CleanUpItems(int minDesiredGenerated, int maxDesiredGenerated)
        {
            UIElementCollection children = this.InternalChildren;
            IItemContainerGenerator generator = this.ItemContainerGenerator;
            for (int i = children.Count - 1; i >= 0; i--)
            {
                GeneratorPosition childGeneratorPos = new GeneratorPosition(i, 0);
                int itemIndex = generator.IndexFromGeneratorPosition(childGeneratorPos);
                if (itemIndex < minDesiredGenerated || itemIndex > maxDesiredGenerated)
                {
                    generator.Remove(childGeneratorPos, 1);
                    RemoveInternalChildRange(i, 1);
                }
            }
        }
        /// <summary>
        /// When items are removed, remove the corresponding UI if necessary
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected override void OnItemsChanged(object sender, ItemsChangedEventArgs args)
        {
            switch (args.Action)
            {
                case NotifyCollectionChangedAction.Remove:
                case NotifyCollectionChangedAction.Replace:
                case NotifyCollectionChangedAction.Move:
                    RemoveInternalChildRange(args.Position.Index, args.ItemUICount);
                    break;
            }
        }
        #region Layout specific code
        // I've isolated the layout specific code to this region. If you want to do something other than tiling, this is
        // where you'll make your changes
        /// <summary>
        /// Calculate the extent of the view based on the available size
        /// </summary>
        /// <param name="availableSize">available size</param>
        /// <param name="itemCount">number of data items</param>
        /// <returns></returns>
        private Size CalculateExtent(Size availableSize, int itemCount)
        {
            int childrenPerRow = CalculateChildrenPerRow(availableSize);
            // See how big we are
            return new Size(childrenPerRow * ChildDesiredWidth,
                ChildDesiredHeigth * Math.Ceiling((double)itemCount / childrenPerRow));
        }
        /// <summary>
        /// Get the range of children that are visible
        /// </summary>
        /// <param name="firstVisibleItemIndex">The item index of the first visible item</param>
        /// <param name="lastVisibleItemIndex">The item index of the last visible item</param>
        private void GetVisibleRange(out int firstVisibleItemIndex, out int lastVisibleItemIndex)
        {
            int childrenPerRow = CalculateChildrenPerRow(_extent);
            if (ChildDesiredWidth == double.PositiveInfinity)
                firstVisibleItemIndex = 0;
            else
                firstVisibleItemIndex = (int)Math.Floor(_offset.Y / ChildDesiredHeigth) * childrenPerRow;
            lastVisibleItemIndex = (int)Math.Ceiling((_offset.Y + _viewport.Height) / ChildDesiredHeigth) * childrenPerRow - 1;
            ItemsControl itemsControl = ItemsControl.GetItemsOwner(this);
            int itemCount = itemsControl.HasItems ? itemsControl.Items.Count : 0;
            if (lastVisibleItemIndex >= itemCount)
                lastVisibleItemIndex = itemCount - 1;
        }
        /// <summary>
        /// Get the size of the children. We assume they are all the same
        /// </summary>
        /// <returns>The size</returns>
        private Size GetChildSize()
        {
            return new Size(ChildDesiredWidth, ChildDesiredHeigth);
        }
        /// <summary>
        /// Position a child
        /// </summary>
        /// <param name="itemIndex">The data item index of the child</param>
        /// <param name="child">The element to position</param>
        /// <param name="finalSize">The size of the panel</param>
        private void ArrangeChild(int itemIndex, UIElement child, Size finalSize)
        {
            int childrenPerRow = CalculateChildrenPerRow(finalSize);
            int row = itemIndex / childrenPerRow;
            int column = itemIndex % childrenPerRow;
            //coorrect horizontal content
            var itemRect = new Rect(column * ChildDesiredWidth, row * ChildDesiredHeigth, ChildDesiredWidth, ChildDesiredHeigth);
            ItemsControl itemsControl = ItemsControl.GetItemsOwner(this);
            int itemCount = itemsControl.HasItems ? itemsControl.Items.Count : 0;
            if(itemCount > 1)
            {
                var correction = Math.Ceiling((finalSize.Width - childrenPerRow * ChildDesiredWidth) / 2);
                if (correction < child.DesiredSize.Width)
                {
                    itemRect.X += correction;
                }
            }  
            child.Arrange(itemRect);
        }
        /// <summary>
        /// Helper function for tiling layout
        /// </summary>
        /// <param name="availableSize">Size available</param>
        /// <returns></returns>
        private int CalculateChildrenPerRow(Size availableSize)
        {
            // Figure out how many children fit on each row
            //int childrenPerRow;
            //if (availableSize.Width == Double.PositiveInfinity)
            //    childrenPerRow = 1;
            //else
            //    childrenPerRow = Math.Max(1, (int)Math.Floor(availableSize.Width / ChildDesiredWidth));
            return Math.Max(1, (int)Math.Floor(availableSize.Width / ChildDesiredWidth)); ;
        }
        #endregion
        #region IScrollInfo implementation
        // See Ben Constable's series of posts at http://blogs.msdn.com/bencon/
        private void UpdateScrollInfo(Size availableSize)
        {
            // See how many items there are
            ItemsControl itemsControl = ItemsControl.GetItemsOwner(this);
            int itemCount = itemsControl.HasItems ? itemsControl.Items.Count : 0;
            Size extent = CalculateExtent(availableSize, itemCount);
            // Update extent
            if (extent != _extent)
            {
                _extent = extent;
            }
            //// Update viewport
            if (availableSize != _viewport)
            {
                _viewport = availableSize;
            }
            if (_owner != null)
            {
                _owner.InvalidateScrollInfo();
            }
        }
        public ScrollViewer ScrollOwner
        {
            get { return _owner; }
            set { _owner = value; }
        }
        public bool CanHorizontallyScroll
        {
            get { return _canHScroll; }
            set { _canHScroll = value; }
        }
        public bool CanVerticallyScroll
        {
            get { return _canVScroll; }
            set { _canVScroll = value; }
        }
        public double HorizontalOffset
        {
            get { return _offset.X; }
        }
        public double VerticalOffset
        {
            get { return _offset.Y; }
        }
        public double ExtentHeight
        {
            get { return _extent.Height; }
        }
        public double ExtentWidth
        {
            get { return _extent.Width; }
        }
        public double ViewportHeight
        {
            get { return _viewport.Height; }
        }
        public double ViewportWidth
        {
            get { return _viewport.Width; }
        }
        public void LineUp()
        {
            SetVerticalOffset(this.VerticalOffset - SCROLL_STEP);
        }
        public void LineDown()
        {
            SetVerticalOffset(this.VerticalOffset + SCROLL_STEP);
        }
        public void PageUp()
        {
            SetVerticalOffset(this.VerticalOffset - _viewport.Height);
        }
        public void PageDown()
        {
            SetVerticalOffset(this.VerticalOffset + _viewport.Height);
        }
        public void MouseWheelUp()
        {
            SetVerticalOffset(this.VerticalOffset - SCROLL_STEP);
        }
        public void MouseWheelDown()
        {
            SetVerticalOffset(this.VerticalOffset + SCROLL_STEP);
        }
        public void LineLeft()
        {
            throw new InvalidOperationException();
        }
        public void LineRight()
        {
            throw new InvalidOperationException();
        }
        public Rect MakeVisible(Visual visual, Rect rectangle)
        {
            return new Rect();
        }
        public void MouseWheelLeft()
        {
            throw new InvalidOperationException();
        }
        public void MouseWheelRight()
        {
            throw new InvalidOperationException();
        }
        public void PageLeft()
        {
            throw new InvalidOperationException();
        }
        public void PageRight()
        {
            throw new InvalidOperationException();
        }
        public void SetHorizontalOffset(double offset)
        {
            throw new InvalidOperationException();
        }
        public void SetVerticalOffset(double offset)
        {
            if (offset < 0 || _viewport.Height >= _extent.Height)
            {
                offset = 0;
            }
            else
            {
                if (offset + _viewport.Height >= _extent.Height)
                {
                    offset = _extent.Height - _viewport.Height;
                }
            }
            _offset.Y = offset;
            if (_owner != null)
                _owner.InvalidateScrollInfo();
            _trans.Y = -offset;
            // Force us to realize the correct children           
            InvalidateMeasure();
        }
        private TranslateTransform _trans = new TranslateTransform();
        private ScrollViewer _owner;
        private bool _canHScroll = false;
        private bool _canVScroll = false;
        private Size _extent = new Size(0, 0);
        private Size _viewport = new Size(0, 0);
        private Point _offset;
        private const int SCROLL_STEP = 60;
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
