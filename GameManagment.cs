using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManagment : Singleton<GameManagment>
{
    public TowerButton ClickButton { get; set; }

   

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

    void Start()
    {
        Bytes = 35;
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
}
