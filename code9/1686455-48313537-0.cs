    /*
    UINT WINAPI MapVirtualKey(
      _In_ UINT uCode,
      _In_ UINT uMapType
    ); */
    const uint MAPVK_VK_TO_CHAR = 0x02;
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    static extern uint MapVirtualKey(uint uCode, uint uMapType);
    
      private void TextBox1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
      {
          if (e.KeyCode != Keys.Back)
          {
              string _Char;
              e.SuppressKeyPress = true;
              string KeyModifiers = string.Join("+", e.Modifiers
                                          .ToString().Split(',')
                                          .Where(s => s != "None"))
                                          .ToUpper();
              if (e.KeyCode >= Keys.F1 & e.KeyCode <= Keys.F24)
              {
                  _Char = e.KeyCode.ToString();
              } else {
                  _Char = ((char)(MapVirtualKey((uint)e.KeyCode, MAPVK_VK_TO_CHAR))).ToString();
              }
              TextBox1.Text = KeyModifiers + ((KeyModifiers.Length > 0 && _Char != "\0" ? "+ " : "") + _Char);
          } else {
              TextBox1.Text = "";
          }
      }
