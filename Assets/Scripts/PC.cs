using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PC : MonoBehaviour
{
    public Karakter karakter;

    [Header ("Animasyonlar")]
    public Animator CloseAnimator;
    public Animator MessagingAnimator;

    [Header ("Objeler")]
    /*
    public GameObject FriendMessageBox;
    public GameObject MessageBox;
    */
    public GameObject CloseScreen;
    public GameObject OpenButton;
    public GameObject CloseButton;
    public GameObject ChatScreen;
    public GameObject OpenChatButton;
    public GameObject Bildirim;
    public GameObject Game;
    public GameObject GameScreen;
    public GameObject Cheat;
    public GameObject CheatScreen;
    public GameObject OpenCheatScreen;
    public GameObject OpenGameButton;
    public GameObject GameHeader;
    public GameObject Arkaplan;
    public GameObject InGameCheatScreen;
    public GameObject BolumlerGecildiObje;
    public GameObject Buttons;
    public GameObject Mesajlasma;


    [Header ("Butonlar")]
    public Button ChatApplication;
    public Button OpenChatApplication;
    public Button GameApplication;
    public Button CheatApplication;

    [Header ("Sesler")]
    public AudioSource OpenSound;
    public AudioSource CloseSound;
    public AudioSource ButtonSound;
    public AudioSource BildirimSound;

    [Header ("Bool")]
    public bool OpenScreen;
    public bool OpenChat;
    public bool OpenCheat;
    public bool OpenGameCheat;
    public bool OpenGame;

    private bool Played;

    /*
    public string ChatMessage;

    public Transform MesajTransform;
    */


    private void Start()
    {
        OpenScreen = false;
        OpenChat = false;
        Played = false;
        OpenGameCheat = false;
        BildirimSound.Play();

        Buttons.SetActive(false);
        OpenCheatScreen.SetActive(false);
        OpenChatButton.SetActive(false);
    }

    private void Update()
    {
        if (Mesajlasma.activeSelf)
        {
            OpenChatApplication.enabled = true;
        }

        if (!OpenGameButton.activeSelf)
        {
            GameApplication.enabled = true;
        }

        if (!OpenCheatScreen.activeSelf)
        {
            CheatApplication.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.Tab) && OpenGame && InGameCheatScreen.activeSelf)
        {
            InGameCheatScreen.SetActive(false);
            karakter.HareketYasak = false;
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && OpenGame)
        {
            InGameCheatScreen.SetActive(true);
            karakter.HareketYasak = true;
        }

        if (!GameScreen.activeSelf)
        {
            InGameCheatScreen.SetActive(false);
            BolumlerGecildiObje.SetActive(false);
        }
        
    }

    public void OpenButtonFunction() 
    {
        OpenScreen = false;

        CloseAnimator.SetTrigger("kapat");

        if (!CloseAnimator.GetCurrentAnimatorStateInfo(0).IsName("Exit"))
        {
            CloseSound.Play();

            OpenButton.SetActive(false);
            CloseButton.SetActive(true);
        }
    }

    public void CloseButtonFunction()
    {
        OpenScreen = true;

        CloseAnimator.SetTrigger("ac");

        if (!CloseAnimator.GetCurrentAnimatorStateInfo(0).IsName("Open")) 
        {
            OpenSound.Play();

            CloseButton.SetActive(false);
            OpenButton.SetActive(true);
        }
    }

    public void ChatButtonFunction()
    {
        if (!OpenChat)
        {
            ChatScreen.SetActive(true);
            OpenChatButton.SetActive(true);

            ButtonSound.Play();

            ChatApplication.enabled = false;
            OpenChat = true;

            Bildirim.SetActive(false);

            if (!Played)
            {
                StartCoroutine(Bildirimler());

                MessagingAnimator.SetTrigger("Basla");
            }

            Played = true;
        }
    }

    public void Line()
    {
        if (!MessagingAnimator.GetCurrentAnimatorStateInfo(0).IsName("Mesajlaşma"))
        {
            ButtonSound.Play();

            ChatScreen.SetActive(false);
        }
    }

    public void Exit()
    {
        if (!MessagingAnimator.GetCurrentAnimatorStateInfo(0).IsName("Mesajlaşma"))
        {
            ButtonSound.Play();

            ChatScreen.SetActive(false);

            OpenChat = false;
            ChatApplication.enabled = true;

            OpenChatButton.SetActive(false);
        }
    }

    public void CheatLine()
    {
        ButtonSound.Play();

        CheatScreen.SetActive(false);
    }

    public void CheatExit()
    {
        ButtonSound.Play();
        CheatScreen.SetActive(false);

        OpenCheat = false;

        OpenCheatScreen.SetActive(false);
    }

    public void GameLine()
    {
        ButtonSound.Play();

        GameScreen.SetActive(false);
        GameHeader.SetActive(false);
        Arkaplan.SetActive(false);
        Buttons.SetActive(false);
    }

    public void GameExit()
    {
        ButtonSound.Play();

        GameScreen.SetActive(false);
        GameHeader.SetActive(false);
        Arkaplan.SetActive(false);

        OpenGame = false;

        OpenGameButton.SetActive(false);
        Buttons.SetActive(false);
    }

    public void OpenChatButtonFunction()
    {
        if (OpenChat && !ChatScreen.activeSelf && !MessagingAnimator.GetCurrentAnimatorStateInfo(0).IsName("Mesajlaşma"))
        {
            ButtonSound.Play();

            ChatScreen.SetActive(true);
        }
        else if (OpenChat && !MessagingAnimator.GetCurrentAnimatorStateInfo(0).IsName("Mesajlaşma"))
        {
            ButtonSound.Play();

            ChatScreen.SetActive(false);
        }

        if (MessagingAnimator.GetCurrentAnimatorStateInfo(0).IsName("Mesajlaşma"))
        {
            OpenChatApplication.enabled = false;
        }
    }

    public void OpenCheatButtonFunction()
    {
        if (OpenCheat && !CheatScreen.activeSelf)
        {
            ButtonSound.Play();

            CheatScreen.SetActive(true);
        }
        else if (OpenCheat)
        {
            ButtonSound.Play();

            CheatScreen.SetActive(false);
        }
    }
    public void OpenGameButtonFunction()
    {
        if (OpenGame && !GameScreen.activeSelf)
        {
            ButtonSound.Play();

            GameScreen.SetActive(true);
            GameHeader.SetActive(true);
            Arkaplan.SetActive(true);
            Buttons.SetActive(true);
        }
        else if (OpenGame)
        {
            ButtonSound.Play();

            GameScreen.SetActive(false);
            GameHeader.SetActive(false);
            Arkaplan.SetActive(false);
            Buttons.SetActive(false);
        }
    }

    public void Oyunİndir()
    {
        ButtonSound.Play();

        Game.SetActive(true);
    }

    public void Hilelerİndir()
    {
        ButtonSound.Play();

        Cheat.SetActive(true);
    }

    public void OyunEkran()
    {
        if (!OpenGameButton.activeSelf)
        {
            ButtonSound.Play();

            OpenGameButton.SetActive(true);
            GameScreen.SetActive(true);
            GameHeader.SetActive(true);
            Arkaplan.SetActive(true);
            Buttons.SetActive(true);

            OpenGame = true;
        }
        else
        {
            GameApplication.enabled = false;
        }
    }

    public void HileEkran()
    {
        if (!OpenCheatScreen.activeSelf)
        {
            ButtonSound.Play();

            CheatScreen.SetActive(true);
            OpenCheatScreen.SetActive(true);

            OpenCheat = true;
        }
        else
        {
            CheatApplication.enabled = false;
        }
    }

    IEnumerator Bildirimler()
    {
        yield return new WaitForSeconds(2);
        BildirimSound.Play();
        yield return new WaitForSeconds(2);
        BildirimSound.Play();
        yield return new WaitForSeconds(2);
        BildirimSound.Play();
        yield return new WaitForSeconds(2);
        BildirimSound.Play();
        yield return new WaitForSeconds(2);
        BildirimSound.Play();
        yield return new WaitForSeconds(2);
        BildirimSound.Play();
        yield return new WaitForSeconds(2);
        BildirimSound.Play();
        yield return new WaitForSeconds(2);
    }
}
