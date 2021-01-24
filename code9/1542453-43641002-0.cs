    protected override void WndProc(ref Message m) {
        if (m.Msg == Msgs.Close) {
            AskForExit();
        } else if (m.Msg == Msgs.Other) {
            DoOtherStuffOwnedByMe();
        }
            base.WndProc(ref m);
    }
