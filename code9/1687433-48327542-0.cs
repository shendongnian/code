    void SwapFrame(Frame IN_pSrcFrame, Frame IN_pDestFrame)
    {    
        var firstFrameContent = IN_pSrcFrame.Content;
        var secondFrameContent = IN_pDestFrame.Content;
        //detach contents
        IN_pSrcFrame.Content = null; 
        IN_pDestFrame.Content = null;
        IN_pSrcFrame.Content = secondFrameContent;
        IN_pDestFrame.Content = firstFrameContent;
    }
