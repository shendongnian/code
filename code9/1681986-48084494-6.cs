    var inDrag = false;
    var drags = new List<MouseInfo>();
    var clicks = new List<MouseInfo>();
    var beginTime = 0L;
    for (var i = 0; i < moves.Count; ++i) {
        var curMove = moves[i];
        var wasDrag = inDrag;
        inDrag = curMove.b == 1 && (inDrag || (i + 1 < moves.Count ? moves[i + 1].b == 1 : false));
        if (inDrag) {
            if (wasDrag)
                drags.Add(new MouseInfo { t = beginTime, x = curMove.x, y = curMove.y, b = curMove.b });
            else {
                drags.Add(curMove);
                beginTime = curMove.t;
            }
        }
        else {
            if (curMove.b != 0)
                clicks.Add(curMove);
        }
    }
