        internal void BeginTextMode()
        {
            if (_streamMode != StreamMode.Text)
            {
                _streamMode = StreamMode.Text;
                _content.Append("BT\n");
                // Text matrix is empty after BT
                _gfxState.RealizedTextPosition = new XPoint();
                _gfxState.ItalicSimulationOn = false;
            }
        }
