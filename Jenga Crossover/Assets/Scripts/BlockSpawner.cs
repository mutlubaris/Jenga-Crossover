using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _blockPrefab;
	[SerializeField] private Vector3[] _blockLocalPos = new Vector3[6];
	[SerializeField] private float _heightStep;

	private List<GameObject> _blocks = new List<GameObject>();

	private void Update()
	{
		if (Input.GetKeyUp(KeyCode.S))
		{
			GameObject newBlock = Instantiate(_blockPrefab, transform);
			newBlock.transform.localPosition = _blockLocalPos[_blocks.Count % 6];
			newBlock.transform.localPosition += Vector3.up * (_blocks.Count / 6) * _heightStep;
			switch (_blocks.Count % 6)
			{
				case 3:
				case 4:
				case 5:
					newBlock.transform.Rotate(new Vector3(0, 90, 0));
					break;
				default:
					break;
			}
			_blocks.Add(newBlock);
		}
	}
}
