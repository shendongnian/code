    public void deleteSegment(int i)
    {
        //Remove from the List
        lineSegmentRep.Remove(lineSegmentRep[i]);
        //Now, destroy its object+script
        Destroy(lineSegmentRep[i].gameObject);
    }
