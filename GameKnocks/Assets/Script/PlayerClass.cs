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
    // Start is called before the first frame update
    void Start()
    {
        playerRigid = player.GetComponent<Rigidbody2D>();
        right.x = right.x * movePow;
        left.x = left.x * movePow;
        jump.y = jump.y * jumpPow;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            playerRigid.AddForce(right);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerRigid.AddForce(left);
        }
        else
        {
            playerRigid.velocity = stop;
        }

        if (Input.GetKey(KeyCode.UpArrow) && playerRigid.velocity.y < jumpFull)
        {
            playerRigid.AddForce(jump);
            Debug.Log("Jump!");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DeathZone")
        {
            Debug.Log("Oh!No!");
            SceneManager.LoadScene("NiseMario");
        }
    }
}