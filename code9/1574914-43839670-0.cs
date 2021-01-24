    int[] MonthNo1 = new int[Legacy.Month1.Length];
    for (int i = 0; i < Legacy.Month1.Length; i++)
    {
          switch (Legacy.Month1[i])
          {
              case "January ":
                  MonthNo1[i] = 1;
                  break;
              case "February ":
                  MonthNo1[i] = 2;
                  break;
          }
    }
