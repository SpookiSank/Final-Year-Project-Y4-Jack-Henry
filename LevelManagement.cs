using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class LevelManagement : Singleton <LevelManagement>
{
    [SerializeField]
    private GameObject[] tiles;


    public float TileWidth
    {
    get { return tiles[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x;}
    }

    [SerializeField]
    private CameraMovement cameraMovement;


    [SerializeField]
    private Transform map;
    // Start is called before the first frame update

    private Point blueSpawn;
    private Point redSpawn;


    [SerializeField]
    private GameObject bluePortalPre;


    [SerializeField]
    private GameObject redPortalPre;
    public Dictionary<Point, TileScript> Tiles { get; set; }


    void Start()
    {
        CreateLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    

    private void CreateLevel()
    {
        Tiles = new Dictionary<Point, TileScript>();

        string[] mapData = ReadLevelTxt();
     

        int mapXSize = mapData[0].ToCharArray().Length;
        int mapYSize = mapData.Length;

        Vector3 maxTile = Vector3.zero;

        Vector3 startPosition = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));
        for(int y = 0; y < mapYSize; y++)
        {
            char[] newTile = mapData[y].ToCharArray();
            for(int x = 0; x < mapXSize; x++)
            {

             SetTile(newTile[x].ToString() ,x,y, startPosition);

            }

        }
        maxTile = Tiles[new Point(mapXSize - 1, mapYSize - 1)].transform.position;
        cameraMovement.CameraLimits(new Vector3(maxTile.x + TileWidth, maxTile.y - TileWidth));

        SpawnPortal();
    }

    private void SetTile(string tileType, int x, int y, Vector3 startPosition)
    {
        int tileIndex = int.Parse(tileType);

        TileScript newTile = Instantiate(tiles[tileIndex]).GetComponent<TileScript>();
  

        newTile.SetUpGrid(new Point(x, y), new Vector3(startPosition.x + (TileWidth * x), startPosition.y - (TileWidth * y), 0), map);
        

       

     
    }

    private string[] ReadLevelTxt()
    {
        TextAsset data = Resources.Load("Level1") as TextAsset;
        string tempData = data.text.Replace(Environment.NewLine, string.Empty);

        return tempData.Split('-');

    }

    private void SpawnPortal()
    {
        blueSpawn = new Point(0, 0);
        Instantiate(bluePortalPre, Tiles[blueSpawn].GetComponent<TileScript>().WorldPosition, Quaternion.identity);

        redSpawn = new Point(11, 6);
        Instantiate(redPortalPre, Tiles[redSpawn].GetComponent<TileScript>().WorldPosition, Quaternion.identity);
    }
        
       
}
