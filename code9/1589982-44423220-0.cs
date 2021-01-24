    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Drawing.Printing;
    
    namespace ZebraPrint
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            /// <summary>
            /// 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            void Button1_Click(object sender, System.EventArgs e)
            {
                using (PrintDocument doc = new PrintDocument())
                {
                    doc.PrintPage += new PrintPageEventHandler(document_PrintPage);
    
                    using (PrintDialog pd = new PrintDialog())
                    {
                        pd.PrinterSettings = new PrinterSettings();
                        pd.Document = doc;
                        if (pd.ShowDialog(this) == DialogResult.OK)
                        {
                            pd.Document.Print();
                        }
                    }
                }
            }
    
            /// <summary>
            /// 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            void document_PrintPage(object sender, PrintPageEventArgs e)
            {
                Font printFont = new Font("Consolas", 6);
                SizeF size = e.Graphics.MeasureString("WWWWWW", printFont);
                float printTextHeight = size.Height;
                float top = 0;
    
                e.Graphics.DrawString(@"${^XA", printFont, System.Drawing.Brushes.Black, 10, top += printTextHeight);
                e.Graphics.DrawString(@"^MD0", printFont, System.Drawing.Brushes.Black, 10, top += printTextHeight);
                e.Graphics.DrawString(@"^MMT", printFont, System.Drawing.Brushes.Black, 10, top += printTextHeight);
                e.Graphics.DrawString(@"^MNY", printFont, System.Drawing.Brushes.Black, 10, top += printTextHeight);
                e.Graphics.DrawString(@"^LL600", printFont, System.Drawing.Brushes.Black, 10, top += printTextHeight);
                e.Graphics.DrawString(@"^LH95,75", printFont, System.Drawing.Brushes.Black, 10, top += printTextHeight);
                e.Graphics.DrawString(@"^FO0,0^AA,54^FD  Palmdale Oil Company, Inc.^FS", printFont, System.Drawing.Brushes.Black, 10, top += printTextHeight);
                e.Graphics.DrawString(@"^FO0,100^AC,36^FDCustomer: AVERITT EXPRESS^FS", printFont, System.Drawing.Brushes.Black, 10, top += printTextHeight);
                e.Graphics.DrawString(@"^FO0,136^AC,36^FD Vehicle: 66030^FS", printFont, System.Drawing.Brushes.Black, 10, top += printTextHeight);
                e.Graphics.DrawString(@"^FO0,172^AC,36^FD    Desc: REEFER^FS", printFont, System.Drawing.Brushes.Black, 10, top += printTextHeight);
                e.Graphics.DrawString(@"^FO0,208^AC,36^FD     TAG: ^FS", printFont, System.Drawing.Brushes.Black, 10, top += printTextHeight);
                e.Graphics.DrawString(@"^FO0,275", printFont, System.Drawing.Brushes.Black, 10, top += printTextHeight);
                e.Graphics.DrawString(@"^BY5", printFont, System.Drawing.Brushes.Black, 10, top += printTextHeight);
                e.Graphics.DrawString(@"^BC,150,N,N,N,N^FD4770013-66030", printFont, System.Drawing.Brushes.Black, 10, top += printTextHeight);
                e.Graphics.DrawString(@"^FS", printFont, System.Drawing.Brushes.Black, 10, top += printTextHeight);
                e.Graphics.DrawString(@"^FO0,430^AC,36^FD4770013-66030^FS", printFont, System.Drawing.Brushes.Black, 10, top += printTextHeight);
                e.Graphics.DrawString(@"^XZ}$", printFont, System.Drawing.Brushes.Black, 10, top += printTextHeight);
            }
        }
    }
