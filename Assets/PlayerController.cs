using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float speed = 5;
    [SerializeField] float jumpHeight = 200;
    private bool isTouchingGround = false;
    private SpriteRenderer sprite;
    private Rigidbody2D rb;

    private AudioSource audioSource;
    // Start is called before the first frame update
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float HorizontalInput = -Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(HorizontalInput, 0) *Time.deltaTime *speed;
        
        if(HorizontalInput > 0)
        {
            sprite.flipX = true;
        }
        else if(HorizontalInput<0)
        {
            sprite.flipX = false;
        }
        transform.Translate(movement);
        if(Input.GetKeyDown(KeyCode.Space) && isTouchingGround)
        {
            jump();
        }
    }
    void jump()
    {
        audioSource.Play();
        rb.AddForce(Vector2.up*jumpHeight);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isTouchingGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isTouchingGround = false;
        }
    }
    
}
