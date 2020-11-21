using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce;
    Rigidbody2D rb;
    bool isGround;
    GameController m_gc;
    public AudioSource auS;
    public AudioClip jumpSound;
    public AudioClip loseSound; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        m_gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isJumpKeyPressed = Input.GetKeyDown(KeyCode.Space);
        if(isJumpKeyPressed && isGround)
        {
            rb.AddForce(Vector2.up * jumpForce);
            isGround = false;
            if (auS && jumpSound)
            {
                auS.PlayOneShot(jumpSound);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {   
        if(col.CompareTag("Obstacle"))
        {
            if(auS && loseSound )
            {
                auS.PlayOneShot(loseSound);
            }
            m_gc.SetGameoverState(true);
        }
    }
}
