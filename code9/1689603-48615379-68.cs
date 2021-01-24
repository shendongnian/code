    public class Editor : TextBox
    {
        private string SubstChar = string.Empty;
        private string SubstCharLarge = ((char)0x2007).ToString();
        private string SubstCharSmall = ((char)0x2002).ToString();
        private Font NormalFont = null;
        private Font UnderlineFont = null;
        private string WordMask = string.Empty;
        private TextFormatFlags _flags = TextFormatFlags.NoPadding | TextFormatFlags.Left |
                                         TextFormatFlags.Bottom | TextFormatFlags.WordBreak |
                                         TextFormatFlags.TextBoxControl;
        public Editor(Label RefLabel, string WordToMatch)
        {
            this.BorderStyle = BorderStyle.None;
            this.TextAlign = HorizontalAlignment.Left;
            this.Margin = new Padding(0);
            this.MatchWord = WordToMatch;
            this.MaxLength = WordToMatch.Length;
            this._Label = RefLabel;
            this.NormalFont = RefLabel.Font;
            this.UnderlineFont = new Font(RefLabel.Font, (RefLabel.Font.Style | FontStyle.Underline));
            this.Font = this.UnderlineFont;
            this.Size = GetTextSize(WordToMatch);
            this.WordMask = CreateMask(this.Size.Width);
            this.Text = this.WordMask;
            this.BackColor = RefLabel.BackColor;
            this.ForeColor = RefLabel.ForeColor;
            this.KeyDown += this.KeyDownHandler;
            this.Enter += (sender, e) => { this.Font = this.UnderlineFont; this.SelectionStart = 0;  this.SelectionLength = 0; };
            this.Leave += (sender, e) => { CheckWordMatch(); };
        }
        public string MatchWord { get; set; }
        private Label _Label { get; set; }
        public void KeyDownHandler(object sender, KeyEventArgs e)
        {
            int _start = this.SelectionStart;
            switch (e.KeyCode)
            {
            case Keys.Back:
                if (this.SelectionStart > 0)
                {
                    this.AppendText(SubstChar);
                    this.SelectionStart = 0;
                    this.ScrollToCaret();
                }
                this.SelectionStart = _start;
                break;
            case Keys.Delete:
                if (this.SelectionStart < this.Text.Length)
                {
                    this.AppendText(SubstChar);
                    this.SelectionStart = 0;
                    this.ScrollToCaret();
                }
                this.SelectionStart = _start;
                break;
            case Keys.Enter:
                e.SuppressKeyPress = true;
                CheckWordMatch();
                break;
            case Keys.Escape:
                e.SuppressKeyPress = true;
                this.Text = this.WordMask;
                this.ForeColor = this._Label.ForeColor;
                break;
            default:
                if ((e.KeyCode >= (Keys)32 & e.KeyCode <= (Keys)127) && (e.KeyCode < (Keys)36 | e.KeyCode > (Keys)39))
                {
                    int _removeat = this.Text.LastIndexOf(SubstChar);
                    if (_removeat > -1) this.Text = this.Text.Remove(_removeat, 1);
                    this.SelectionStart = _start;
                }
                break;
            }
        }
        private void CheckWordMatch()
        {
            if (this.Text != this.WordMask) {
                this.Font = this.Text == this.MatchWord ? this.NormalFont : this.UnderlineFont;
                this.ForeColor = this.Text == this.MatchWord ? Color.Green : Color.Red;
            } else {
                this.ForeColor = this._Label.ForeColor;
            }
        }
        private Size GetTextSize(string _mask)
        {
            return TextRenderer.MeasureText(this._Label.CreateGraphics(), _mask, this._Label.Font, this._Label.Size, _flags);
        }
        private string CreateMask(int _EditorWidth)
        {
            string _TestMask = new StringBuilder().Insert(0, SubstCharLarge, this.MatchWord.Length).ToString();
            SubstChar = (GetTextSize(_TestMask).Width <= _EditorWidth) ? SubstCharLarge : SubstCharSmall;
            return SubstChar == SubstCharLarge 
                              ? _TestMask  
                              : new StringBuilder().Insert(0, SubstChar, this.MatchWord.Length).ToString();
        }
    }
