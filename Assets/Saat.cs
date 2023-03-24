using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Saat : MonoBehaviour
{
    public int dakika;
    public float saniye;
    public int saat;

    public Text saatText;

    void Start()
    {
        saatText = GetComponent<Text>();

        saat = 12;
        dakika = 56;
        saniye = 0;

        saatText.text = saat + ":" + dakika;
    }

    void Update()
    {
        saniye = saniye + Time.deltaTime;

        if (saniye >= 60)
        {
            dakika += 1;
            saniye = 0;
            saatText.text = saat + ":" + dakika;
        }

        if (dakika >= 60)
        {
            saat += 1;
            dakika = 0;
            saatText.text = saat + ":" + dakika;
        }

        if (saat >= 24)
        {
            saat = 0;
            dakika = 0;
            saniye = 0;
            saatText.text = saat + ":" + dakika;
        }

        if (dakika < 10)
        {
            saatText.text = saat + ":" + "0" + dakika;
        }

        if (saat < 10)
        {
            saatText.text = "0" + saat + ":" + dakika;
        }

        if (saat < 10 && dakika < 10)
        {
            saatText.text = "0" + saat + ":" + "0" + dakika;
        }
    }
}
