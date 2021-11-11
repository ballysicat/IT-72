using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoves : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 5.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    private int score = 0;
    GameObject goal;
    // Start is called before the first frame update
    void Start()
    {
        goal = GameObject.Find("FinishGoal");
        goal.SetActive(false);
        controller = gameObject.AddComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
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
        //Ouput the Collision to the console
        
        GameObject obj = collision.gameObject;
        if(collision.gameObject.tag == "Coin")
        {
            obj.SetActive(false);
            score += 1;
        }
        if(score > 8)
        {
            //
            goal.SetActive(true);
        }
       
    }
}
