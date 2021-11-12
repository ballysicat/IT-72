using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayBtnScript : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        player.SetActive(false);
        enemy.SetActive(false);
        
        
    }

    public void onClickPlay()
    {
        player.SetActive(true);
        enemy.SetActive(true);
        canvas.SetActive(false);
    }


}
