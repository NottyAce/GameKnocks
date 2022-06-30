using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuwatto : MonoBehaviour
{
    [SerializeField]
    private Animator fuwatto;


    // Start is called before the first frame update
    void Start()
    {
        fuwatto = GetComponent<Animator>();
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        fuwatto.SetTrigger("");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
