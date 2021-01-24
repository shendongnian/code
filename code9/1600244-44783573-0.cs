    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class TouchInputHandler : AbstractInputHandler
    {
        private const int SWIPE_MIN_DISTANCE = 35;
        private Vector2 touchStartPoint;
        private Vector2 touchMovePoint;
        void Update()
        {
            Touch[] touches = Input.touches;
            if(touches.Length == 1)
            {
                Touch firstTouch = touches[0];
                if(firstTouch.phase == TouchPhase.Began)
                {
                    this.touchStartPoint = firstTouch.position;
                    this.currentDirection = Constants.Direction.NONE;
                    fireNextDirectionChanged(currentDirection);
                }
                else if(firstTouch.phase == TouchPhase.Moved)
                {
                    this.touchMovePoint = firstTouch.position;
                    if(Vector2.Distance(touchStartPoint, touchMovePoint) > SWIPE_MIN_DISTANCE)
                    {
                        detectSwipeDirection();
                    }
                    touchStartPoint = this.touchMovePoint; // <= NEW !
                }
                //else if(firstTouch.phase == TouchPhase.Stationary)
                //{
                //    touchStartPoint.x = touchMovePoint.x;
                //    touchStartPoint.y = touchMovePoint.y;
                //}
                else if(firstTouch.phase == TouchPhase.Ended)
                {
                    this.currentDirection = Constants.Direction.NONE;
                    fireNextDirectionChanged(Constants.Direction.NONE);
                }
            }
        }
        private void detectSwipeDirection()
        {
            float xDiff = touchMovePoint.x - touchStartPoint.x;
            float yDiff = touchMovePoint.y - touchStartPoint.y;
            Constants.Direction nextDirection;
            bool yGreater = Mathf.Abs(yDiff) >= Mathf.Abs(xDiff);
            if(yGreater)
            {
                // direction is up or down
                nextDirection = yDiff < 0 ? Constants.Direction.DOWN : Constants.Direction.UP;
            }
            else
            {
                // direction is left or right
                nextDirection = xDiff < 0 ? Constants.Direction.LEFT : Constants.Direction.RIGHT;
            }
            if(nextDirection != this.currentDirection)
            {
                fireNextDirectionChanged(nextDirection);
                this.currentDirection = nextDirection;
            }
        }
    }
