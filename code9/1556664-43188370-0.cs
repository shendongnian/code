    class MyForm : Form
    {
        private bool _processing;
  
        private void OnMousedown(....) // really depends on what you use, 
            // Click/doubleclick/Up/down - concept is the same
        {
            if (_processing)
                return;
            _processing = true;
            // do something 
            . . . . . . 
            _processing = false;
         }
    . . . . . 
