    using (var myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Green))
                {
                    using (var formGraphics = this.someForm.Child.CreateGraphics())
                    {
                        formGraphics.FillEllipse(myBrush, new System.Drawing.Rectangle(0, 0, 200, 300));
                    }
                }
