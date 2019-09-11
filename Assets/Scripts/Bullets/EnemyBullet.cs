using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour {

	public float _speed;

    private Rigidbody2D _myBody;

    // Use this for initialization
    void Awake()
    {
        _myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _myBody.velocity = new Vector2(-_speed,_myBody.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Bottom Border")
        {
            Destroy(gameObject);
        }
        if (target.tag == "Player")
        {
            Destroy(target.gameObject);
            Destroy(gameObject);
            GamePlayController.instance._PlaneDiedShowPanel();
        }
    }
}
