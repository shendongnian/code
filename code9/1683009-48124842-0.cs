    .....
    decimal sum1 = 0, sum2 = 0,sum3 = 0;
    for (int i = 0; i < dgw.RowCount; i++)
    {
        // we only sum the first and third column as an example
        sum1 += Convert.ToDecimal(dgw.Rows[i].Cells[4].Value);
        sum2 += Convert.ToDecimal(dgw.Rows[i].Cells[5].Value);
        sum3 += Convert.ToDecimal(dgw.Rows[i].Cells[1].Value);//Second cell
    }
    // add the total row
    string[] totalrow = new string[] { sum1.ToString(), "", sum2.ToString(),"", sum3.ToString() };
    dgw.Rows.Add(totalrow);
    .....
