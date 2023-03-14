using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    public Color hoverColor;
    private Color startColor;

    private GameObject turret;
    public Vector3 Offset;
    private Renderer rend;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Can't build there!");
            return;
        }

        GameObject turretTobuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretTobuild, transform.position+ Offset, transform.rotation);
    }
    private void OnMouseEnter()
    {
        rend.material.color = hoverColor; 
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
