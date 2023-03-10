using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingFactory: Singleton<BuildingFactory>
{
    public Building CreateBuilding(string buildingType) {
        Building building = null;
        if (buildingType.Equals("Normal"))
        {
            building = new NormalBuilding();
        }
        else if (buildingType.Equals("Producing"))
        {
            building = new ProdUnitBuilding();
        }
        return building;
    }
}
