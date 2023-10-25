using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameState
{
    gameReady =1,
    gameIng =2,
    gameOver =3
}
public class GameDirector : MonoBehaviour
{
    GameObject car;
    GameObject Flag;
    GameObject distance;
    public static GameState m_State = GameState.gameReady;
    public Button Reset;
    public Text[] PlayerScore;
    static int m_Turn = 0;
    float[] m_PScore;
    int m_UserTurn;

    void Start()
    {
        this.car = GameObject.Find("car");
        this.Flag = GameObject.Find("flag");
        this.distance = GameObject.Find("Distance");

        if (Reset != null)
            Reset.onClick.AddListener(() =>
            {

            });

        m_State = GameState.gameReady;
    }

    void Update()
    {
        float length = this.Flag.transform.position.x - this.car.transform.position.x;
        this.distance.GetComponent<Text>().text = "목표 지점까지" + length.ToString("F2") + "m";

      
    }
   
        
    }
   


