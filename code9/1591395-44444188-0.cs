    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication60
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Date", typeof(DateTime));
                dt.Columns.Add("Amount", typeof(int));
                DataTable dt2 = dt.Clone();
                dt.Rows.Add(new object[] { DateTime.Parse("5/1/17"), 3000 });
                dt.Rows.Add(new object[] { DateTime.Parse("5/2/17"), 4000 });
                dt.Rows.Add(new object[] { DateTime.Parse("5/3/17"), 3000 });
                dt.Rows.Add(new object[] { DateTime.Parse("5/4/17"), 3000 });
                dt.Rows.Add(new object[] { DateTime.Parse("5/5/17"), 3000 });
                dt.Rows.Add(new object[] { DateTime.Parse("5/6/17"), 3000 });
                dt.Rows.Add(new object[] { DateTime.Parse("5/7/17"), 3000 });
                dt.Rows.Add(new object[] { DateTime.Parse("5/8/17"), 3000 });
                dt.Rows.Add(new object[] { DateTime.Parse("5/9/17"), 3000 });
                dt.Rows.Add(new object[] { DateTime.Parse("5/10/17"), 3000 });
                dt.Rows.Add(new object[] { DateTime.Parse("5/11/17"), 4000 });
                for (int rowNumber = 0; rowNumber < dt.Rows.Count; rowNumber++)
                {
                    Boolean exceeds = false;
                    switch (rowNumber)
                    {
                        case 0:
                            exceeds = (int)dt.Rows[rowNumber]["Amount"] + (int)dt.Rows[rowNumber + 1]["Amount"] + (int)dt.Rows[rowNumber + 2]["Amount"] >= 10000 ? true : false;
                            break;
                        case 1:
                            exceeds = ((int)dt.Rows[rowNumber - 1]["Amount"] + (int)dt.Rows[rowNumber]["Amount"] + (int)dt.Rows[rowNumber + 1]["Amount"] >= 10000 ? true : false) ||
                                      ((int)dt.Rows[rowNumber]["Amount"] + (int)dt.Rows[rowNumber + 1]["Amount"] + (int)dt.Rows[rowNumber + 2]["Amount"] >= 10000 ? true : false);
                            break;
                        default:
                            if (rowNumber < dt.Rows.Count - 3)
                            {
                                exceeds = ((int)dt.Rows[rowNumber - 2]["Amount"] + (int)dt.Rows[rowNumber - 1]["Amount"] + (int)dt.Rows[rowNumber]["Amount"] >= 10000 ? true : false) ||
                                          ((int)dt.Rows[rowNumber - 1]["Amount"] + (int)dt.Rows[rowNumber]["Amount"] + (int)dt.Rows[rowNumber + 1]["Amount"] >= 10000 ? true : false) ||
                                          ((int)dt.Rows[rowNumber]["Amount"] + (int)dt.Rows[rowNumber + 1]["Amount"] + (int)dt.Rows[rowNumber + 2]["Amount"] >= 10000 ? true : false);
                            }
                            if (rowNumber == dt.Rows.Count - 2)
                            {
                                exceeds = ((int)dt.Rows[rowNumber - 2]["Amount"] + (int)dt.Rows[rowNumber - 1]["Amount"] + (int)dt.Rows[rowNumber]["Amount"] >= 10000 ? true : false) ||
                                          ((int)dt.Rows[rowNumber - 1]["Amount"] + (int)dt.Rows[rowNumber]["Amount"] + (int)dt.Rows[rowNumber + 1]["Amount"] >= 10000 ? true : false);
                            }
                            if (rowNumber == dt.Rows.Count - 1)
                            {
                                exceeds = ((int)dt.Rows[rowNumber - 2]["Amount"] + (int)dt.Rows[rowNumber - 1]["Amount"] + (int)dt.Rows[rowNumber]["Amount"] >= 10000 ? true : false);
                            }
                            break;
                    }
                    if (exceeds)
                    {
                        dt2.Rows.Add(new object[] { dt.Rows[rowNumber]["Date"], dt.Rows[rowNumber]["Amount"] });
                    }
                }
            }
        }
    }
     
