      private void testDetToolStripMenuItem_Click(object sender, EventArgs e)
            {
                cc_payroll.pyrl_cls_master.ClsPayeDetails dd = ClsPayeDetails.get_paydetail_byrow(2);
                Console.WriteLine(dd.FinancialYear.ToString());
                Console.WriteLine(dd.lowerLimit.ToString());
                Console.WriteLine(dd.upperLimit.ToString());
                Console.WriteLine(dd.percenTage.ToString());
                Console.WriteLine(dd.adjust.ToString());
              
            }
