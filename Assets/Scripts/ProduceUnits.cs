using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProduceUnits : MonoBehaviour
{
    public GameObject unit_obj;
    public void CreateUnit() {
        unit_obj.transform.GetChild(1).GetChild(0).GetComponent<SpriteRenderer>().sprite = transform.GetChild(0).GetComponent<Image>().sprite;
        Instantiate(unit_obj,GameManager.instance.clicked_builing_pos,Quaternion.identity);
    }

}
