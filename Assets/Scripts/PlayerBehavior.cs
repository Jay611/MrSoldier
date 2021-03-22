using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{
    //Reference to character components
    [Header("Controller")]
    public CharacterController controller;
    public GameController control;

    [Header("Controls")]
    public Joystick joystick;
    public float horizontalSensitivity;
    public float verticalSensitivity;

    [Header("Movement")]
    public float speed = 12f;
    public float jumpHeight = 3f;
    public float gravity = -9.81f;

    //Check if we're on the floor
    [Header("Ground Detection")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;


    //Health System
    [Header("HealthBar")]
    public HealthBar healthBar;
    public int maxHealth = 150;
    public int currentHealth;

    //Store our velocity from the up/down axis
    Vector3 velocity;

    void Start()
    {
        //Setting our health
        currentHealth = maxHealth;
        healthBar.currentHealth = currentHealth;
    }
    // Update is called once per frame
    void Update()
    {
        // if game paused, player dead, level won or pointer is over a UI, don't run any code.
        if (PauseMenu.GameIsPaused || control.isDead || EventSystem.current.IsPointerOverGameObject() || control.levelComplete)
        {
            return;
        }
        //Jump code
        Jump();
        //Checking if you're on the floor
        OnTheFloor();
    //Grab inputs.

    // Input for WebGL and Desktop
    // x = Input.GetAxis("Horizontal");
    // z = Input.GetAxis("Vertical");

    float x = joystick.Horizontal;
    float z = joystick.Vertical;

    Debug.Log("X: " + x);
    Debug.Log("Z: " + z);

        if (isGrounded && velocity.y < 0)
        {
            //Reset our weight once we land on the ground
            velocity.y = -2f;
        }

        //Turn the inputs to a direction
        Vector3 move = transform.right * x + transform.forward * z;

        //Code to move
        controller.Move(move * speed * Time.deltaTime);
        
        //How to weigh us down
        velocity.y += gravity * Time.deltaTime;

        //Add the weight to our player
        controller.Move(velocity * Time.deltaTime);
    }
    public void TakeDamage(int damage)
    {
        //Whatever damage we take, subtract from our current health and set our health onto the health bar
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        //If you're dead, run this
        if(currentHealth <= 0)
        {
            control.EndGame();
        }
    }
    void Jump()
    {
        //Jump code
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
    void OnTheFloor()
    {
        //Check if we're grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }
    public void Save()
    {
        //This is where i'll be putting the save game code
        SaveSystem.SavePlayer(this);
    }
    public void Load()
    {
        //This is where i'll be putting the load game code
        PlayerData data = SaveSystem.LoadPlayer();

        SceneManager.LoadScene(data.level);
        currentHealth = data.health;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];

        this.transform.position = position;
    }
}
