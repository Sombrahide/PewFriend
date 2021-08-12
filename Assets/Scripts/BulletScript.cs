using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 5f;
    public int damage = 1;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector2(speed, 0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Player":
                //collision.GetComponent<PlayerScript>().ReduceHealth(damage);
                SelfKill();
                break;
            case "Obstacle":
                //In this case it have collide with a obstacle and will disapear with a explosion
                SelfKill();
                break;
        }
    }
    private void SelfKill()
    {
        Destroy(gameObject);
    }
}
