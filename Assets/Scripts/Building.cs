using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Building:MonoBehaviour
{
    public int building_id;
    public string building_name;
    public int building_level;
    public string building_disc;
    public string building_type;
    public Vector2 building_diminsion;
    public bool is_building_damaged;
    public Sprite building_image;
    protected Building() { }
}
