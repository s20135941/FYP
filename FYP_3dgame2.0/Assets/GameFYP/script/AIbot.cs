using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AIbot : MonoBehaviour
{
    [SerializeField]
    [Header("tower")]
    private Transform target; //tower

    [SerializeField]
    [Header("move Speed")]
    private float moveSpeed = 5.0f;//move Speed

    [SerializeField]
    [Header("rotate Speed")]
    private float rotateSpeed = 5.0f;//rotate Speed

    [SerializeField]
    [Header("monsters")]
    private Transform mytransform;

    [SerializeField]
    [Header("tower")]
    private Transform range; //tower

    //Animator anim;

    void Start()
    {

        Transform target = GameObject.FindGameObjectWithTag("Player").transform;
        //anim = GetComponent<Animator>();

    }


    void Update()

    {
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance < 20)
        {

            Debug.DrawLine(target.transform.position, this.transform.position, Color.yellow);


            mytransform.rotation = Quaternion.Slerp(mytransform.rotation, Quaternion.LookRotation(target.position - mytransform.position), rotateSpeed * Time.deltaTime);


            mytransform.position += mytransform.forward * moveSpeed * Time.deltaTime;

            //anim.SetBool("GhostRunning", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //anim.SetTrigger("GhostAttack");
    }
}