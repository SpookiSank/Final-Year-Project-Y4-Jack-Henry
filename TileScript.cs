using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{

    public Point GridPosition { get; private set; }

    public Vector2 WorldPosition
    {
        get
        {
            return new Vector2(transform.position.x + (GetComponent<SpriteRenderer>().bounds.size.x / 2), transform.position.y - (GetComponent<SpriteRenderer>().bounds.size.y / 2));
        }



    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUpGrid(Point gridPosition, Vector3 worldPosition, Transform parent)
    {
        this.GridPosition = gridPosition;
        transform.position = worldPosition;
        transform.SetParent(parent);
        LevelManagement.Instance.Tiles.Add(gridPosition, this);
    
    }

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            PlaceTower();
        }
        
    }

    private void PlaceTower()
    {
       GameObject tower = Instantiate(GameManagment.Instance.TowerPre, transform.position, Quaternion.identity);
        tower.GetComponent<SpriteRenderer>().sortingOrder = GridPosition.Y;

        tower.transform.SetParent(transform);
    }
}
