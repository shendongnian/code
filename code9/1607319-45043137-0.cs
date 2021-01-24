    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace ContextMenuOnRichText_45042370
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
    
            private void doit(Point mouseClickedAtPosition)
            {
                if (txtbx_1.SelectedText != null)
                {
                    //find out where the selected text is
                    Point selectionposition = txtbx_1.GetPositionFromCharIndex(txtbx_1.SelectionStart);
    
                    /*
                     * the user is not likely to click in the right spot every time,
                     * so let's make a fudgeFactor
                     */
                    int fudgeFactor = 15;
    
                    
                    if ((mouseClickedAtPosition.X <= selectionposition.X + fudgeFactor && mouseClickedAtPosition.X >= selectionposition.X - fudgeFactor) && (mouseClickedAtPosition.Y <= selectionposition.Y + fudgeFactor && mouseClickedAtPosition.Y >= selectionposition.Y - fudgeFactor))
                    {
                        /*
                         * If the right click happened within the fudgeFactored area, then append to the box(open your menu)
                         */
                        txtbx_1.AppendText("positions are matching");
                    }
                    else
                    {
                        /*
                         * User did not right-click in the proper area
                         * don't show your menu
                         */
                        txtbx_1.AppendText("not matching" + Environment.NewLine);
                    }
                }
            }
    
            private void txtbx_1_MouseDown(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Right)
                {
                    doit(e.Location);
                }
            }
        }
    }
