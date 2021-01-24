    public static class Extensions
    {
      // This helper function is essentially the same as this answer:
      // https://stackoverflow.com/a/14132711/4184842
      //
      // It adds an additional forced 1ms delay to let the UI thread
      // catch up.
      public static Task FinishLayoutAsync(this FrameworkElement element)
      {
        TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
        // Setup handler that will be raised when layout has completed.
        EventHandler<object> handler = null;
        handler = (s, a) =>
        {
          element.LayoutUpdated -= handler;
          tcs.SetResult(true);
        };
        element.LayoutUpdated += handler;
        // Await at least 1 ms (to force UI pump) and until the Task is completed
        // If you don't wait the 1ms then you can get a 'layout cycle detected' error
        // from the XAML runtime.
        return Task.WhenAll(new[] { Task.Delay(1), tcs.Task });
      }
    }
    public sealed partial class MainPage : Page
    {
      public MainPage()
      {
        InitializeComponent();
        // Simple animation to show the UI is not frozen
        BadUiAnimation_DontDoThis();
      }
      // Very VERY bad way of doing animation, but it shows
      // that the UI is still responsive. Normally you should
      // use StoryBoards to do animation.
      void BadUiAnimation_DontDoThis()
      {
        DispatcherTimer dt = new DispatcherTimer();
        dt.Interval = TimeSpan.FromMilliseconds(33);
        int delta = 4;
        const int width = 20;
        dt.Tick += (s, a) =>
        {
          var leftOffset = animation.Margin.Left;
          if (leftOffset + delta < 0)
          {
            delta *= -1;
            leftOffset = 0;
          }
          else if (leftOffset + delta + width > container.ActualWidth)
          {
            delta *= -1;
            leftOffset = container.ActualWidth - width;
          }
          else
          {
            leftOffset += delta;
          }
          animation.Margin = new Thickness(leftOffset, 5, 0, 5);
        };
        dt.Start();
      }
      private async void Go(object sender, RoutedEventArgs e)
      {
        // Helper function
        void AppendSimpleString(string s)
        {
          RichTextBlock rtb = new RichTextBlock();
          rtb.Blocks.Add(CreateParagraphWithText(s));
          thePanel.Children.Add(rtb);
        }
        // Another helper function
        Paragraph CreateParagraphWithText(string s)
        {
          var p = new Paragraph();
          var r = new Run();
          r.Text = s;
          p.Inlines.Add(r);
          return p;
        }
        // Disable the button so you can't click it again until the 
        // insertion is over
        (sender as Button).IsEnabled = false;
        thePanel.Children.Clear();
        AppendSimpleString($"Begin...{Environment.NewLine}");
        // Generate some dummy strings to add to the page
        var strings = new StringBuilder();
        for (int i = 0; i < 1000; i++)
          strings.Append($"This is line {i + 1}{Environment.NewLine}");
        string text = strings.ToString();
        // Create initial block with far too much text in it
        var source = new RichTextBlock();
        source.MaxHeight = 100;
        source.Blocks.Add(CreateParagraphWithText(text));
        thePanel.Children.Add(source);
        // Create the first overflow and connect it to the original textblock
        var prev = new RichTextBlockOverflow
        {
          MaxHeight = 100,
          Margin = new Thickness(0, 10, 0, 0)
        };
        thePanel.Children.Add(prev);
        source.OverflowContentTarget = prev;
        // Wait for layout to complete so we can check the 
        // HasOverflowContent property
        await prev.FinishLayoutAsync();
        // Keep creating more overflows until there is no content left
        while (prev.HasOverflowContent)
        {
          var next = new RichTextBlockOverflow
          {
            MaxHeight = 100,
            Margin = new Thickness(0, 10, 0, 0)
          };
          thePanel.Children.Add(next);
          prev.OverflowContentTarget = next;
          // Wait for layout to complete, which will compute whether there
          // is additional overflow (or not)
          await prev.FinishLayoutAsync();
          prev = next;
        };
        AppendSimpleString($"Done!{Environment.NewLine}");
        // Enable interaction with the button again
        (sender as Button).IsEnabled = true;
      }
    }
