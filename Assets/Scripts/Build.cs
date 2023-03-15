using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Build : MonoBehaviour
{
    public Color hoverColor;
    private Color startColor;

    public GameObject turret;

    public Vector3 Offset;
    private Renderer rend;

    public TurretBlueprint turretBlueprint;
    BuildManager buildManager;
	void Start()
	{
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;

		buildManager = BuildManager.instance;
	}

	public Vector3 GetBuildPosition()
	{
		return transform.position + Offset;
	}

	void OnMouseDown()
	{
		if (EventSystem.current.IsPointerOverGameObject())
			return;

		if (turret != null)
		{
			buildManager.SelectNode(this);
			return;
		}

		if (!buildManager.CanBuild)
			return;

		BuildTurret(buildManager.GetTurretToBuild());
	}

	void BuildTurret(TurretBlueprint blueprint)
	{
		if (Player.Money < blueprint.cost)
		{
			Debug.Log("Not enough money to build that!");
			return;
		}

		Player.Money -= blueprint.cost;

		GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
		turret = _turret;

		turretBlueprint = blueprint;

		GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
		Destroy(effect, 5f);

		Debug.Log("Turret build!");
	}


	public void SellTurret()
	{
		Player.Money += turretBlueprint.GetSellAmount();

		GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
		Destroy(effect, 5f);

		Destroy(turret);
		turretBlueprint = null;
	}

	void OnMouseEnter()
	{
		if (EventSystem.current.IsPointerOverGameObject())
			return;

		if (!buildManager.CanBuild)
			return;

		if (buildManager.HasMoney)
		{
			rend.material.color = hoverColor;
		}
		else
		{
		//	rend.material.color = notEnoughMoneyColor;
		}

	}

	void OnMouseExit()
	{
		rend.material.color = startColor;
	}
}
