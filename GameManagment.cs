using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManagment : Singleton<GameManagment>
{
    public TowerButton ClickButton { get; set; }

    public ObjectPool Pool{ get; set; }

    // Start is called before the first frame update

    private int bytes;
    public int Bytes {

        get
        { 
            return bytes;
        }
        set 
        { 
            this.bytes = value;
            this.byteText.text = value.ToString() + " <color=purple>Bytes</color>";
        }
            
    }

    [SerializeField]
    private Text byteText;


    private void Awake()
    {


        Pool = GetComponent<ObjectPool>();
    }


    void Start()
    {
        Bytes = 10000;
    }

    // Update is called once per frame
    void Update()
    {
        HandleEscape();
    }

    public void PickTower(TowerButton towerButton)
    {
        if(Bytes >= towerButton.Bytes)
        {
            this.ClickButton = towerButton;
            Hover.Instance.Activate(towerButton.Sprite);
        }
  
    }

    public void BuyTower()
    {
        if(Bytes >= ClickButton.Bytes)
        {
            Bytes -= ClickButton.Bytes;
        }
        Hover.Instance.Deactivate();

    }

    private void HandleEscape()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Hover.Instance.Deactivate();
        }


    }

    public void StartWave()
    {

        StartCoroutine(SpawnWave());


    }

    private IEnumerator SpawnWave()
    {

        LevelManagement.Instance.GeneratePath();
        int monsterIndex = Random.Range(0, 4);

        string type = string.Empty;


        switch (monsterIndex)
        {

            case 0:
                type = "BlueMonster";
                break;
            case 1:
                type = "RedMonster";
                break;
            case 2:
                type = "GreenMonster";
                break;
            case 3:
                type = "PurpleMonster";
                break;
        }

       Viruses virus = Pool.GetObject(type).GetComponent<Viruses>();
        virus.Spawn();
                yield return new WaitForSeconds(2.5f);

    }
}
