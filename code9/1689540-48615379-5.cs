    public class Editor : TextBox
    {
        private string SubstChar = "_";
        private string WordMask = string.Empty;
        private TextFormatFlags _flags = TextFormatFlags.NoPadding |
                                         TextFormatFlags.Left |
                                         TextFormatFlags.Bottom |
                                         TextFormatFlags.TextBoxControl;
        public Editor(Label RefLabel, string WordToMatch)
        {
            this.BorderStyle = BorderStyle.None;
            this.TextAlign = HorizontalAlignment.Left;
            this.Margin = new Padding(0);
            this.MatchWord = WordToMatch;
            this.MaxLength = WordToMatch.Length;
            this.WordMask = new StringBuilder().Insert(0, SubstChar, WordToMatch.Length).ToString();
            this.Text = this.WordMask;
            this._Label = RefLabel;
            this.BackColor = RefLabel.BackColor;
            this.ForeColor = RefLabel.ForeColor;
            this.Font = RefLabel.Font;
            this.Size = new Size(GetTextWidth(WordToMatch), RefLabel.Height);
            this.Visible = true;
            this.KeyDown += this.KeyDownHandler;
        }
        public string MatchWord { get; set; }
        private Label _Label { get; set; }
        public void KeyDownHandler(object sender, KeyEventArgs e)
        {
            //Non-C# 7 Switch may be substituted with:
            //var keyswitch = new List<KeyValuePair<Func<int, bool>, Action>>();
            int _start = this.SelectionStart;
            switch (e.KeyCode)
            {
                case Keys.Back:
                    if (this.SelectionStart > 0)
                        this.AppendText(SubstChar);
                    this.SelectionStart = _start;
                    break;
                case Keys.Delete:
                    if (this.SelectionStart < this.Text.Length)
                        this.AppendText(SubstChar);
                    this.SelectionStart = _start;
                    break;
                case Keys.Enter:
                    e.Handled = true;
                    CheckWordMatch();
                    break;
                case Keys.Escape:
                    this.Text = this.WordMask;
                    this.ForeColor = this._Label.ForeColor;
                    break;
                default:
                    if (e.KeyCode >= Keys.A & e.KeyCode <= Keys.Z)
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
                this.ForeColor = this.Text == this.MatchWord ? Color.Green : Color.Red;
            } else {
                this.ForeColor = this._Label.ForeColor;
            }
        }
        private int GetTextWidth(string _mask)
        {
            return TextRenderer.MeasureText(_Label.CreateGraphics(), _mask, _Label.Font, this._Label.Size, _flags).Width;
        }
    }
