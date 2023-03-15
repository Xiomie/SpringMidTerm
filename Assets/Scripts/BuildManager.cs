using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;


    public GameObject StandardTurretPrefab;
    public TurretBlueprint turretToBuild;
    public GameObject AnotherTurretPrefab;
    public GameObject Soldier;

    public GameObject buildEffect;
    public GameObject sellEffect;

    public Build selectedNode;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return Player.Money >= turretToBuild.cost; } }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one buildmanager in this scene");
            return;
        }
        instance = this;
    }

    public NodeUI nodeUI;
    public void BuildTurretOn(Build node)
    {
        if (Player.Money < turretToBuild.cost)
        {
            Debug.Log("Not Enough Money");
        }
        Player.Money -= turretToBuild.cost;

       GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
    }

    public void SelectedTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    public void SelectNode(Build node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }
    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }
}
