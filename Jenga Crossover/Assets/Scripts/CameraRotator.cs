using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    [SerializeField] private Transform[] _targets;
	[SerializeField] private float _distanceFromTarget = 25f;
	[SerializeField] private float _heightIncrement = 10f;

	private Vector3 _previousPos;
	private Camera _camera;
	private Transform _currentTarget;
	private int _targetIndex = 0;

	private void Start()
	{
		_camera = GetComponent<Camera>();
		_currentTarget = _targets[_targetIndex];
		_camera.transform.position = _currentTarget.position;
		_camera.transform.Translate(new Vector3(0, _heightIncrement, -_distanceFromTarget));
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.D)) 
		{
			_targetIndex = (_targetIndex + 1) % _targets.Length;
			_currentTarget = _targets[_targetIndex];
		}
	}

	private void LateUpdate()
	{
		if (Input.GetMouseButtonDown(0))
		{
			_previousPos = _camera.ScreenToViewportPoint(Input.mousePosition);
		}

		if (Input.GetMouseButton(0))
		{
			Vector3 direction = _previousPos - _camera.ScreenToViewportPoint(Input.mousePosition);

			_camera.transform.position = _currentTarget.position;

			_camera.transform.Rotate(new Vector3(1, 0, 0), direction.y * 180);
			_camera.transform.Rotate(new Vector3(0, 1, 0), -direction.x * 180, Space.World);
			_camera.transform.Translate(new Vector3(0, _heightIncrement, -_distanceFromTarget));

			_previousPos = _camera.ScreenToViewportPoint(Input.mousePosition);
		}
	}
}
