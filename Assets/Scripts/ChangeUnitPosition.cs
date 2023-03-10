using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeUnitPosition : MonoBehaviour
{
    GameObject clicked_cell;
    bool isClicked = false;

    private void OnMouseDown()
    {
        isClicked = true;
        if (clicked_cell != null) {
            clicked_cell.GetComponent<SpriteRenderer>().color = Color.white;
        }
           
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && isClicked) {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider.tag == "GridCell" )
            {
                clicked_cell = hit.collider.gameObject;
                transform.parent.parent.GetChild(0).position = clicked_cell.transform.position;
                clicked_cell.GetComponent<SpriteRenderer>().color = Color.red;
               
            }
            isClicked = false;
        }
        
    }
  
}
