    var pts = _context.PT
                    .Include(p => p.CH)
                    .Where(p => p.PTcol == selectedID)
                    .Select(p => new PT_CH_ViewModel()
                    {
                        PTCol1 = pt.Col1,
                        PTCol2 = pt.Col2,
                        PTCol3 = pt.Col3,
                        CHCol1 = pt.CH.Col1,
                        CHCol2 = pt.CH.Col2
                    });
    return View(pts);
