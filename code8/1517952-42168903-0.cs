    public void PrintItemsTo(ItemsControl ic, String jobName)
        {
            PrintDialog dlg = new PrintDialog();
            dlg.UserPageRangeEnabled = true;
            if (dlg.ShowDialog().GetValueOrDefault())
            {
                PageRange range = dlg.PageRange;
                //    range check - user selection starts from 1
                if (range.PageTo > ic.Items.Count)
                    range.PageTo = ic.Items.Count;
                dlg.PrintQueue.CurrentJobSettings.Description = jobName;
                XpsDocumentWriter xdw = PrintQueue.CreateXpsDocumentWriter(dlg.PrintQueue);
                if (dlg.UserPageRangeEnabled == false || range.PageTo < range.PageFrom)
                    WriteAllItems(ic, xdw);
                else
                    WriteSelectedItems(ic, xdw, range);
            }
        }
        private void WriteAllItems(ItemsControl ic, XpsDocumentWriter xdw)
        {
            PageRange range = new PageRange(1, ic.Items.Count);
            WriteSelectedItems(ic, xdw, range);
        }
        private void WriteSelectedItems(ItemsControl ic, XpsDocumentWriter xdw, PageRange range)
        {
            IItemContainerGenerator generator = ic.ItemContainerGenerator;
            // write visuals using a batch operation
            VisualsToXpsDocument collator = (VisualsToXpsDocument)xdw.CreateVisualsCollator();
            collator.BeginBatchWrite();
            if (WritePageRange(collator, generator, range))
                collator.EndBatchWrite();
        }
        private bool WritePageRange(VisualsToXpsDocument collator, IItemContainerGenerator generator, PageRange range)
        {
            //    Get the generator position of the first data item
            //    PageRange reflects user's selection starts from 1
            GeneratorPosition startPos = generator.GeneratorPositionFromIndex(range.PageFrom - 1);
            //    If PageFrom > PageTo, print in reverse order
            //    UPDATE: never occurs; PrintDialog always 'normalises' the PageRange
            GeneratorDirection direction = (range.PageFrom <= range.PageTo) ? GeneratorDirection.Forward : GeneratorDirection.Backward;
            using (generator.StartAt(startPos, direction, true))
            {
                for (int numPages = Math.Abs(range.PageTo - range.PageFrom) + 1; numPages > 0; --numPages)
                {
                    bool newlyRealized;
                    // Get or create the child
                    UIElement next = generator.GenerateNext(out newlyRealized) as UIElement;
                    if (newlyRealized)
                    {
                        generator.PrepareItemContainer(next);
                    }
                    //    The collator doesn't like ContentPresenters and produces blank pages
                    //    for pages 2-n.  Finding the child of the ContentPresenter and writing
                    //    that solves seems to solve the problem
                    if (next is ContentPresenter)
                    {
                        ContentPresenter presenter = (ContentPresenter)next;
                        presenter.UpdateLayout();
                        presenter.ApplyTemplate();    //    not sure if this is necessary
                        DependencyObject child = VisualTreeHelper.GetChild(presenter, 0);
                        if (child is UIElement)
                            next = (UIElement)child;
                    }
                    try
                    {
                        collator.Write(next);
                    }
                    catch
                    {
                        //    if user prints to Microsoft XPS Document Writer
                        //    and cancels the SaveAs dialog, we get an exception.
                        return false;
                    }
                }
            }
            return true;
        }
