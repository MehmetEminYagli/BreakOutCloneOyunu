using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject dusmanprefab;
    [SerializeField] private Vector2Int size; //ka�a ka� olsun ynai 5 e 3 gibi �eyleri buradan se�ice�im 5 s�tun 3 sat�r gibi s�rala diyoruz
    [SerializeField] private Vector2 offset; // burada da aralar�ndaki fark� ayarl�yoruz

   // [SerializeField] private List<GameObject> dusmanlar;


    [ContextMenu(nameof(Create))] //oyun ba�lamadan inspector sekmesinde dusmanspawn nas�l oluyor bakabiliyoruz
    public void Create()
    {

        var parent = new GameObject { transform = { name = "Parent" } }; //burada spawn edece�imiz d��manlar� bir parent ad�nda objenin alt�nda olu�turuyoruz

        var list = new List<GameObject>();

        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                var x = i * offset.x;
                var y = j * offset.y;
                var position = new Vector3(x, y, 0);
                var dusman = Instantiate(dusmanprefab, position, Quaternion.identity);
                list.Add(dusman);
            }
        }

        Vector3 origin = Vector3.zero;
        foreach (var item in list)
        {
            origin += item.transform.position;
        }
        origin /= list.Count;

        parent.transform.position = origin;

        foreach (var item in list)
        {
            item.transform.SetParent(parent.transform);
        }

        parent.transform.position = Vector3.zero;


       // dusmanlar = new List<GameObject>(list);
    }

    
    void Start()
    {

       

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
