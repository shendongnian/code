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
        private bool _upScaling = false;
        private bool _downScaling = false;
    
        private IEnumerator ScaleUp()
        {
            _upScaling = true;
            while (_upScaling)
            {
                _currentScale += _dx;
                if (_currentScale > TargetScale)
                {
                    _upScaling = false;
                    _currentScale = TargetScale;
                }
                objectToScale.transform.localScale = Vector3.one * _currentScale;
                yield return new WaitForSeconds(_deltaTime);
            }
        }
    
        private IEnumerator ScaleDown()
        {
            _downScaling = true;
            while (_downScaling)
            {
                _currentScale -= _dx;
                if (_currentScale < InitScale)
                {
                    _downScaling = false;
                    _currentScale = InitScale;
                    droid.SetActive(false);
                }
                objectToScale.transform.localScale = Vector3.one * _currentScale;
                yield return new WaitForSeconds(_deltaTime);
            }
        }
    
        public void Scale(bool scaleUp)
        {
            if (!droid.activeInHierarchy) {
                droid.SetActive(true);
                StartCoroutine(ScaleUp());
            }
            if (_downScaling)
                StartCoroutine(ScaleUp());
            else
                StartCoroutine(ScaleDown());
        }
    }
