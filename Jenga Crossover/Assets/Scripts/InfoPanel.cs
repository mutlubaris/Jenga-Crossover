using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoPanel : MonoBehaviour
{
	private TextMeshProUGUI _text;

	private void Start()
	{
		_text = GetComponentInChildren<TextMeshProUGUI>();
	}

	private void OnEnable()
	{
		EventManager.OnBlockRightClicked.AddListener(SetPanelText);
	}

	private void OnDisable()
	{
		EventManager.OnBlockRightClicked.RemoveListener(SetPanelText);
	}

	private void SetPanelText(Block block)
	{
		_text.SetText(block.grade + ": " + block.domain + "\n\n" + block.cluster + "\n\n" + block.standardid + ": " + block.standarddescription);
	}
}
