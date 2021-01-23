    using System;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Media;
    using System.Windows.Threading;
    
    namespace BrokenRichTextBox
    {
        class FixedCustomRichTextBox : RichTextBox
        {
            private bool _didAddLayoutUpdatedEvent = false;
    
            public FixedCustomRichTextBox() : base()
            {
                UpdateAdorner();
                if (!_didAddLayoutUpdatedEvent)
                {
                    _didAddLayoutUpdatedEvent = true;
                    LayoutUpdated += updateAdorner;
                }
            }
    
            public void UpdateAdorner()
            {
                updateAdorner(null, null);
            }
    
            // Fixing missing caret bug code adjusted from: http://stackoverflow.com/questions/5180585/viewbox-makes-richtextbox-lose-its-caret
            private void updateAdorner(object sender, EventArgs e)
            {
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    Selection.GetType().GetMethod("System.Windows.Documents.ITextSelection.UpdateCaretAndHighlight", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(
                        Selection, null);
                    var caretElement = Selection.GetType().GetProperty("CaretElement", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(Selection, null);
                    if (caretElement == null)
                        return;
                    var caretSubElement = caretElement.GetType().GetField("_caretElement", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(caretElement) as UIElement;
                    if (caretSubElement == null) return;
                    // Scale slightly differently if in italic just so it looks a little bit nicer
                    bool isItalic = (bool)caretElement.GetType().GetField("_italic", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(caretElement);
                    double scaleX = 1;
                    if (!isItalic)
                        scaleX = (1 / ScaleX);
                    else
                        scaleX = 0.685;// output;
                    double scaleY = 1;
                    var scaleTransform = new ScaleTransform(scaleX, scaleY);
                    caretSubElement.RenderTransform = scaleTransform; // The line of trouble
                    updateSpellingErrors(CaretPosition);
                }), DispatcherPriority.ContextIdle);
            }
    
            private void checkSpelling(TextPointer pointer, string currentWord)
            {
                if (pointer != null)
                {
                    string otherText = WordBreaker.GetWordRange(pointer).Text;
                    if (currentWord != otherText || currentWord == "" || otherText == "")
                    {
                        GetSpellingError(pointer);
                    }
                }
            }
    
            private void checkSpelling(Paragraph paragraph, string currentWord)
            {
                if (paragraph != null)
                {
                    checkSpelling(paragraph.ContentStart.GetPositionAtOffset(3, LogicalDirection.Forward), currentWord);
                    checkSpelling(paragraph.ContentEnd.GetPositionAtOffset(-3, LogicalDirection.Backward), currentWord);
                }
            }
    
            private void updateSpellingErrors(TextPointer position)
            {
                string currentWord = GetCurrentWord();
    
                // Update first and last words of previous and next paragraphs
                var previousParagraph = position.Paragraph?.PreviousBlock as Paragraph;
                checkSpelling(previousParagraph, currentWord);
                var nextParagraph = position.Paragraph?.NextBlock as Paragraph;
                checkSpelling(nextParagraph, currentWord);
    
                // Update surrounding words next to current caret
                checkSpelling(position.GetPositionAtOffset(-3), currentWord);
                checkSpelling(position.GetPositionAtOffset(3), currentWord);
            }
    
            // Modified from: http://stackoverflow.com/a/26689916/3938401
            private string GetCurrentWord()
            {
                TextPointer start = CaretPosition;  // this is the variable we will advance to the left until a non-letter character is found
                TextPointer end = CaretPosition;    // this is the variable we will advance to the right until a non-letter character is found
                string stringBeforeCaret = start.GetTextInRun(LogicalDirection.Backward);   // extract the text in the current run from the caret to the left
                string stringAfterCaret = start.GetTextInRun(LogicalDirection.Forward);     // extract the text in the current run from the caret to the left
                int countToMoveLeft = 0;  // we record how many positions we move to the left until a non-letter character is found
                int countToMoveRight = 0; // we record how many positions we move to the right until a non-letter character is found
                for (int i = stringBeforeCaret.Length - 1; i >= 0; --i)
                {
                    // if the character at the location CaretPosition-LeftOffset is a letter, we move more to the left
                    if (!char.IsWhiteSpace(stringBeforeCaret[i]))
                        ++countToMoveLeft;
                    else break; // otherwise we have found the beginning of the word
                }
                for (int i = 0; i < stringAfterCaret.Length; ++i)
                {
                    // if the character at the location CaretPosition+RightOffset is a letter, we move more to the right
                    if (!char.IsWhiteSpace(stringAfterCaret[i]))
                        ++countToMoveRight;
                    else break; // otherwise we have found the end of the word
                }
                start = start.GetPositionAtOffset(-countToMoveLeft);    // modify the start pointer by the offset we have calculated
                end = end.GetPositionAtOffset(countToMoveRight);        // modify the end pointer by the offset we have calculated
                // extract the text between those two pointers
                TextRange r = new TextRange(start, end);
                string text = r.Text;
                // check the result
                return text;
            }
    
            public double ScaleX
            {
                get { return (double)GetValue(ScaleXProperty); }
                set { SetValue(ScaleXProperty, value); }
            }
            public static readonly DependencyProperty ScaleXProperty =
                DependencyProperty.Register("ScaleX", typeof(double), typeof(FixedCustomRichTextBox), new UIPropertyMetadata(1.0));
    
            public double ScaleY
            {
                get { return (double)GetValue(ScaleYProperty); }
                set { SetValue(ScaleYProperty, value); }
            }
            public static readonly DependencyProperty ScaleYProperty =
                DependencyProperty.Register("ScaleY", typeof(double), typeof(FixedCustomRichTextBox), new UIPropertyMetadata(1.0));
    
        }
    }
