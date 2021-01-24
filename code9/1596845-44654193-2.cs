      var nonEmptyLines = File.ReadAllLines(File).
                            SkipWhile(cell=>{var arr=cell.Split(',');if(string.IsNullOrWhiteSpace(cell)){
                                return true;
                            }
                                else
                            {
                                return false;
                            }
                            });
