    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class ChangeScale : MonoBehaviour
    {
        public GameObject objectToScale;
    
        private float _currentScale = InitScale;
        private const float TargetScale = 1.1f;
        private const float InitScale = 0f;
        private const int FramesCount = 100;
        private const float AnimationTimeSeconds = 2;
        private float _deltaTime = AnimationTimeSeconds / FramesCount;
        private float _dx = (TargetScale - InitScale) / FramesCount;
        private bool _upScale = true;
    
        private IEnumerator ScaleUp()
        {
            bool upscaling = true;
            while (upscaling)
            {
                _currentScale += _dx;
                if (_currentScale > TargetScale)
                {
                    upscaling = false;
                    _currentScale = TargetScale;
                }
                objectToScale.transform.localScale = Vector3.one * _currentScale;
                yield return new WaitForSeconds(_deltaTime);
            }
        }
    
        private IEnumerator ScaleDown()
        {
            bool downscaling = true;
            while (downscaling)
            {
                _currentScale -= _dx;
                if (_currentScale < InitScale)
                {
                    downscaling = false;
                    _currentScale = InitScale;
                }
                objectToScale.transform.localScale = Vector3.one * _currentScale;
                yield return new WaitForSeconds(_deltaTime);
            }
        }
    
        public void Scale(bool scaleUp)
        {
            if (scaleUp)
                StartCoroutine(ScaleUp());
            else
                StartCoroutine(ScaleDown());
        }
    }
