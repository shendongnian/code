    public override bool MoveToNextAttribute() {
                if ( !IsInReadingStates() || nodeType == XmlNodeType.EndElement )
                    return false;
                readerNav.LogMove( curDepth );
                readerNav.ResetToAttribute( ref curDepth );
                if ( readerNav.MoveToNextAttribute( ref curDepth ) ) {
                    nodeType = readerNav.NodeType;
                    if ( bInReadBinary ) {
                        FinishReadBinary();
                    }
                    return true;
                }
                readerNav.RollBackMove( ref curDepth );
                return false;
            }
