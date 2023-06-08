using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField ]private float speed = 1f;
    [SerializeField] private float limitX = 8.8f;
    

    // Update is called once per frame
    void Update()
    {
        var input = Input.GetAxis("Horizontal");

        var position = transform.position; //pozisyonunu al o anki
        position.x += input * speed * Time.deltaTime; //h�z�n� hareketini sa�la 
        position.x = Mathf.Clamp(position.x, -limitX, limitX); //oyuncunun harita d��ars�na ��kmas�n� engelle
        transform.position = position; //pozisyonunu g�ncelleyerek hareket ediyormu� imaj� ver :)
    }
}
