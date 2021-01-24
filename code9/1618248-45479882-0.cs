    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace YOUR APPLICATION NAMESPACE
    {
        
       public class ClassResize
        {
           List<System.Drawing.Rectangle> AryControlsStorage = new List<System.Drawing.Rectangle>();
           private bool ShowRowHeader=false;
    
           private Form form { get; set; }
           private float FontSize { get; set; }
           private System.Drawing.SizeF FormSize { get; set; }
    
           public ClassResize(Form FForm)
           {
               form = FForm;
               FormSize = FForm.ClientSize;
               FontSize = FForm.Font.Size;
           }
           private static IEnumerable<Control> GetAllControls(Control c)
           {
               return c.Controls.Cast<Control>().SelectMany(item=>           
               GetAllControls(item)).Concat(c.Controls.Cast<Control>()).Where(control=>
                    control.Name !=string.Empty);
           }
           public void GetInitialSize()
           {
               var _Controls = GetAllControls(form);
               foreach (Control control in _Controls)
               {
                   AryControlsStorage.Add(control.Bounds);
                   if (control.GetType() == typeof(DataGridView))
                       DGColumnAdjust(((DataGridView)control), ShowRowHeader);
    
               }
    
           }
           public void Resize()
           {
               double FormRatioWidth = (double)form.ClientSize.Width / (double)FormSize.Width;
               double FormRatioHeight=(double)form.ClientSize.Height / (double)FormSize.Height;
               var _Controls = GetAllControls(form);
               int Postion = -1;
               foreach(Control control in _Controls)
               {
                   Postion += 1;
                   System.Drawing.Size _ControlsSize = new System.Drawing.Size((int)(AryControlsStorage[Postion].Width * FormRatioWidth),
                       (int)(AryControlsStorage[Postion].Height * FormRatioHeight));
                   System.Drawing.Point _ControlsPoint = new System.Drawing.Point((int)(AryControlsStorage[Postion].X * FormRatioWidth),
        (int)(AryControlsStorage[Postion].Y * FormRatioHeight));
                   control.Bounds = new System.Drawing.Rectangle(_ControlsPoint, _ControlsSize);
                   if (control.GetType() == typeof(DataGridView))
                       DGColumnAdjust(((DataGridView)control),ShowRowHeader);
                   //control.Font = new System.Drawing.Font(form.Font.FontFamily,
                   //(float)(((Convert.ToDouble(FontSize) * FormRatioWidth) / 1.5) + ((Convert.ToDouble(FontSize) * FormRatioHeight) / 1.5)));
    
    
    
               }
    
           }
           private void DGColumnAdjust(DataGridView dgv, bool _showRowHeader)
           {
               int intRowHeader = 0;
               const int Hscrolbarwidth = 5;
               if (_showRowHeader)
               {
                   intRowHeader = dgv.RowHeadersWidth;
               }
               else
               {
                   dgv.RowHeadersVisible = false;
               }
                   for (int i = 0; i < dgv.ColumnCount; i++)
                   {
                       if (dgv.Dock == DockStyle.Fill)
                           dgv.Columns[i].Width = ((dgv.Width - intRowHeader) / dgv.ColumnCount);
                       else
                           dgv.Columns[i].Width = ((dgv.Width - intRowHeader - Hscrolbarwidth) / dgv.ColumnCount);
    
                   }
               }
           
    
        }
    }
