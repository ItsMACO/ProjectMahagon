using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 8f;
    Rigidbody2D body;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed = 5f;
    [SerializeField] float timeBetweenShots = 0.5f;
    Coroutine firing;
    Vector2 direction;

    Vector3 cameraOffset;

    void Start()
    {
        cameraOffset = new Vector3(0, 0, -1);
    }

    // Update is called once per frame
    void Update()
    {
        FaceMouse();
        Move();
        Fire();
    }

    void Move()
    {
        if(Input.GetButtonDown("Walk"))
        {
            moveSpeed /= 2;
        }
        if(Input.GetButtonUp("Walk"))
        {
            moveSpeed *= 2;
        }
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var newXPos = transform.position.x + deltaX;

        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var newYPos = transform.position.y + deltaY;

        transform.position = new Vector2(newXPos, newYPos);

        Camera camera = Camera.main;
        camera.transform.position = transform.position + cameraOffset;

    }
    void FaceMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        transform.up = direction;

    }
    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
    public void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            firing = StartCoroutine(RapidFire());
        }
        if(Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firing);
        }
    }

    IEnumerator RapidFire()
    {
        while(true)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation*Quaternion.Euler(0, 0, 90f)) as GameObject;
            Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();
            bulletBody.velocity = direction*bulletSpeed;
            yield return new WaitForSeconds(timeBetweenShots);
        }
    }
}
