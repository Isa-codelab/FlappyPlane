using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] public GameObject puff;

    public PlayerServices playerService;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerService = new PlayerServices(moveSpeed);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

        rb.velocity = playerService.LimitVelocity(rb.velocity);

        if (playerService.IsPlayerOutOfBounds(transform.position.y, 5.5f))
            SceneManager.LoadScene(0);


        //movimento vertical do player
        //MoveUp();

        //VelocityLimited();

        //LimitFieldOutput();

    }
    public GameObject Jump()
    {
        rb.velocity = playerService.GetJumpVelocity();
        GameObject mypuff = Instantiate(puff, transform.position, Quaternion.identity);
        Destroy(mypuff, 0.4f);
        return mypuff; // retorna o puff para teste
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(0);
    }





    //private void VelocityLimited()
    //{

    //    if (rb.velocity.y < -moveSpeed)
    //    {
    //        rb.velocity = Vector2.down * moveSpeed;
    //    }
    //}

    //public void MoveUp()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        rb.velocity = Vector2.up * moveSpeed;
    //        GameObject mypuff = Instantiate(puff, transform.position, Quaternion.identity);
    //        Destroy(mypuff, 0.4f);
    //    }
    //} 

    //private void LimitFieldOutput()
    //{
    //    if(transform.position.y < -5.5f || transform.position.y > 5.5f)
    //    {
    //        SceneManager.LoadScene(0);
    //    }
        
    //}
}
