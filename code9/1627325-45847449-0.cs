                int position = numProcess.SelectionStart;
                if (numProcess.Text.Length <= position)
                {
                   ...
                }
                else
                {
                    string firstPiece = numProcess.Text.Substring(0, position);
                    string secondPiece = numProcess.Text.Substring(position + 1);
                    numProcess.Text = firstPiece + secondPiece ;
                    numProcess.SelectionStart = position;
                    numProcess.SelectionLength = 0;
                }
