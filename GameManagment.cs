using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagment : Singleton<GameManagment>
{
    [SerializeField]
    private GameObject towerPre;

    public GameObject TowerPre
    {
        get
        {
            return towerPre;
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
}
