        public static void createLettering(List<ARRegister> lines)
        {
            // We build a new LELettering piece
            Lettrage graph = CreateInstance<Lettrage>();
            LELettering piece = new LELettering();
            piece.Status = ListStatus._OPEN;
            piece.LetteringDateTime = DateTime.Now;
            piece = graph.ARLetteringPiece.Insert(piece);
            // We fill the checked lines with the autonumber of the piece
            bool lineUpdated = false;
            foreach (ARRegister line in lines)
            {
                if (line.Selected.Value)
                {
                    if (!lineUpdated)
                    {
                        piece.BranchID = line.BranchID;
                        piece.AccountID = line.CustomerID;
                        piece = graph.ARLetteringPiece.Update(piece);
                        graph.Actions.PressSave();
                    }
                    line.GetExtension<ARRegisterLeExt>().LettrageCD = graph.ARLetteringPiece.Current.LetteringCD;
                    graph.ARlines.Update(line);
                    lineUpdated = true;
                }
            }
            // If there are lines in our piece, we save it
            // It saves our lettering piece and our modifications on the ARLines
            if (lineUpdated)
            {
                graph.Actions.PressSave();
            }
        }
