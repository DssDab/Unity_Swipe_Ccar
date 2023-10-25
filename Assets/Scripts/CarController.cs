using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarController : MonoBehaviour
{
    public float Speed = 0.0f;
    // Start is called before the first frame update
    Vector2 StartPos;
    
    void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
    }

    // Update is called once per frame
    void Update()
    {

        //if(Input.GetMouseButtonDown(0))
        //{
        //    this.Speed = 0.2f;
        //}

        // 스와이프 길이를 구한다.
        if (Input.GetMouseButtonDown(0)&&GameDirector.m_State ==GameState.gameReady)
        {
            // 마우스 단추를 클릭한 좌표
            this.StartPos = Input.mousePosition;
           
        }
        else if(Input.GetMouseButtonUp(0) && GameDirector.m_State == GameState.gameReady)
        {
            Vector2 EndPos = Input.mousePosition; ;
            float SwipeLength = EndPos.x - this.StartPos.x;
            // 스와이프 길이를 처음 속도로 변경한다.

            if(SwipeLength <= 0)  // 만약 SwipeLength값이 0보다 작다면 플레이어가 뒤로 마우스를 보냈다는 뜻
            {
                SwipeLength = 0f;
            }

            Speed = SwipeLength / 500.0f;
            GetComponent<AudioSource>().Play();
            GameDirector.m_State = GameState.gameIng;
        }
        if(!(Speed <= 0))
        {
        transform.Translate(Speed, 0, 0);
        this.Speed *= 0.98f;
        }

            
       
    }
}
