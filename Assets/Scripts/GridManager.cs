using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : Singleton<GridManager>
{
    public AstarPath a_plus;
    public Transform grid_prefab;
    Transform t = null;
    // Start is called before the first frame update
    void Start()
    {
        int grid_width = Mathf.RoundToInt(Camera.main.aspect * 10);
        int grid_height = 10;
        Vector3 first_pos=Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        a_plus.data.graphs[0].active.data.gridGraph.SetDimensions(grid_width,grid_height, 1);
        a_plus.data.graphs[0].Scan();
        for (int i=0;i<grid_width;i++) {
            for (int j = 0; j < grid_height; j++)
            {
                t=Instantiate(grid_prefab);
                t.name = i + "_" + j;
                t.SetParent(transform);
                t.localPosition = new Vector2(first_pos.x+i+.5f, first_pos.y+j + .5f);

            }
        }
        
    }
    public bool AssignOccupied(List<GameObject> cells_list) {
        bool isOccupied = false;
        foreach (GameObject cell in cells_list)
        {
            if (!cell.GetComponent<GridCell>().isFree) {
                isOccupied = true;
                break;
            }
            cell.GetComponent<GridCell>().isFree = false;
            cell.layer = 1;
            isOccupied = false;
            
        }
        a_plus.Scan();
        return isOccupied;
    }
    public bool  AssignOneOccupied(GameObject cell) {
        bool isOccupied = false;
        if (!cell.GetComponent<GridCell>().isFree)
        {
            isOccupied = true;
        }
        cell.GetComponent<GridCell>().isFree = false;
        cell.layer = 1;
        a_plus.Scan();
        return isOccupied;
    }
    public void UnAssignOneOccupied(GameObject cell)
    {  
        cell.GetComponent<GridCell>().isFree = true;
        cell.layer = 0;
        a_plus.Scan();
    }
    public bool GetTargetCells(int row,int col) {
        List<GameObject> hitted_area_Cells = new List<GameObject>();
        int cell_x = 0;
        int cell_y = 0;
        GameObject hitted_obj=null;
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider.tag == "GridCell") {
            hitted_obj = hit.collider.gameObject;

        }
            string[] splitted_name = hitted_obj.name.Split('_');
            cell_x = int.Parse(splitted_name[0]);
            cell_y = int.Parse(splitted_name[1]);
            for (int i = cell_x; i < row + cell_x; i++)
            {
                for (int j = cell_y; j < col + cell_y; j++)
                {
                    hitted_area_Cells.Add(GameObject.Find(i + "_" + j));
                }
            }
        
        return AssignOccupied(hitted_area_Cells);

        
    }

}
