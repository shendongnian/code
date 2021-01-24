    private void OnTextViewMouseHover(object sender, MouseHoverEventArgs e)
    {
        SnapshotPoint? point = GetMousePosition(new SnapshotPoint(this._textView.TextSnapshot, e.Position));
        if (point.HasValue)
        {
            string contentType = this._textView.TextBuffer.ContentType.DisplayName;
            if (contentType.Equals("Disassembly"))
            {
                this.ToolTipLegacy(point.Value);
            } 
            else // handle Tooltip the regular way 
            {
                if (!this._quickInfoBroker.IsQuickInfoActive(this._textView))
                {
                    ITrackingPoint triggerPoint = point.Value.Snapshot.CreateTrackingPoint(point.Value.Position, PointTrackingMode.Positive);
                    this._session = this._quickInfoBroker.CreateQuickInfoSession(this._textView, triggerPoint, false);
                    this._session.Start();
                }
            }
        }
    }
