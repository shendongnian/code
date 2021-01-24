    public override bool OnTouchEvent(MotionEvent e)
        {
            float x = e.RawX;
            float y = e.RawY;
            var dragView = Element as DraggableView;
            switch (e.Action)
            {
                case MotionEventActions.Down:
                    if (dragView.DragMode == DragMode.Touch)
                    {
                        if (!touchedDown)
                        {
                            if (firstTime)
                            {
                                originalX = GetX();
                                originalY = GetY();
                                firstTime = false;
                            }
                            dragView.DragStarted();
                        }
                        touchedDown = true;
                    }
                    dX = x - this.GetX();
                    dY = y - this.GetY();
                    break;
                case MotionEventActions.Move:
                    //if (touchedDown)
                    //{
                        if (dragView.DragDirection == DragDirectionType.All || dragView.DragDirection == DragDirectionType.Horizontal)
                        {
                            SetX(x - dX);
                        }
                        if (dragView.DragDirection == DragDirectionType.All || dragView.DragDirection == DragDirectionType.Vertical)
                        {
                            SetY(y - dY);
                        }
                    //}
                    break;
                case MotionEventActions.Up:
                    touchedDown = false;
                    dragView.DragEnded();
                    break;
                case MotionEventActions.Cancel:
                    touchedDown = false;
                    break;
            }
            
            return true;
        }
