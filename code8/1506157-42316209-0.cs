    Flow = new FlowListView()
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FlowColumnCount = 3,
                FlowColumnTemplate = new DataTemplate(typeof(FlowCellImage)),
                FlowTappedBackgroundDelay = 250,
                FlowTappedBackgroundColor = Color.Gray,
                SeparatorVisibility = SeparatorVisibility.Default,
                IsPullToRefreshEnabled = true,
                HasUnevenRows = true,
                //Margin = thickness
            };
