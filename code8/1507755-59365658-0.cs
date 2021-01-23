    using System;
    using UnityEngine;
    using UnityEngine.Events;
    using Utilities;
    public class SwipeManager : MonoBehaviour {
  
      public float swipeThreshold = 40f;
      public float timeThreshold = 0.3f;
      public UnityEvent onSwipeLeft;
      public UnityEvent onSwipeRight;
      public UnityEvent onSwipeUp;
      public UnityEvent onSwipeDown;
      private Vector2 _fingerDown;
      private DateTime _fingerDownTime;
      private Vector2 _fingerUp;
      private DateTime _fingerUpTime;
      private void Update () {
        if (Input.GetMouseButtonDown(0)) {
          _fingerDown = Input.mousePosition;
          _fingerUp = Input.mousePosition;
          _fingerDownTime = DateTime.Now;
        }
    
        if (Input.GetMouseButtonUp(0)) {
          _fingerDown = Input.mousePosition;
          _fingerUpTime = DateTime.Now;
          CheckSwipe();
        }
    
        foreach (var touch in Input.touches) {
          if (touch.phase == TouchPhase.Began) {
            _fingerDown = touch.position;
            _fingerUp = touch.position;
            _fingerDownTime = DateTime.Now;
          }
      
          if (touch.phase == TouchPhase.Ended) {
            _fingerDown = touch.position;
            _fingerUpTime = DateTime.Now;
            CheckSwipe();
          }
        }
      }
      private void CheckSwipe() {
        var duration = (float)_fingerUpTime.Subtract(_fingerDownTime).TotalSeconds;
        var dirVector = _fingerUp - _fingerDown;
    
        if (duration > timeThreshold) return;
        if (dirVector.magnitude < swipeThreshold) return;
    
        var direction = dirVector.Rotation(180f).Round();
        print(direction);
    
        if (direction >= 45 && direction < 135) onSwipeUp.Invoke();
        else if (direction >= 135 && direction < 225) onSwipeRight.Invoke();
        else if (direction >= 225 && direction < 315) onSwipeDown.Invoke();
        else if (direction >= 315 && direction < 360 || direction >= 0 && direction < 45) onSwipeLeft.Invoke();
      }
    }
