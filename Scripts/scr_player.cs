using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed;
    public float life;
    private bool invunerable;
    private float timer;
    public float invulnerabilityTime;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        invunerable = true;
        timer = invulnerabilityTime;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * moveSpeed;
        if(invunerable == true) 
        {
            timer -= Time.deltaTime;
            if(timer <= invulnerabilityTime)
            {
                invunerable = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Enemy" && invunerable == false) {
            life--;
            timer = invulnerabilityTime;
            invunerable = true;
            if(life <= 0) {
                Destroy(gameObject);
            }
        }
    }
}
