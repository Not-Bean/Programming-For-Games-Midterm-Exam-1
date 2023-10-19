using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Windows;

public class Player : MonoBehaviour
{
    
    [SerializeField]float playerSpeed;
    Vector2 playerPosition;
    Vector2 nextPosition;
    private Vector2 moveDirection;
    private static MovementControls movement;

    public void setMovementDirection(Vector2 newDirection)
    {
        moveDirection = newDirection;//reads what direction player is trying to move to
    }
    void Start()
    {
        Init(this);
        GameMode();
        //Player.setMovementDirection(ctx.ReadValue<Vector2>());
    }
    public static void Init(Player myPlayer)//allows player class to communicate to Init function
    {
        movement = new MovementControls();//initializes new controls in unity
        movement.Movement.Move.performed += ctx =>//communicates the movement to unity
        {
            myPlayer.setMovementDirection(ctx.ReadValue<Vector2>());//sees what direction to move from player class
        };
        movement.Enable();//allows movement while game is running
    }
    public static void GameMode()//allows movement
    {
        movement.Movement.Enable();
    }
    public static void UIMode()//allows movement
    {
        movement.Movement.Disable();
    }
    void Update()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.A))
        {
            //move player left
            //Vector2 AddForce = new Vector2(playerSpeed * Time.deltaTime , 0);
            Vector2 AddForce = playerSpeed * Time.deltaTime * moveDirection;

        }
        if (UnityEngine.Input.GetKeyDown(KeyCode.D))
        {
            //move player right

        }
    }
}
