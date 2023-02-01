using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float xMoveSpeed;
    [SerializeField] float yMoveSpeed;
    [SerializeField] float zMoveSpeed;

    public KeyCode inputUp;
    public KeyCode inputDown;
    public KeyCode inputRight;
    public KeyCode inputLeft;
    public KeyCode placeBomb;

    public float moveSpeed;
    private Vector3 moveDirection;
    private Player player;
    private Rigidbody rgPlayer;
    //private CharacterController controller;
    private Animator anim;

    private void Awake()
    {
        player = GetComponent<Player>();
        //controller = GetComponent<CharacterController>();
        rgPlayer = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        moveSpeed = player.playerMoveSpeed;
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        Vector3 newPosition = new Vector3();
        if (Input.GetKey(inputUp))
        {
            newPosition = new Vector3(0f,0f, zMoveSpeed);

            Vector3 newRotation = new Vector3(0, 0, 0);
            transform.eulerAngles = newRotation;
        }
        else if (Input.GetKey(inputDown))
        {
            newPosition = new Vector3(0f,0f, -zMoveSpeed);
            
            Vector3 newRotation = new Vector3(0, 180, 0);
            transform.eulerAngles = newRotation;
        }
        else if (Input.GetKey(inputRight))
        {
            newPosition = new Vector3(xMoveSpeed,0f,0f);
            
            Vector3 newRotation = new Vector3(0, 90, 0);
            transform.eulerAngles = newRotation;
        }
        else if (Input.GetKey(inputLeft))
        {
            newPosition = new Vector3(-xMoveSpeed,0f,0f);
            
            Vector3 newRotation = new Vector3(0, -90, 0);
            transform.eulerAngles = newRotation;
        }

        transform.position = transform.position + (newPosition * Time.deltaTime);
        
    }
}
