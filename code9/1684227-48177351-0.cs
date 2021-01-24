      class Program
      {
          public static Block[,] blocks = new Block[10000, 10000];
          public static BlockType[] blockTypes = new BlockType[5];
          static void Main(string[] args)
          {
              populate();
          }
          static void populate()
          {
              for (int x = 0; x < 10000; x++)
              {
                  for (int y = 0; y < 10000; y++)
                  {
                      blocks[x, y] = new Block(blockTypes[1]);
                  }
              }
          }
      }
