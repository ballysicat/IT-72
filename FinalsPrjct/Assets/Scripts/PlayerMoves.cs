using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMoves : MonoBehaviour
{
    
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 5.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    private static int score = 0;
    private int coin = 0;
    public Text HignScr;
    public Text NamePly;
    public Text txtScore;
    
    
    static GameObject goal, scoreCard, btnCard, prmttxt;
    // Start is called before the first frame update
    void Start()
    {
        NamePly.text =  Getname();
        HignScr.text =  GetHighScoure().ToString();
        goal = GameObject.Find("FinishGoal");
        goal.SetActive(false);
        GameObject.Find("BntSubmit").GetComponent<Button>().onClick.AddListener(()=>{onSubmit();});
        controller = gameObject.AddComponent<CharacterController>();
        scoreCard =  GameObject.Find("ImgScoreCard");
        scoreCard.SetActive(false); 
        GameObject.Find("BtnConfrm").GetComponent<Button>().onClick.AddListener(()=>{confrmbtn();});
        prmttxt = GameObject.Find("PromtTxt");
        prmttxt.SetActive(false);
        
    }

    public static void SetPlayerScoure(int scr,string name)
    {
        PlayerPrefs.SetInt("HignScoure", scr);
        PlayerPrefs.SetString("name", name);
    }
    public int GetHighScoure()
    {
        return PlayerPrefs.GetInt("HignScoure");
    }
    public string Getname()
    {
        return PlayerPrefs.GetString("name");
    }

    // Update is called once per frame
    void Update()
    {
        txtScore.text = score.ToString();
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(  Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);
        //
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
    //Detect when there is a collision starting
    void OnCollisionEnter(Collision collision)
    {
        
        GameObject obj = collision.gameObject;
        if(collision.gameObject.tag == "Coin")
        {
            obj.SetActive(false);
            score += 1;
            coin += 1;
        }

        if(collision.gameObject.tag == "CubeObstacle")
        {
            obj.SetActive(false);
            score -= 1;
            
        }

        if(coin > 24)
        {
            int Hscr = GetHighScoure();
            if(score > Hscr)
            {
                scoreCard.SetActive(true);
                txtScore.text = score.ToString();
            }
            else
            {
                prmttxt.SetActive(true);
            }
            goal.SetActive(true);
        }
       
    }

    public void onSubmit()
    {
        Text newscore = GameObject.Find("NewScore").GetComponent<Text>();
        HignScr.text = score.ToString();
        Text newname = GameObject.Find("PlayerNametxt").GetComponent<Text>();
        NamePly.text =  newname.text;
        SetPlayerScoure(score,newname.text);
        SceneManager.LoadScene("Mage");
    }
    void confrmbtn()
    {
        SceneManager.LoadScene("Mage");
    }
}
