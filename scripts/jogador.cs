using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
public class jogador : MonoBehaviour
{
    public Rigidbody2D rb ;
    public float forcaPulo ;    
    private bool estanochao ;
    public float distanciaMinimaChao = 1 ;
    public LayerMask Layerchao;
    public float pontos;
    
    private float highScore ;

    public float multiplicadorpontos = 1 ;
    public Text pontostext;
    public Text Highscoretext;  
    public Animator animatorComponent; 
    public AudioSource pularAudiosource;
    public AudioSource cempontosAudiosource;
    public AudioSource Fimdejogo;
    public GameObject Cenario;
    public GameObject Cenario1;
    public GameObject reniciarbutton;
    public AudioSource drivesound;
    public bool ativar;
    
    // Start is called before the first frame update
    private void Start()


    {
         
         highScore = PlayerPrefs.GetFloat("HIGHSCORE");  
         Highscoretext.text = Mathf.FloorToInt(highScore).ToString();
         
         
    }

    // Update is called once per frame
    void Update()
    {

      pontos  += Time.deltaTime * multiplicadorpontos;
       
      var pontosArrendondados = Mathf.FloorToInt(pontos);

      pontostext.text = pontosArrendondados.ToString();


      if (pontosArrendondados > 0 && pontosArrendondados %  100 == 0 && !cempontosAudiosource.isPlaying)
         {
           cempontosAudiosource.Play(); 
         }

      if (pontos > 50)
      {
       Cenario.SetActive(true);
       Cenario1.SetActive(true);
       
      }        
           
       
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            Pular();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
           Abaixar(); 
        }
         else if (Input.GetKeyUp(KeyCode.DownArrow))
         {
           Levantar (); 
         }

      
    }
    void Pular()
    {
       if(estanochao)
       {
          rb.AddForce(Vector2.up * forcaPulo);

          pularAudiosource.Play();
       }
       
       
       
    }
    void Abaixar (){
         ("abaixado", true );
    }

     void Levantar (){
      animatorComponent.SetBool("abaixado", false );
    }
     private void FixedUpdate() 
     {
        estanochao= Physics2D.Raycast(transform.position , Vector2.down, distanciaMinimaChao, Layerchao); 
     } 

     private void OnCollisionEnter2D(Collision2D other) 
     {
         if(other.gameObject.CompareTag("Inimigos"))
         {
            if (pontos>highScore)
            {
               highScore = pontos;
               
               PlayerPrefs.SetFloat("HIGHSCORE",highScore);
            }
            
             Fimdejogo.Play();
            reniciarbutton.SetActive(true);
            Time.timeScale = 0;
                       
         } 
     }
} 
