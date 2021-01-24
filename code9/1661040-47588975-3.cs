    using System;
	using System.Collections.Generic;
	using ICSharpCode.AvalonEdit.Document;
	namespace ICSharpCode.AvalonEdit.Folding
	{
		/// <summary>
		/// Allows producing tab based foldings
		/// </summary>
		public class TabFoldingStrategy : AbstractFoldingStrategy
		{
			internal class TabIndent
			{
				public int IndentSize;
				public int LineStart;
				public int LineEnd;
				public int StartOffset => LineStart + IndentSize - 1;
				public int TextLength => LineEnd - StartOffset;
				public TabIndent(int i_indentSize, int i_lineStart, int i_lineEnd)
				{
					IndentSize = i_indentSize;
					LineStart = i_lineStart;
					LineEnd = i_lineEnd;
				}
			}
			/// <summary>
			/// Creates a new TabFoldingStrategy.
			/// </summary>
			public TabFoldingStrategy()
			{
			}
			/// <summary>
			/// Create <see cref="NewFolding"/>s for the specified document.
			/// </summary>
			public override IEnumerable<NewFolding> CreateNewFoldings(TextDocument document, out int firstErrorOffset)
			{
				firstErrorOffset = -1;
				return CreateNewFoldings(document);
			}
			/// <summary>
			/// Create <see cref="NewFolding"/>s for the specified document.
			/// </summary>
			public IEnumerable<NewFolding> CreateNewFoldings(TextDocument document)
			{
				List<NewFolding> newFoldings = new List<NewFolding>();
				int documentIndent = 0;
				List<TabIndent> tabIndents = new List<TabIndent>();
				foreach (DocumentLine line in document.Lines) {
					int lineIndent = 0;
					for (int i = line.Offset; i < line.EndOffset; i++) {
						char c = document.GetCharAt(i);
						if (c == '\t') {
							lineIndent++;
						} else {
							break;
						}
					}
					if (lineIndent > documentIndent) {
						tabIndents.Add(new TabIndent(lineIndent, line.PreviousLine.Offset, line.PreviousLine.EndOffset));
					} else if (lineIndent < documentIndent) {
						List<TabIndent> closedIndents = tabIndents.FindAll(x => x.IndentSize > lineIndent);
						closedIndents.ForEach(x => {
							newFoldings.Add(new NewFolding(x.StartOffset, line.PreviousLine.EndOffset) {
								Name = document.GetText(x.StartOffset, x.TextLength)
							});
							tabIndents.Remove(x);
						});
					}
					documentIndent = lineIndent;
				}
				tabIndents.ForEach(x => {
					newFoldings.Add(new NewFolding(x.StartOffset, document.TextLength));
				});
				newFoldings.Sort((a, b) => a.StartOffset.CompareTo(b.StartOffset));
				return newFoldings;
			}
		}
	}
