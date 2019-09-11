using UnityEngine;
using System.Collections;

public class OurBullet : MonoBehaviour {
    public float speed;
    private Rigidbody2D _myBody;
    
    // Use this for initialization
    void Awake()
    {
        _myBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _myBody.velocity = new Vector2(speed, _myBody.velocity.y);
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Enemy")
        {
            Destroy(target.gameObject);
            Destroy(gameObject);
            GamePlayController.instance.playerScore++;
        }
        if (target.tag == "Top Border")
        {
            Destroy (gameObject);
        }
    }
}
