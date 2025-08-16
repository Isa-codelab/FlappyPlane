using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //movimento vertical do player
        MoveUp();

        VelocityLimited();

    }

    private void VelocityLimited()
    {

        if (rb.velocity.y < -moveSpeed)
        {
            rb.velocity = Vector2.down * moveSpeed;
        }
    }

    public void MoveUp()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = Vector2.up * moveSpeed;
        }
    }
}
