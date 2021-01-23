                if (_Items.Count == _Uprices.Count)
            {
                for (int i = 0; i < _Items.Count; i++)
                {
                    tw.WriteLine(String.Format("{0} {1}",_Items[i],_Uprices[i]));
                }
            }
