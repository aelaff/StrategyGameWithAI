using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingClick : MonoBehaviour
{

    private void OnMouseDown()
    {
        Building building = BuildingPooler.instance.FindBuilding(int.Parse(name));
        GameManager.instance.SetInfoPanel(building);
        GameManager.instance.clicked_builing_pos = transform.position;
    }
}
