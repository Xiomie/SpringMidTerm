using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class NodeUI : MonoBehaviour
{
	public GameObject ui;


	public TextMeshProUGUI sellAmount;

	private Build target;

	public void SetTarget(Build _target)
	{
		target = _target;

		transform.position = target.GetBuildPosition();

		sellAmount.text = "$" + target.turretBlueprint.GetSellAmount();

		ui.SetActive(true);
	}

	public void Hide()
	{
		ui.SetActive(false);
	}

	public void Sell()
	{
		target.SellTurret();
		BuildManager.instance.DeselectNode();
	}

}
