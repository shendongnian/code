    public class Quiz : IDisposable
    {
        private bool _disposed = false;
        private List<QuizWord> _Words = new List<QuizWord>();
        private List<Editor> _Editors = new List<Editor>();
        private MultilineSupport _Multiline;
        private Control _Container = null;
        public Quiz() : this(null, null) { }
        public Quiz(Label RefControl, List<QuizWord> Words)
        {
            this._Container = RefControl.Parent;
            this.Label = null;
            if (RefControl != null)
            {
                this.Label = RefControl;
                this.Matches = new List<QuizWord>();
                if (Words != null)
                {
                    this._Multiline = new MultilineSupport(RefControl);
                    this.Matches = Words;
                }
            }
        }
           
        public Label Label { get; set; }
        public List<QuizWord> Matches
        {
            get { return this._Words; }
            set { this._Words = value; Editors_Setup(); }
        }
        private void Editors_Setup()
        {
            if ((this._Words == null) || (this._Words.Count < 1)) return;
            int i = 1;
            foreach (QuizWord _word in _Words)
            {
                List<Point> _Positions = GetEditorPosition(this.Label, _word);
                foreach (Point _P in _Positions)
                {
                    Editor _editor = new Editor(this.Label, _word.WordMask);
                    _editor.Location = _P;
                    _editor.Name = this.Label.Name + "Editor" + i.ToString(); ++i;
                    _Editors.Add(_editor);
                    this._Container.Controls.Add(_editor);
                    this._Container.Controls[_editor.Name].BringToFront();
                }
            }
        }
        private List<Point> GetEditorPosition(Label _label, QuizWord _word)
        {
            List<Point> _positions = new List<Point>();
            List<int> _idxes = Regex.Matches(_label.Text, _word.WordMask)
                                    .Cast<Match>()
                                    .Select(t => t.Index).ToList();
            foreach (int _idx in _idxes)
            {
                _positions.Add(this._Multiline.GetPositionFromCharIndex(_idx));
            }
            return _positions;
        }
        private class MultilineSupport
        {
            Label RefLabel;
            float _FontSpacingCoef = 1.8F;
            private TextFormatFlags _flags = TextFormatFlags.SingleLine |
                                             TextFormatFlags.Left |
                                             TextFormatFlags.NoPadding |
                                             TextFormatFlags.TextBoxControl;
            public MultilineSupport(Label label)
            {
                this.Lines = new List<string>();
                    
                this.LinesFirstCharIndex = new List<int>();
                this.NumberOfLines = 0;
                Initialize(label);
            }
            public int NumberOfLines { get; set; }
            public List<string> Lines { get; set; }
            public List<int> LinesFirstCharIndex { get; set; }
            public int GetFirstCharIndexFromLine(int line)
            {
                if (LinesFirstCharIndex.Count == 0) return -1;
                return LinesFirstCharIndex.Count - 1 >= line ? LinesFirstCharIndex[line] : -1;
            }
            public int GetLineFormCharIndex(int index)
            {
                if (LinesFirstCharIndex.Count == 0) return -1;
                int _lineindex = 0;
                foreach (int idx in LinesFirstCharIndex)
                {
                    if (index < idx) break;
                    _lineindex++;
                }
                return _lineindex - 1;
            }
            public Point GetPositionFromCharIndex(int Index)
            {
                return CalcPosition(GetLineFormCharIndex(Index), Index);
            }
            private void Initialize(Label label)
            {
                this.RefLabel = label;
                if (label.Text.Trim().Length == 0)
                    return;
                List<string> _wordslist = new List<string>();
                string _substring = string.Empty;
                this.LinesFirstCharIndex.Add(0);
                this.NumberOfLines = 1;
                int _currentlistindex = 0;
                int _start = 0;
                _wordslist.AddRange(label.Text.Split(new char[] { (char)32 }, StringSplitOptions.None));
                foreach (string _word in _wordslist)
                {
                    ++_currentlistindex;
                    int _wordindex = label.Text.IndexOf(_word, _start);
                    int _sublength = MeasureString((_substring + _word + (_currentlistindex < _wordslist.Count ? ((char)32).ToString() : string.Empty)));
                    if (_sublength > label.Width)
                    {
                        this.Lines.Add(_substring);
                        this.LinesFirstCharIndex.Add(_wordindex);
                        this.NumberOfLines += 1;
                        _substring = string.Empty;
                    }
                    _start += _word.Length + 1;
                    _substring += _word + (char)32;
                }
                this.Lines.Add(_substring.TrimEnd());
            }
            private Point CalcPosition(int Line, int Index)
            {
                int _font_padding = (int)((RefLabel.Font.Size - ((int)RefLabel.Font.Size % 12)) * _FontSpacingCoef);
                int _font_spacing = (int)(this.RefLabel.Font.Size * _FontSpacingCoef);
                int _verticalpos = Line * _font_spacing + this.RefLabel.Top;
                int _horizontalpos = MeasureString(this.Lines[Line]
                                      .Substring(0, Index - GetFirstCharIndexFromLine(Line)));
                return new Point(_horizontalpos + _font_padding, _verticalpos);
            }
            private int MeasureString(string _string)
            {
                return TextRenderer.MeasureText(RefLabel.CreateGraphics(), _string,
                                                this.RefLabel.Font, this.RefLabel.Size, _flags).Width;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected void Dispose(bool IsSafeDisposing)
        {
            if (IsSafeDisposing && (!this._disposed))
            {
                foreach (Editor _editor in _Editors)
                    if (_editor != null) _editor.Dispose();
                this._disposed = true;
            }
        }
    }
