using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint Tank;
    public TurretBlueprint Helicopter;

    BuildManager buildManager;
    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectStandardTurret()
    {
        Debug.Log("Tank");
        buildManager.SelectedTurretToBuild(Tank);
    }
    public void PurchaseAnotherTurret()
    {
        Debug.Log("Helicopter");
        buildManager.SelectedTurretToBuild(Helicopter);

    }
    public void SoldierTurret()
    {
        buildManager.SelectedTurretToBuild(standardTurret);
    }

}
