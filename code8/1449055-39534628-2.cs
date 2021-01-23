      private void SetText(Label l, string text){
          if(l.InvokeRequired)
          {
              MethodInvoker mI = () => { 
                  l.Text = text;
                  //representing any other stuff you want to do in a func
                  lbl_Bytes_Total.Text = io.total_KB.ToString("N0");
                  lbl_Uncompressed_Bytes.Text = io.mem_Used.ToString("N0");
                  pgb_Load_Progress.Value = (int)pct;
              }; 
              BeginInvoke(mI);
          } 
          else
          {
              l.Text = text;
          }
      }
