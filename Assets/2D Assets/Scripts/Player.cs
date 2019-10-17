using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    public float speed = 5.0f;
    [SerializeField]
    public float missileLauncherInit = 1;
    public float missileLauncherInitU = -0.2f;
    [SerializeField]
    private float _fireRate = 0.25f;

    private float _canFire = 0.0f;

    public bool canTripleShoot = true;
    public int lives = 3;

    [SerializeField]
    private GameObject _tripleShotPrefab;
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }
    
    void Update()
    {
        Movement();

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (Time.time > _canFire)
        {
            if(canTripleShoot == true)
            {
                Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(_laserPrefab, transform.position + new Vector3(missileLauncherInit, 0, 0), Quaternion.identity);

            }
            _canFire = Time.time + _fireRate;
        }
    }
    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);

        if (transform.position.y > 4.2f)
        {
            transform.position = new Vector3(transform.position.x, 4.2f, 0);
        }
        else if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }

        if (transform.position.x > 0)
        {
            transform.position = new Vector3(0, transform.position.y, 0);
        }
        else if (transform.position.x < -8)
        {
            transform.position = new Vector3(-8, transform.position.y, 0);
        }
    }

    public void Damage()
    {
        lives--;
        if(lives < 1)
        {
            Destroy(this.gameObject);
        }
    }

}
