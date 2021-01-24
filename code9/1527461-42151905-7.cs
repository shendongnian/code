	using UnityEngine;
	using System.Collections;
	using UniRx;
	[RequireComponent(typeof(MeshRenderer))]
	[RequireComponent(typeof(SwipeListener))]
	public class ColorFlasher : MonoBehaviour
	{
		[SerializeField]
		private Material _left;
		[SerializeField]
		private Material _right;
		private Material _normal;
		[SerializeField]
		private float _flashPeriod = .1f;
		private MeshRenderer _meshRenderer;
		private SwipeListener _inputListener;
		void Start()
		{
			_meshRenderer = GetComponent<MeshRenderer>();
			_normal = _meshRenderer.material;
			_inputListener = GetComponent<SwipeListener>();
			_inputListener.InputStream
				.Subscribe(x => StartCoroutine(FlashColor(x)));
			_inputListener.InputStream.Subscribe(x => Debug.Log(x));
		}
		private IEnumerator FlashColor(float swipe)
		{
			Material material = _normal;
			if (swipe > 0)
				material = _right;
			else if (swipe < 0)
				material = _left;
			_meshRenderer.material = material;
			yield return new WaitForSeconds(_flashPeriod);
			_meshRenderer.material = _normal;
		}
	}
