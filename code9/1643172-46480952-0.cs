    class DrawCanvas : View
    {
         MyHandler mHandler;
         ...
         private void init(Context ctx)
         {
             mHandler = new MyHandler(this);
             mContext = ctx;
             black = new Paint() { Color = Color.Black,TextSize=56 };
             white = new Paint() { Color = Color.White, TextSize = 56 };
         }
         ...
         protected override void OnDraw(Canvas canvas)
         {
             TestDraw(canvas);
             mHandler.SendEmptyMessageDelayed(1,33);
         }
         ...
         public class MyHandler : Handler
         {
             private DrawCanvas drawCanvas;
             public MyHandler(DrawCanvas drawCanvas)
             {
                 this.drawCanvas = drawCanvas;
             }
             public override void HandleMessage(Message msg)
             {
                 base.HandleMessage(msg);
                 drawCanvas.Invalidate();
             }
         }
    }
