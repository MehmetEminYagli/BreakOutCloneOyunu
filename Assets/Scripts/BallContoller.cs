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
        var random = Random.value > .5f ? 1 : -1; //random value fonksiyonu bize  0 ile 1 arasýnda bir deðer veriyor biz bunu þans faktörü olarak kullanýcaz þimdi burda dediðimiz eðer deðer
                                    //0.5 sayýsýndan büyükse 1 yap deðilse -1 yap deðeri dedik böylelikle topumuz random bir þekilde hareketine baþlýcak 
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
