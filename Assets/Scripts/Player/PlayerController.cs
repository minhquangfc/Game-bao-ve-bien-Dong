using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float speed;
    private Rigidbody2D _myBody;
    [SerializeField]
    private GameObject _bullet;
    [SerializeField]
    private AudioClip _weaponClip;
    
    
    // Use this for initialization


    // Update is called once per frame
    void Awake()
    {
        _myBody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
        StartCoroutine(Shoot());

    }
    void Update()
    {
       if(Input.GetKey(KeyCode.Space))
        {
            Instantiate(_bullet, transform.position, Quaternion.identity);
        }
        


    }
    void FixedUpdate()
    {
       
         float h = Input.GetAxis("Horizontal") * speed;
        
        //A,D=>-1 0 1=>-1 -0.9 -0.8   0.1
        //-1 0 1
        float v = Input.GetAxis("Vertical") * speed;
        //W,S=> -1 0 1
        _myBody.velocity = new Vector2(h,v);
        
        
    }
    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(0.4f);
        Vector3 temp = transform.position;
        temp.x += 0.8f;
        Instantiate(_bullet, temp, Quaternion.identity);
        AudioSource.PlayClipAtPoint(_weaponClip, temp);
        StartCoroutine(Shoot());
    }
}
