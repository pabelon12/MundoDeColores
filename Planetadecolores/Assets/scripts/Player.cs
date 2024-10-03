using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float verticalForce = 400f;
    [SerializeField] private float restartDelay = 1f;
    [SerializeField] private ParticleSystem PlayerParticle;
    [SerializeField] private Color Amarillo;
    [SerializeField] private Color Celeste;
    [SerializeField] private Color Rojo;
    [SerializeField] private Color Morado;
    [SerializeField] private AudioClip Moneda;
    [SerializeField] private AudioClip Perder;
    [SerializeField] private AudioClip transformar;
    [SerializeField] private AudioClip Meta;
    //comesaremos a anotar las variables que bamos a utilizar para nuestro sistema de puntos
    public int punto;
    public Text puntoText;

    //variable de alamcenar el color actual 
    private string currentColor;
    Rigidbody2D playerRB;
    SpriteRenderer playerSR;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
     
        playerSR = GetComponent<SpriteRenderer>();
        punto = 0;
    

        ChangeColor();

    }

    // Update is called once per frame
    void Update()
    {
        //controles del juego
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRB.velocity = Vector2.zero;
           playerRB.AddForce(new Vector2(0, 400));

        }

    }
   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("paleta"))
        {
            Control.Instance.EjecutarSonido(transformar);
            ChangeColor();
            Destroy(collision.gameObject);
            return;

        }
        if (collision.gameObject.CompareTag("DIamante"))
        {
            Control.Instance.EjecutarSonido(Moneda);
            Destroy(collision.gameObject);
            punto++;
            puntoText.text = punto.ToString();  
            return;
            
        }
        if (collision.gameObject.CompareTag("meta")) {
            //indica cuando llega va a pasar al siguiente nivel 
            gameObject.SetActive(false);
            Instantiate(PlayerParticle, transform.position, Quaternion.identity);
            Control.Instance.EjecutarSonido(Meta);
            Invoke("LoadNextScene", restartDelay);
            return;

        }
        //interacion con la plataforma
        if (!collision.gameObject.CompareTag(currentColor))
        {
            gameObject.SetActive(false);
            Instantiate(PlayerParticle,transform.position, Quaternion.identity);
            Control.Instance.EjecutarSonido(Perder);
            Invoke("RestartScene",restartDelay);
        } 
 
    }
    void LoadNextScene()
    {

        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeSceneIndex + 1);

    }



    void RestartScene()
    {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeSceneIndex);
    }
    //propio metodo
    void ChangeColor()
    {
        //1er numero seria inclusivo y 2do exclusivo 
        int randomNumber = Random.Range(0, 4);
        Debug.Log(randomNumber);

        if (randomNumber == 0)
        {
            playerSR.color = Morado;
            currentColor = "morado";
        }
        else if (randomNumber == 1)
        {
            playerSR.color = Celeste;
            currentColor = "celeste";
        }
        else if (randomNumber == 2)
        {
            playerSR.color = Rojo;
            currentColor = "rojo";
        }
        else if (randomNumber == 3)
        {
            playerSR.color = Amarillo;
            currentColor = "amarillo";
        }
    }
    

}
