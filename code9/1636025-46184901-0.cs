	/// <summary>
	/// Instances of this class strip HTML/XML tags from a string
	/// </summary>
	public class HTMLStripper
	{
		public HTMLStripper() { }
		public HTMLStripper(string source)
		{
			m_source = source;
			stripTags();
		}
		private const char m_beginToken = '<';
		private const char m_endToken = '>';
		private const char m_whiteSpace = ' ';
		private enum tokenType
		{
			nonToken = 0,
			beginToken = 1,
			endToken = 2,
			escapeToken = 3,
			whiteSpace = 4
		}
		private string m_source = string.Empty;
		private string m_stripped = string.Empty;
		private string m_tagName = string.Empty;
		private string m_tag = string.Empty;
		private Int32 m_startpos = -1;
		private Int32 m_endpos = -1;
		private Int32 m_currentpos = -1;
		private IList<string> m_skipTags = new List<string>();
		private bool m_tagFound = false;
		private bool m_tagsStripped = false;
		/// <summary>
		/// Gets or sets the source string.
		/// </summary>
		/// <value>
		/// The source string.
		/// </value>
		public string source { get { return m_source; } set { clear(); m_source = value; stripTags(); } }
		/// <summary>
		/// Gets the string stripped of HTML tags.
		/// </summary>
		/// <value>
		/// The string.
		/// </value>
		public string stripped { get { return m_stripped; } set { } }
		/// <summary>
		/// Gets or sets a value indicating whether [HTML tags were stripped].
		/// </summary>
		/// <value>
		///   <c>true</c> if [HTML tags were stripped]; otherwise, <c>false</c>.
		/// </value>
		public bool tagsStripped { get { return m_tagsStripped; } set { } }
		/// <summary>
		/// Adds the name of an HTML tag to skip stripping (leave in the text).
		/// </summary>
		/// <param name="value">The value.</param>
		public void addSkipTag(string value)
		{
			if (value.Length > 0)
			{
				// Trim start and end tokens from skipTags if present and add to list
				CharEnumerator tmpScanner = value.GetEnumerator();
				string tmpString = string.Empty;
				while (tmpScanner.MoveNext())
				{
					if (tmpScanner.Current != m_beginToken && tmpScanner.Current != m_endToken) { tmpString += tmpScanner.Current; }
				}
				if (tmpString.Length > 0) { m_skipTags.Add(tmpString); }
			}
		}
		/// <summary>
		/// Clears this instance.
		/// </summary>
		public void clear()
		{
			m_source = string.Empty;
			m_tag = string.Empty;
			m_startpos = -1;
			m_endpos = -1;
			m_currentpos = -1;
			m_tagsStripped = false;
		}
		/// <summary>
		/// Clears all.
		/// </summary>
		public void clearAll()
		{
			this.clear();
			m_skipTags.Clear();
		}
		/// <summary>
		/// Strips the HTML tags.
		/// </summary>
		private void stripTags()
		{
			// Preserve source and make a copy for stripping
			m_stripped = m_source;
			// Find first tag
			getNext();
			// If there are any tags (if next tag is string.Empty we are at EOS)...
			if (m_tagName != string.Empty)
			{
				do
				{
					// If the tag we found is not to be skipped...
					if (!m_skipTags.Contains(m_tagName))
					{
						// Remove tag from string
						m_stripped = m_stripped.Remove(m_startpos, m_endpos - m_startpos + 1);
						m_tagsStripped = true;
					}
					// Get next tag, rinse and repeat (if next tag is string.Empty we are at EOS)
					getNext();
				} while (m_tagName != string.Empty);
			}
		}
		/// <summary>
		/// Steps the pointer to the next HTML tag.
		/// </summary>
		private void getNext()
		{
			m_tagFound = false;
			m_tag = string.Empty;
			m_tagName = string.Empty;
			bool beginTokenFound = false;
			CharEnumerator scanner = m_stripped.GetEnumerator();
			// If we're not at the beginning of the string, move the enumerator to the appropriate location in the string
			if (m_currentpos != -1)
			{
				Int32 index = 0;
				do
				{
					scanner.MoveNext();
					index += 1;
				} while (index < m_currentpos + 1);
			}
			while (!m_tagFound && m_currentpos + 1 < m_stripped.Length)
			{
				// Find next begin token
				while (scanner.MoveNext())
				{
					m_currentpos += 1;
					if (evaluateChar(scanner.Current) == tokenType.beginToken)
					{
						m_startpos = m_currentpos;
						beginTokenFound = true;
						break;
					}
				}
				// If a begin token is found, find next end token
				if (beginTokenFound)
				{
					while (scanner.MoveNext())
					{
						m_currentpos += 1;
						// If we find another begin token before finding an end token we are not in a tag
						if (evaluateChar(scanner.Current) == tokenType.beginToken)
						{
							m_tagFound = false;
							beginTokenFound = true;
							break;
						}
						// If the char immediately following a begin token is a white space we are not in a tag
						if (m_currentpos - m_startpos == 1 && evaluateChar(scanner.Current) == tokenType.whiteSpace)
						{
							m_tagFound = false;
							beginTokenFound = true;
							break;
						}
						// End token found
						if (evaluateChar(scanner.Current) == tokenType.endToken)
						{
							m_endpos = m_currentpos;
							m_tagFound = true;
							break;
						}
					}
				}
				if (m_tagFound)
				{
					// Found a tag, get the info for this tag
					m_tag = m_stripped.Substring(m_startpos, (m_endpos + 1) - m_startpos);
					m_tagName = m_stripped.Substring(m_startpos + 1, m_endpos - m_startpos - 1);
					// If this tag is to be skipped, we do not want to reset the position within the string
					// Also, if we are at the end of the string (EOS) we do not want to reset the position
					if (!m_skipTags.Contains(m_tagName) && m_currentpos != stripped.Length)
					{
						m_currentpos = -1;
					}
				}
			}
		}
		/// <summary>
		/// Evaluates the next character.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>tokenType</returns>
		private tokenType evaluateChar(char value)
		{
			tokenType returnValue = new tokenType();
			switch (value)
			{
				case m_beginToken:
					returnValue = tokenType.beginToken;
					break;
				case m_endToken:
					returnValue = tokenType.endToken;
					break;
				case m_whiteSpace:
					returnValue = tokenType.whiteSpace;
					break;
				default:
					returnValue = tokenType.nonToken;
					break;
			}
			return returnValue;
		}
	}
