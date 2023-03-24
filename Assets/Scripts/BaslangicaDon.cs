using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaslangicaDon : MonoBehaviour
{
    public bool Ne = false;

    public BoxCollider2D carpmaKutusu;

    private void Start()
    {
        carpmaKutusu = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Ne = true;
        }
    }
}
