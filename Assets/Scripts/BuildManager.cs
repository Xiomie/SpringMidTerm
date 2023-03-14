using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;


    public GameObject StandardTurretPrefab;
    public GameObject turretToBuild;

    private void Start()
    {
        turretToBuild = StandardTurretPrefab;
    }
    public GameObject GetTurretToBuild ()
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
}
