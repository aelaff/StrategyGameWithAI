using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingPooler : Singleton<BuildingPooler>
{

    public Transform buildings_scrollview;
    public Transform building_item_prefab;



    // Start is called before the first frame update
    void Start()
    {
        for (int i=0;i<transform.childCount;i++) {
            Building building_prop = transform.GetChild(i).GetComponent<Building>();
            Transform tmp = Instantiate(building_item_prefab);
            tmp.GetChild(0).GetComponent<Image>().sprite = building_prop.building_image;
            tmp.GetChild(1).GetComponent<Text>().text = building_prop.building_name;
            tmp.GetChild(2).GetComponent<Text>().text = building_prop.building_diminsion.x + "*" + building_prop.building_diminsion.y;
            tmp.name= building_prop.building_id+"";
            tmp.SetParent(buildings_scrollview);
        }
    }
    public Building FindBuilding(int building_id)
    {
        Building building = null;
        for (int i = 0; i < transform.childCount; i++)
        {
            Building building_prop = transform.GetChild(i).GetComponent<Building>();
            if (building_prop.building_id == building_id) {
                building = building_prop;
            }
        }
        return building;
    }

   
}
