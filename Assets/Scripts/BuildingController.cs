using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

//[Serializable]
//public class StringEvent : UnityEvent<string> { }
public class BuildingController : MonoBehaviour
{

    GameObject intiated_object;
    bool is_choosen = false;
    bool is_dragging = false;
    Building b;
    BoxCollider2D box_collider;
    Vector3 offset;

    private void Start()
    {
        offset = new Vector3();
    }
    public void AddNewBuilding() {
        is_choosen = true;
        b=BuildingPooler.instance.FindBuilding(int.Parse(name));
        intiated_object = new GameObject();
        intiated_object.AddComponent<SpriteRenderer>();
        intiated_object.GetComponent<SpriteRenderer>().sprite = b.building_image;
        intiated_object.name = b.name;
        box_collider=intiated_object.AddComponent<BoxCollider2D>();
        intiated_object.AddComponent<BuildingClick>();
        box_collider.enabled = false;
        intiated_object.layer = 1;
        Rect sprite_bounds = intiated_object.GetComponent<SpriteRenderer>().sprite.rect;
        offset.x = sprite_bounds.width / 2;
        offset.y = sprite_bounds.height / 2;
    }
    private void FixedUpdate()
    {
        if (is_choosen) {
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(intiated_object.transform.position);
            Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z);
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace + offset);
            intiated_object.transform.position = currentPosition;
            is_dragging = true;
            GameManager.instance.is_dragging_state = true;
        }
        if(Input.GetMouseButtonUp(0)&& is_dragging)
        {
            if (b != null) {
                bool isFree=GridManager.instance.GetTargetCells(Convert.ToInt32(b.building_diminsion.x), Convert.ToInt32(b.building_diminsion.y));
                if (!isFree) {
                    is_choosen = false;
                    is_dragging = false;
                    GameManager.instance.is_dragging_state = false;
                    box_collider.enabled = true;
                    GameManager.instance.building_panel.SetActive(false);
                    GameManager.instance.building_BTN.SetActive(true);
                }
            }
        }
    }
  
}
