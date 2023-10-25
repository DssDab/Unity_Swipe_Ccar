using JetBrains.Annotations;
using Mono.CompilerServices.SymbolWriter;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameState
{
    gameReady = 0,
    gameIng   = 1,
    gameOver  = 2
}
class PlayerData
{
    public int m_index = 0;
    public float m_SvLen =0.0f;
    public int m_Ranking = -1;
}
public class GameDirector : MonoBehaviour
{
   
    GameObject car;
    GameObject Flag;
    GameObject distance;
    public static GameState m_State = GameState.gameReady;
    public Button Reset;
    public Text[] PlayerScore;
    int m_Turn = 0;
    float m_Length = 0.0f;
    List<PlayerData> m_Players = new List<PlayerData>();
    
    void Start()
    {
        this.car = GameObject.Find("car");
        this.Flag = GameObject.Find("flag");
        this.distance = GameObject.Find("Distance");

        if (Reset != null)
            Reset.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(0);
            });

        m_State = GameState.gameReady;
    }

    void Update()
    {
        float length = this.Flag.transform.position.x - this.car.transform.position.x;
        length = Mathf.Abs(length);
        this.distance.GetComponent<Text>().text = "목표 지점까지" + length.ToString("F2") + "m";

        m_Length = length;
        if(this.Flag.transform.position.x < this.car.transform.position.x)
        {
            m_Length = 14.50f;
        }
        
    }
    public void RecordLength()
    {
        if(m_Turn < PlayerScore.Length)
        {
            PlayerScore[m_Turn].text = "Player " + (m_Turn + 1).ToString()
                                       +" : " + m_Length.ToString("F2") + "m";
            PlayerData a_Node = new PlayerData();
            a_Node.m_index = m_Turn;
            a_Node.m_SvLen = m_Length;
            m_Players.Add(a_Node);
            m_Turn++;
        }
        if(m_Turn >= PlayerScore.Length)
        {
            m_State = GameState.gameOver;
            RankingAlgorithm();
            if (Reset != null)
                Reset.gameObject.SetActive(true);
        }
    }
    int SvLenComp(PlayerData x, PlayerData y)
    {
        return x.m_SvLen.CompareTo(y.m_SvLen);  // 오름차순 정렬
    }
    void RankingAlgorithm()
    {
        m_Players.Sort(SvLenComp);
        PlayerData a_Players = null;
        for(int i=0; i <m_Players.Count;i++)
        {
            a_Players = m_Players[i];
            if (PlayerScore.Length <= a_Players.m_index)
                continue;

            a_Players.m_Ranking = i + 1;
            PlayerScore[i].text = "Player " + (i + 1).ToString()
                                     + " : " + a_Players.m_SvLen.ToString("F2") + "m "+ a_Players.m_Ranking.ToString()+"등";
        }
    }

}
   


