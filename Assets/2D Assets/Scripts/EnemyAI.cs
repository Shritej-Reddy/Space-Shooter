using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private float _speed = 5.0f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(-Vector3.right * _speed * Time.deltaTime);

        if(transform.position.x < -10)
        {
            float randomY = Random.Range(-4f, 4f);
            transform.position = new Vector3(10, randomY, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "laser")
        {
            if(other.transform.parent != null)
            {
                Destroy(other.transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }
        else if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if(player != null)
            {
                player.Damage();
            }
        }
    }

}
