using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuwatto : MonoBehaviour
{
    [SerializeField]
    private Animator fuwattoAnima;


    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Anima");
        fuwattoAnima.SetBool("AnimationStart", true);
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
