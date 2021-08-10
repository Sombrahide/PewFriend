using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    //The PlayerInput the player will use
    public PlayerInput playerInput;

    //The bullet the player will shoot
    public GameObject bullet;

    //THe point from where the bullets will be shoot
    public Transform gun;

    //The Player speed of movement
    public float speed = 5;

    //The movement of the player right now
    private Vector2 inputMovement;

    //The health of the player
    private int health = 3;

    #region Input Functions
    // First let's start with the input controller
    public void OnShoot(InputAction.CallbackContext value)
    {
        Debug.Log("Shoot: " + value.started);
        if (value.started)
        {
            //Here write the code for whenn you shoot
            GameObject proyectile = Instantiate(bullet, gun.position, transform.rotation);
        }
    }
    public void OnMovement(InputAction.CallbackContext value)
    {
        inputMovement = value.ReadValue<Vector2>();
    }
    #endregion

    #region Unity Functions
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    #endregion
    
    // Code of movement
    private void Movement()
    {
        //First let's move the object
        transform.Translate(new Vector3(inputMovement.x, inputMovement.y, 0) * speed * Time.deltaTime);

        //This is a log to see the direction of the input
        //Debug.Log("X: " + inputMovement.x + " | Y: " + inputMovement.y);
    }

    //This will be used when the player recibe damage
    public void ReduceHealth(int damage)
    {
        health -= damage;
    }
}
