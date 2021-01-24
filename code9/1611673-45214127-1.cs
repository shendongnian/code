            protected override void Dispose(bool disposing)
        {
            IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
            if (designerHost != null)
            {
                for (int i = ((WTab)Component).Controls.Count - 1; i >= 0; i--)
                {
                    //
                    var tab = ((WTab)Component).Controls[i];
                    //
                    ((WTab)Component).Controls.Remove(tab);
                    //
                    designerHost.DestroyComponent(tab);
                }
            }
            base.Dispose(disposing);
        }
