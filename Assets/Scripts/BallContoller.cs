using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallContoller : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    [SerializeField] private float speed = 1f;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        var random = Random.value > .5f ? 1 : -1; //random value fonksiyonu bize  0 ile 1 aras�nda bir de�er veriyor biz bunu �ans fakt�r� olarak kullan�caz �imdi burda dedi�imiz e�er de�er
                                    //0.5 say�s�ndan b�y�kse 1 yap de�ilse -1 yap de�eri dedik b�ylelikle topumuz random bir �ekilde hareketine ba�l�cak 
        var force = new Vector2(random, -1);
        _rigidbody2D.AddForce(force.normalized * speed);
    }                           //normalized ne demek?

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Dusman"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
