        public static void AddScrollBar(Ex.Worksheet ExSH, int StartCellRow, int StartCellColumn, int EndCellRow, int EndCellColumn, int ReferenceRow, int ReferenceColumn)
        {
            int Left, Top, Right, Bottom;
            if(StartCellRow > EndCellRow || StartCellColumn > EndCellColumn) { throw new System.Exception("EROR: Please check Start- and Endcell reference or flip it!"); }
            Left = (int)(ExSH.Cells[StartCellRow, StartCellColumn] as Ex.Range).Left;
            Top = (int)(ExSH.Cells[StartCellRow, StartCellColumn] as Ex.Range).Top;
            Right = (int)((ExSH.Cells[EndCellRow, EndCellColumn] as Ex.Range).Left + (ExSH.Cells[EndCellRow, EndCellColumn] as Ex.Range).Width);
            Bottom = (int)((ExSH.Cells[EndCellRow, EndCellColumn] as Ex.Range).Top + (ExSH.Cells[EndCellRow, EndCellColumn] as Ex.Range).Height);
            Ex.Shape SB = ExSH.Shapes.AddFormControl(Ex.XlFormControl.xlScrollBar, Left, Top, Right - Left, Bottom - Top);
            SB.ControlFormat.Value = CurrentValue;
            SB.ControlFormat.Min = MinValue;
            SB.ControlFormat.Max = MaxValue;
            SB.ControlFormat.LinkedCell = "A" + ReferenceRow.ToString();
        }
