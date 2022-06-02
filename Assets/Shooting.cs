using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject axePrefab;

    public float bulletForce = 4f;

    void Start()
    {
        StartCoroutine(ShootingCoroutine());   
    }

    void OnFire()
    {
        Debug.Log("Fire");
        Shoot();
    }

    IEnumerator ShootingCoroutine()
    {
        for (;;)
        {
            Shoot();
            yield return new WaitForSeconds(2.0f);
        }
    }

    void Shoot()
    {
        //Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        //if (mousePos != Vector2.zero)
        //{
        //    Vector2 lookDir = mousePos - rb.position;
        //    float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        //}
        GameObject axe = Instantiate(axePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = axe.GetComponent<Rigidbody2D>();
        float direction = Random.Range(0, 10) < 5 ? -1.0f : 1.0f;

        Vector3 tmp = new Vector3(0.35f * direction, 1.0f, 0.0f);
        rb.AddForce(tmp * bulletForce, ForceMode2D.Impulse);
    }

}
