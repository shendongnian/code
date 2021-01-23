    public void sort(int[] A)
        {
            int i, j;
            int N = A.Length;
            for (j = 1; j < N; j++)
            {
                for (i = j; i > 0 && A[i] < A[i - 1]; i--)
                {
                    but[i - 1].BackColor = Color.Green;
                    System.Threading.Thread.Sleep(400);
                    but[i].BackColor = Color.GreenYellow;
                    System.Threading.Thread.Sleep(400);
                    but[i].Refresh();
                    but[i - 1].Refresh();
                    exchange(A, i, i - 1);
                    //Try adding these 2 lines
                    but[i-1].BackColor = SystemColors.Control;
                    but[i].BackColor = SystemColors.Control;
                }
            }
        }
