using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
    [SerializeField]
    private GameObject _enemy;
    private BoxCollider2D _box;
    // Use this for initialization
    void Awake()
    {
        _box = GetComponent<BoxCollider2D>();
    }
    void Start()
    {
        StartCoroutine(SpawnerEnemy());
    }

    // Update is called once per frame
    void Update () {
	
	}
    IEnumerator SpawnerEnemy()
    {
        yield return new WaitForSeconds(Random.Range(1f, 3f));
        float minY = -_box.bounds.size.y / 2f;
        float maxY = _box.bounds.size.y / 2f;
        Vector3 temp = transform.position;
        temp.y = Random.Range(minY, maxY);
        Instantiate(_enemy, temp, Quaternion.identity);
        StartCoroutine(SpawnerEnemy());
    }
}
