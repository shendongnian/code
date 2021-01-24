        var length = word.Length;
                    // Try to select the text as a contiguous range
                    for (TextPointer start = textRange.Start.GetPositionAtOffset(offset); start != textRange.End; start = start.GetPositionAtOffset(1))
					{
						try
						{
							TextRange result = new TextRange(start, start.GetPositionAtOffset(word.Contains(" ") ? word.Length + 4: word.Length)); //Added 4 to the offset length to account for special invisible characters coming up with space in richtext box
							if (result.Text.Trim() == word.Trim())	
							{
								result.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(Colors.Red));
								break;
							}
						}
						catch (Exception ex)
						{
							throw new Exception(ex.Message);
						}
