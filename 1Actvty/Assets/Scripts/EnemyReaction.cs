using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyReaction : MonoBehaviour
{
    private float speed = 1f;
    private Vector2 target;
    private Vector2 position;
    // Start is called before the first frame update
    void Start()
    {
        target = new Vector2(-7.0f,0);
        position = gameObject.transform.position;
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target, step);
    }

    private void OnTriggerEnter(Collider other)
    {
        target = new Vector2(10.0f,0);
    
    }
}
