    public class Quiz
    {
        private List<QuizWord> _Words = new List<QuizWord>();
        private List<Editor> _Editors = new List<Editor>();
        private Control _Container = null;
        private int _labelpadding = 4;
        private TextFormatFlags _flags = TextFormatFlags.NoPadding |
                                         TextFormatFlags.Left |
                                         TextFormatFlags.TextBoxControl;
        public Quiz() : this(null, null) { }
        public Quiz(Label RefControl, List<QuizWord> Words)
        {
            this._Container = RefControl.Parent;
            this.Label = null;
            if (RefControl != null)
                this.Label = RefControl;
            this.Matches = new List<QuizWord>();
            if (Words != null)
                this.Matches = Words;
        }
           
        public Label Label { get; set; }
        public List<QuizWord> Matches
        {
            get { return _Words; }
            set { _Words = value; Editors_Setup(); }
        }
        private void Editors_Setup()
        {
            if ((this._Words == null) || (this._Words.Count < 1)) return;
            int i = 1;
            foreach (QuizWord _word in _Words)
            {
                Editor _editor = new Editor(this.Label, _word.WordMask);
                _editor.Location = GetEditorPosition(this.Label, _word.WordMask);
                _editor.Name = this.Label.Name + "Editor" + i.ToString(); ++i;
                _Editors.Add(_editor);
                this._Container.Controls.Add(_editor);
                this._Container.Controls[_editor.Name].BringToFront();
            }
        }
        private Point GetEditorPosition(Label _label, string _word)
        {
            string _text = _label.Text.Substring(0,_label.Text.IndexOf(_word));
            int _textsize = TextRenderer.MeasureText(_text, _label.Font, _label.Size, this._flags).Width;
            return new Point((_label.Left - _labelpadding + _textsize), _label.Top);
        }
    }
