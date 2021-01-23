    [UserRepositoryItem("RegisterPasteHandlerEdit")]
    public class RepositoryItemPasteHandlerEdit : RepositoryItemTextEdit
    {
        static RepositoryItemPasteHandlerEdit()
        {
            RegisterPasteHandlerEdit();
        }
        static private readonly object EventPaste;
        public const string CustomEditName = "PasteHandlerEdit";
        public RepositoryItemPasteHandlerEdit() { }
        public override string EditorTypeName => CustomEditName;
        public static void RegisterPasteHandlerEdit()
        {
            Image img = null;
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomEditName, typeof(PasteHandlerEdit), typeof(RepositoryItemPasteHandlerEdit), typeof(TextEditViewInfo), new TextEditPainter(), true, img));
        }
        public override void Assign(RepositoryItem item)
        {
            BeginUpdate();
            try
            {
                base.Assign(item);
                var source = item as RepositoryItemPasteHandlerEdit;
                if (source == null) return;
                Events.AddHandler(EventPaste, source.Events[EventPaste]);
            }
            finally
            {
                EndUpdate();
            }
        }
        public event PasteEventHandler OnPaste
        {
            add
            {
                Events.AddHandler(EventPaste, value);
            }
            remove
            {
                Events.RemoveHandler(EventPaste, value);
            }
        }
        protected internal void RaiseOnPaste(PasteEventArgs e)
        {
            if (IsLockEvents)
                return;
            var handler = (PasteEventHandler)Events[EventPaste];
            handler?.Invoke(GetEventSender(), e);
        }
    }
    [ToolboxItem(true)]
    public class PasteHandlerEdit : TextEdit
    {
        static PasteHandlerEdit()
        {
            RepositoryItemPasteHandlerEdit.RegisterPasteHandlerEdit();
        }
        public PasteHandlerEdit() { }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemPasteHandlerEdit Properties => base.Properties as RepositoryItemPasteHandlerEdit;
        public override string EditorTypeName => RepositoryItemPasteHandlerEdit.CustomEditName;
        protected override TextBoxMaskBox CreateMaskBoxInstance() => new PasteHandlerMaskBox(this);
        protected override void CreateMaskBox()
        {
            base.CreateMaskBox();
            var pasteHandlerMaskBox = MaskBox as PasteHandlerMaskBox;
            pasteHandlerMaskBox.OnPaste += PasteHandlerMaskBox_OnPaste;
        }
        private void PasteHandlerMaskBox_OnPaste(object sender, PasteEventArgs e) => Properties.RaiseOnPaste(e);
    }
    public class PasteHandlerMaskBox : TextBoxMaskBox
    {
        private const int WM_PASTE = 0x0302;
        public PasteHandlerMaskBox(TextEdit ownerEdit) : base(ownerEdit) { }
        public event PasteEventHandler OnPaste;
        protected override void WndProc(ref Message msg)
        {
            if (msg.Msg == WM_PASTE)
            {
                var e = new PasteEventArgs();
                OnPaste?.Invoke(this, e);
                if (e.Cancel)
                    return;
            }
            base.WndProc(ref msg);
        }
    }
    public class PasteEventArgs : CancelEventArgs
    {
        public PasteEventArgs() { }
        public PasteEventArgs(bool cancel) : base(cancel) { }
        public string Text => Clipboard.GetText();
    }
    public delegate void PasteEventHandler(object sender, PasteEventArgs e);
