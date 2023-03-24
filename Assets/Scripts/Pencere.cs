using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pencere : MonoBehaviour
{

    public bool mouseDrag;
    public bool mouseTemas;

    public Vector2 fareKonum;

    private void Start()
    {
        mouseDrag = false;
    }

    private void Update()
    {
        fareKonum = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mouseDrag && !mouseTemas && fareKonum.x < 19 && fareKonum.x > -19 && fareKonum.y < 10 && fareKonum.y > -10)
        {
            transform.position = fareKonum;
        }
    }

    void OnMouseDown()
    {
        mouseDrag = true;
    }

    void OnMouseUp()
    {
        mouseDrag = false;
    }

    void OnMouseOver()
    {
        if (!mouseDrag)
        {
            mouseTemas = true;
        }
    }

    void OnMouseExit()
    {
        mouseTemas = false;
    }
}
