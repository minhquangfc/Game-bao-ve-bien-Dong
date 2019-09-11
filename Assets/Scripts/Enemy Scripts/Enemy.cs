using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public float _enemyspeed;
    private Rigidbody2D _myBody;
    [SerializeField]
    private GameObject _bullet;
    [SerializeField]
    private AudioClip _weaponEnemyClip;
    // Use this for initialization
    void Awake()
    {
        _myBody = GetComponent<Rigidbody2D>();

    }
     void Start()
    {
        StartCoroutine(_EnemyShoot());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _myBody.velocity = new Vector2(-_enemyspeed, _myBody.velocity.y);
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
            GamePlayController.instance._PlaneDiedShowPanel();
        }
    }
    IEnumerator _EnemyShoot()
    {
        yield return new WaitForSeconds(Random.Range(1f, 3f));
        Vector3 temp = transform.position;
        temp.x -= 0.8f;
        Instantiate(_bullet, temp, Quaternion.identity);
        AudioSource.PlayClipAtPoint(_weaponEnemyClip, temp);
        StartCoroutine(_EnemyShoot());
    }
    
}
