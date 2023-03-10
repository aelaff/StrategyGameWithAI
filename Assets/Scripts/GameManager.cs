using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public Transform info_panel;
    public Transform internal_info_panel;
    public Transform units_scroll;
    public Transform units_element;
    public Vector3 clicked_builing_pos;
    public GameObject building_panel;
    public GameObject building_BTN;
    public bool is_dragging_state = false;

    
    public void SetInfoPanel(Building b) {
        if (!is_dragging_state) { 
            info_panel.gameObject.SetActive(true);
            internal_info_panel.GetChild(0).GetChild(0).GetComponent<Image>().sprite = b.building_image;
            internal_info_panel.GetChild(0).GetChild(1).GetComponent<Text>().text = b.building_name +" Building";
            internal_info_panel.GetChild(0).GetChild(2).GetComponent<Text>().text = "Size : " + b.building_diminsion.x+"*"+b.building_diminsion.y;
            internal_info_panel.GetChild(1).GetComponent<Text>().text = b.building_disc;
            if (b.building_type == "Normal")
            {
                internal_info_panel.GetChild(2).gameObject.SetActive(false);
            }
            else if (b.building_type == "Producing")
            {
                ProdUnitBuilding prod = (ProdUnitBuilding)b;
                internal_info_panel.GetChild(2).gameObject.SetActive(true);
                RemoveUnits();
                foreach (ProdUnitBuilding.Soldier sol in prod.soldiers_list)
                {
                    Transform t = Instantiate(units_element);
                    t.GetChild(0).GetComponent<Image>().sprite = sol.soldier_image;
                    t.GetChild(1).GetComponent<Text>().text = sol.soldier_name;
                    t.SetParent(units_scroll);
                }

            }
        }
    }
    void RemoveUnits() {
        for (int i = 0; i < units_scroll.childCount; i++) {
            Destroy(units_scroll.GetChild(i).gameObject);
        }
    }
}
