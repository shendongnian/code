    this.olvInvoiceType.RendererDelegate =  delegate (EventArgs re, Graphics g, Rectangle r, object rowObject)
                {
                    var item = rowObject as MyItem;
                    if (item != null)
                    {
                        //g.FillRectangle(new SolidBrush(this.olvItems.BackColor), r);
                        g.DrawString(item.Name, olvItems.Font, brush, r);
                    }
                   return true;
                };
