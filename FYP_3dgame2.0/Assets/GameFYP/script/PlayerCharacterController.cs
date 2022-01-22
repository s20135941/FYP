using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCharacterController : MonoBehaviour
{
    public CharacterController controller;

    public Camera PlayerCamera;
    public float speed = 10f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float KillHeight = -50f;
    public float RotationSpeed = 200f;
    [SerializeField]
    private int health = 100;
    public int currentHP;

    private UIManager uiManager_;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;

    public bool isGrounded;

    public bool isDestroyed;

    CharacterController m_Controller;

    // Start is called before the first frame update
    void Start()
    {
        uiManager_ = GameObject.Find("Canvas").GetComponent<UIManager>();
        currentHP = health;
        uiManager_.SetMaxHealth(health);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.K))
        //{
        //    PlayerTakeDamage(10);
        //}

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    void PlayerTakeDamage(int damage)
    {
        currentHP -= damage;

        uiManager_.SetHealth(currentHP);
    }


}
