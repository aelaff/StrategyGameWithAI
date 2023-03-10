using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProdUnitBuilding : Building
{
    public List<Soldier> soldiers_list;

   [Serializable]
    public class Soldier
    {
        public int soldier_level;
        public string soldier_name;
        public string soldier_disc;
        public Sprite soldier_image;
        public int soldier_diffence_power;
        public int soldier_attack_power;
    }
}
