    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ICSharpCode.AvalonEdit.Highlighting;
    using ICSharpCode.AvalonEdit.Highlighting.Xshd;
    using ICSharpCode.AvalonEdit.Rendering;
    using ICSharpCode.AvalonEdit.Document;
    using ICSharpCode.AvalonEdit.Folding;
    using System.Text.RegularExpressions;
    namespace Foo.languages
    {
        public class TabFoldingStrategy : AbstractFoldingStrategy
        {
            // How many spaces == one tab
            private const int SpacesInTab = 4;
            /// <summary>
            /// Creates a new TabFoldingStrategy.
            /// </summary>
            public TabFoldingStrategy() {
            }
            /// <summary>
            /// Create <see cref="NewFolding"/>s for the specified document.
            /// </summary>
            public override IEnumerable<NewFolding> CreateNewFoldings(TextDocument document, out int firstErrorOffset)
            {
                firstErrorOffset = -1;
                return CreateNewFoldingsByLine(document);
            }
            /// <summary>
            /// Create <see cref="NewFolding"/>s for the specified document.
            /// </summary>
            public IEnumerable<NewFolding> CreateNewFoldingsByLine(ITextSource document)
            {
                List<NewFolding> newFoldings = new List<NewFolding>();
                if (document == null || (document as TextDocument).LineCount <= 1)
                {
                    return newFoldings;
                }
                //Can keep track of offset ourself and from testing it seems to be accurate
                int offsetTracker = 0;
                // Keep track of start points since things nest
                Stack<int> startOffsets = new Stack<int>();
                StringBuilder lineBuffer = new StringBuilder();
                foreach (DocumentLine line in (document as TextDocument).Lines)
                {
                    if (offsetTracker >= document.TextLength)
                    {
                        break;
                    }
                    lineBuffer.Clear();
                    // First task is to get the line and figure out the spacing in front of it
                    int spaceCounter = 0;
                    bool foundText = false;
                    bool foundColon = false;
                    //for (int i = 0; i < line.Length; i++)
                    int i = 0;
                    //TODO buffer the characters so you can have the line contents on the stack too for the folding name (display text)
                    while (i < line.Length && !(foundText && foundColon))
                    {
                        char c = document.GetCharAt(offsetTracker + i);
                        switch (c)
                        {
                            case ' ': // spaces count as one
                                if (!foundText) {
                                    spaceCounter++;
                                }
                                break;
                            case '\t': // Tabs count as N
                                if (!foundText) {
                                    spaceCounter += SpacesInTab;
                                }
                                break;
                            case ':': // Tabs count as N
                                foundColon = true;
                                break;
                            default: // anything else means we encountered not spaces or tabs, so keep making the line but stop counting
                                foundText = true;
                                break;
                        }
                        i++;
                    }
                    // before we continue, we need to make sure its a correct multiple
                    int remainder = spaceCounter % SpacesInTab;
                    if (remainder > 0)
                    {
                        // Some tabbing isn't correct. ignore this line for folding purposes.
                        // This may break all foldings below that, but it's a complex problem to address.
                        continue;
                    }
                    // Now we need to figure out if this line is a new folding by checking its tabing
                    // relative to the current stack count. Convert into virtual tabs and compare to stack level
                    int numTabs = spaceCounter / SpacesInTab; // we know this will be an int because of the above check
                    if (numTabs >= startOffsets.Count && foundText && foundColon)
                    {
                        // we are starting a new folding
                        startOffsets.Push(offsetTracker);
                    }
                    else // numtabs < offsets
                    {
                        // we know that this is the end of a folding. It could be the end of multiple foldings. So pop until it matches.
                        while (numTabs < startOffsets.Count)
                        {
                            int foldingStart = startOffsets.Pop();
                            NewFolding tempFolding = new NewFolding();
                            //tempFolding.Name = < could add logic here, possibly by tracking key words when starting the folding, to control what is shown when it's folded >
                            tempFolding.StartOffset = foldingStart;
                            tempFolding.EndOffset = offsetTracker - 2; 
                            newFoldings.Add(tempFolding);
                        }
                    }
                    // Increment tracker. Much faster than getting it from the line
                    offsetTracker += line.TotalLength;
                }
                // Complete last foldings
                while (startOffsets.Count > 0)
                {
                    int foldingStart = startOffsets.Pop();
                    NewFolding tempFolding = new NewFolding();
                    //tempFolding.Name = < could add logic here, possibly by tracking key words when starting the folding, to control what is shown when it's folded >
                    tempFolding.StartOffset = foldingStart;
                    tempFolding.EndOffset = offsetTracker;
                    newFoldings.Add(tempFolding);
                }
                newFoldings.Sort((a, b) => (a.StartOffset.CompareTo(b.StartOffset)));
                return newFoldings;
            }
        }
    }
