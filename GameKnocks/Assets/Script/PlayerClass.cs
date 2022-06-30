using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerClass : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    int movePow = 1;
    [SerializeField]
    int jumpPow = 1;
    [SerializeField]
    int jumpFull = 2;
    Rigidbody2D playerRigid;
    Vector2 right = new Vector2(1, 0);
    Vector2 left = new Vector2(-1, 0);
    Vector2 jump = new Vector2(0, 1);
    Vector2 stop = new Vector2(0, 0);
    float jumpdet = 0;//ジャンプの正規化用
    // Start is called before the first frame update
    void Start()
    {
        playerRigid = player.GetComponent<Rigidbody2D>();
        right.x = right.x * movePow;
        left.x = left.x * movePow;
        jump.y = jump.y * movePow;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            PlayerAction(right);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            PlayerAction(left);
        }
        else
        {
            playerRigid.velocity = stop;
        }

        if (Input.GetKey(KeyCode.UpArrow) && playerRigid.velocity.y < jumpFull)
        {
            PlayerAction(jump);
            //Debug.Log("Jump!");
        }
    }
    private void FixedUpdate()
    {
        
    }

    private void PlayerAction(Vector2 direction) {

        if (direction == right)
        {
            playerRigid.AddForce(right);
        }
        else if (direction == left)
        {
            playerRigid.AddForce(left);
        }
        else { 
        
        }

        if (direction == jump) {
            jumpdet = playerRigid.velocity.x + jump.y;

            jump.x = playerRigid.velocity.x;
            jump.y = (jump.y + jumpPow);
            if (jumpdet != 0) {
                jump = jump * jumpPow / jumpdet;
            }
            playerRigid.AddForce(jump);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DeathZone")
        {
            SceneManager.LoadScene("NiseMario");
        }
    }
}
