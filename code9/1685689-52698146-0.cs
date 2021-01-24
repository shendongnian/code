       public override void UpdateDrawState(TextPaint ds)
       {
            ds.LinkColor = Android.Graphics.Color.Blue.ToArgb();
            base.UpdateDrawState(ds);
            ds.UnderlineText = false;
       }
