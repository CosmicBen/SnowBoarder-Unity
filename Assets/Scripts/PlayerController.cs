using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float torqueAmount = 1.0f;
    [SerializeField] private float boostSpeed = 30.0f;
    [SerializeField] private float slowSpeed = 10.0f;

    private SurfaceEffector2D surfaceEffector2D;
    private Rigidbody2D rb2d;
    private bool canMove = true;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    private void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }
    }

    public void DisableControls()
    {
        canMove = false;
    }

    private void RotatePlayer()
    {
        float direction = -Input.GetAxis("Horizontal");
        rb2d.AddTorque(direction * torqueAmount);
    }

    private void RespondToBoost()
    {
        float direction = Input.GetAxis("Vertical");
        surfaceEffector2D.speed = Remap(direction, -1, 1, slowSpeed, boostSpeed);
    }

    private float Remap(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }
}
