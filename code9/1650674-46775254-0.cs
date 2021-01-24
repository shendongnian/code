    for (int i = 0; i < ????; i++)
    {
        int ii = i;
        myDGV[i].Scroll += (sender, e) => {
            if(e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                int val = myDGV[ii].FirstDisplayedScrollingRowIndex;
                myPanel[ii].VerticalScroll.Value = val;
            }
        };
    }
    }
