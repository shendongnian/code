    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using Microsoft.SqlServer.Management.UI.Grid;
    
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            private GridControl _control = new GridControl();
    
            public Form1()
            {
                InitializeComponent();
    
                for (int i = 0; i < 256; i++)
                {
                    _control.AddColumn(new GridColumnInfo { HeaderType = GridColumnHeaderType.Text, IsUserResizable = true });
                    _control.SetHeaderInfo(i, "Column " + i, null);
                }
    
                _control.Dock = DockStyle.Fill;
                _control.GridStorage = new GridStorage();
                Controls.Add(_control);
            }
        }
    
        // represents a datasource
        public class GridStorage : IGridStorage
        {
            public long EnsureRowsInBuf(long FirstRowIndex, long LastRowIndex)
            {
                return NumRows(); // pagination, dynamic load, virtualization, could happen here
            }
    
            public void FillControlWithData(long nRowIndex, int nColIndex, IGridEmbeddedControl control)
            {
                // for cell edition
                control.SetCurSelectionAsString(GetCellDataAsString(nRowIndex, nColIndex));
            }
    
            public string GetCellDataAsString(long nRowIndex, int nColIndex)
            {
                // get cell data
                return nRowIndex + " x " + nColIndex;
            }
    
            public int IsCellEditable(long nRowIndex, int nColIndex)
            {
                return 1; // 1 means yes, 0 means false
            }
    
            public long NumRows()
            {
                return 10000;
            }
    
            public bool SetCellDataFromControl(long nRowIndex, int nColIndex, IGridEmbeddedControl control)
            {
                // when a cell has changed, you're supposed to change your data here
                return true;
            }
    
            public Bitmap GetCellDataAsBitmap(long nRowIndex, int nColIndex) => throw new NotImplementedException();
            public void GetCellDataForButton(long nRowIndex, int nColIndex, out ButtonCellState state, out Bitmap image, out string buttonLabel) => throw new NotImplementedException();
            public GridCheckBoxState GetCellDataForCheckBox(long nRowIndex, int nColIndex) => throw new NotImplementedException();
        }
    }
