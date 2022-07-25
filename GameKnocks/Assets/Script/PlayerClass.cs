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
    //[SerializeField]
    //int jumpFull = 2;
    Rigidbody2D playerRigid;
    Vector2 right = new Vector2(1, 0);
    Vector2 left = new Vector2(-1, 0);
    Vector2 jump = new Vector2(0, 1);
    Vector2 stop = new Vector2(0, 0);
    float jumpdet = 0;//ÉWÉÉÉìÉvÇÃê≥ãKâªóp
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
        playerRigid.velocity = new Vector2(Input.GetAxis("Horizontal") * movePow,playerRigid.velocity.y);
        
        if (Input.GetKeyDown(KeyCode.UpArrow) && !(playerRigid.velocity.y < -0.5f)){
            Jump();
        }
    }
    private void FixedUpdate()
    {
        
    }

    void Jump() {
        playerRigid.AddForce(Vector2.up * jumpPow, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DeathZone")
        {
            SceneManager.LoadScene("KiraNoYatsu");
        }
    }
}
