using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using UnityEngine;

public class Karakter : MonoBehaviour
{
    public PC pc;

    public float Yatay;
    public float Speed;

    private bool SagaBak;

    public bool HareketYasak;
    public bool Zeminde;
    public bool Zipla;

    public float Mesafe;
    public float ZiplamaKuvveti;

    public int Level;

    public LayerMask ZeminKatman;

    public GameObject BolumGecildiObje;

    public Transform AltKonum;

    public Slider SpeedSlider;
    public Slider JumpSlider;
    public Slider GravitySlider;

    public Text bolumGecildiText;

    public Text jumpValueText;
    public Text speedValueText;
    public Text gravityValueText;

    public Text maxJumpValueText;
    public Text maxSpeedValueText;
    public Text maxGravityValueText;

    public Color buttonColor;
    public Color clickButtonColor;

    public AudioSource KarakterAudioSource { get; set; }

    public Rigidbody2D KarakterRigidbody { get; set; }

    private void Start()
    {
        KarakterRigidbody = GetComponent<Rigidbody2D>();
        KarakterAudioSource = GetComponent<AudioSource>();

        SagaBak = true;
        HareketYasak = false;

        GameObject.Find("SagButon").GetComponent<Image>().color = buttonColor;
        GameObject.Find("SolButon").GetComponent<Image>().color = buttonColor;
        GameObject.Find("ZiplaButon").GetComponent<Image>().color = buttonColor;
        GameObject.Find("HileEkranButon").GetComponent<Image>().color = buttonColor;

        Level = 1;

        GravitySlider.maxValue = 3f;
        GravitySlider.minValue = 1f;
        GravitySlider.value = 3f;

        JumpSlider.maxValue = 10f;
        JumpSlider.minValue = 2f;
        JumpSlider.value = 2f;

        SpeedSlider.maxValue = 10f;
        SpeedSlider.minValue = 2f;
        SpeedSlider.value = 2f;

        maxGravityValueText.text = GravitySlider.maxValue.ToString();
    }

    private void Update()
    {
        Kontroller();

        Speed = SpeedSlider.value * 1.6f;
        ZiplamaKuvveti = JumpSlider.value * 2.4f;
        KarakterRigidbody.gravityScale = GravitySlider.value;

        maxJumpValueText.text = JumpSlider.maxValue.ToString();
        maxSpeedValueText.text = SpeedSlider.maxValue.ToString();

        jumpValueText.text = JumpSlider.value.ToString();
        speedValueText.text = SpeedSlider.value.ToString();
        gravityValueText.text = GravitySlider.value.ToString();

        if (KarakterRigidbody.gravityScale == 2)
        {
            JumpSlider.maxValue = 6f;
            SpeedSlider.maxValue = 6f;
        }

        if (KarakterRigidbody.gravityScale == 1)
        {
            JumpSlider.maxValue = 4f;
            SpeedSlider.maxValue = 4f;
        }

        if (KarakterRigidbody.gravityScale == 3)
        {
            JumpSlider.maxValue = 10f;
            SpeedSlider.maxValue = 10f;
        }
    }

    private void FixedUpdate()
    {
        //Yatay = CrossPlatformInputManager.GetAxis("Horizontal");

        Temel_Hareketler();

        Yon_Cevir();

        Zeminde_mi();

        if (!HareketYasak)
        {
            transform.eulerAngles = new Vector3(0, 0, Yatay * Speed * -1f);
        }
    }

    private void Temel_Hareketler()
    {
        if (Zipla)
        {
            KarakterRigidbody.velocity = (Vector2.up * ZiplamaKuvveti);

            Zipla = false;

            KarakterAudioSource.Play();
        }
        
        if (!HareketYasak)
        {
            KarakterRigidbody.velocity = new Vector2(Yatay * Speed, KarakterRigidbody.velocity.y);
        }
        else
        {
            KarakterRigidbody.velocity = Vector2.zero;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    private void Yon_Cevir()
    {
        if ((SagaBak && Yatay < 0 || !SagaBak && Yatay > 0) && !HareketYasak)
        {
            SagaBak = !SagaBak;

            Vector3 yon = transform.localScale;
            yon.x *= -1;
            transform.localScale = yon;
      }
    }

    private void Zeminde_mi()
    {
        RaycastHit2D zeminHit = Physics2D.CircleCast(AltKonum.position, 0.1f, Vector2.down, Mesafe, ZeminKatman);

        if (zeminHit.collider == null)
        {
            Zeminde = false;
        }
        else
        {
            Zeminde = true;
        }
    }
  
    private void Kontroller()
    {
        if (Input.GetKeyDown(KeyCode.W) && Zeminde && !HareketYasak)
        {
            Zipla = true;
       }
    }

    private void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.CompareTag("ölümZemini"))
        {
            HareketYasak = true;

            StartCoroutine(Olme());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("bitis") && !HareketYasak)
        {
            Level += 1;
            HareketYasak = true;

            StartCoroutine(Gecme());
            StartCoroutine(BolumGecildi());
        }
    }

    private IEnumerator Gecme()
    {
        yield return new WaitForSeconds(3);

        StartCoroutine(Bolum());
    }

    private IEnumerator Olme()
    {
        StartCoroutine(Bolum());

        yield return null;
    }

    private IEnumerator Bolum()
    {
        if (Level == 1)
        {
            transform.position = new Vector3 (-10, -3.5f, 0);
            SagaBak = true;
            transform.localScale = new Vector3 (12.5f, 12.5f, 1);
        }

        if (Level == 2)
        {
            transform.position = new Vector3(97.5f, -3.5f, 0);
            SagaBak = true;
            transform.localScale = new Vector3(12.5f, 12.5f, 1);
        }

        if (Level == 3)
        {
            transform.position = new Vector3(214, -3.5f, 0);
            SagaBak = true;
            transform.localScale = new Vector3(12.5f, 12.5f, 1);
        }

        if (Level == 4)
        {
            transform.position = new Vector3(336, -3.5f, 0);
            SagaBak = true;
            transform.localScale = new Vector3(12.5f, 12.5f, 1);
        }

        if (Level == 5)
        {
            transform.position = new Vector3(456, -3.5f, 0);
            SagaBak = true;
            transform.localScale = new Vector3(12.5f, 12.5f, 1);
        }

        if (Level == 6)
        {
            transform.position = new Vector3(592, -3.5f, 0);
            SagaBak = true;
            transform.localScale = new Vector3(12.5f, 12.5f, 1);
        }

        if (Level == 7)
        {
            transform.position = new Vector3(720, -3.5f, 0);
            SagaBak = true;
            transform.localScale = new Vector3(12.5f, 12.5f, 1);
        }

        HareketYasak = false;

        yield return null;
    }

    private IEnumerator BolumGecildi()
    {
        BolumGecildiObje.SetActive(true);

        bolumGecildiText.text = "3";
        yield return new WaitForSeconds (1);
        bolumGecildiText.text = "2";
        yield return new WaitForSeconds(1);
        bolumGecildiText.text = "1";
        yield return new WaitForSeconds(1);

        BolumGecildiObje.SetActive(false);
    }

    public void SagButon()
    {
        GameObject.Find("SagButon").GetComponent<Image>().color = clickButtonColor;

        Yatay = 1;
    }

    public void SolButon()
    {
        GameObject.Find("SolButon").GetComponent<Image>().color = clickButtonColor;

        Yatay = -1;
    }

    public void Bekleme()
    {
        GameObject.Find("SagButon").GetComponent<Image>().color = buttonColor;
        GameObject.Find("SolButon").GetComponent<Image>().color = buttonColor;

        Yatay = 0;
    }

    public void ZiplaButon()
    {
        GameObject.Find("ZiplaButon").GetComponent<Image>().color = clickButtonColor;

        if (Zeminde && !HareketYasak)
        {
            Zipla = true;
        }
    }

    public void ClickUp()
    {
        GameObject.Find("ZiplaButon").GetComponent<Image>().color = buttonColor;
    }

    public void OyunİciHileButon()
    {
        if (pc.OpenGame && pc.InGameCheatScreen.activeSelf)
        {
            GameObject.Find("HileEkranButon").GetComponent<Image>().color = buttonColor;

            pc.InGameCheatScreen.SetActive(false);

            pc.karakter.HareketYasak = false;
        }
        else if (pc.OpenGame)
        {
            GameObject.Find("HileEkranButon").GetComponent<Image>().color = clickButtonColor;

            pc.InGameCheatScreen.SetActive(true);

            pc.karakter.HareketYasak = true;
        }
    }
}
