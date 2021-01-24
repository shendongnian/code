        private void OnMyListViewContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
        {
            var containerVisual = ElementCompositionPreview.GetElementVisual(args.ItemContainer);
            if (args.InRecycleQueue)
            {
                containerVisual.ImplicitAnimations = null;
            }
            else
            {
                // EnableImplicitAnimation() is available at
                // https://github.com/JustinXinLiu/Continuity/blob/0015a96897c138e09d8604267df46da936b66838/Continuity/Extensions/CompositionExtensions.Implicit.cs#L144
                containerVisual.EnableImplicitAnimation(VisualPropertyType.Offset, 400.0f);
            }
        }
