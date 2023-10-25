using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarController : MonoBehaviour
{
    float Speed = 0.0f;
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
        if (GameDirector.m_State == GameState.gameReady)
        {

            // 스와이프 길이를 구한다.
            if (Input.GetMouseButtonDown(0))
            {
                // 마우스 단추를 클릭한 좌표
                this.StartPos = Input.mousePosition;

            }
            else if (Input.GetMouseButtonUp(0))
            {
                Vector2 EndPos = Input.mousePosition; ;
                float SwipeLength = EndPos.x - this.StartPos.x;
                // 스와이프 길이를 처음 속도로 변경한다.

                Speed = SwipeLength / 500.0f;
                GetComponent<AudioSource>().Play();
                GameDirector.m_State = GameState.gameIng;
            }
        }
        else if (GameDirector.m_State == GameState.gameIng)
        {
            if (!(Speed <= 0))
            {
                transform.Translate(Speed, 0, 0);
                this.Speed *= 0.98f;
            }
            if(this.Speed <=0.005f)
            {
                this.Speed = 0.0f;
                GameDirector.m_State = GameState.gameReady;

                //GameDirector a_GDirector = null;
                //GameObject a_GObj = GameObject.Find("GameMgr");
                //if(a_GObj != null) 
                //    a_GDirector = a_GObj.GetComponent<GameDirector>();
                //if (a_GDirector != null)
                //    a_GDirector.RecordLength();
                GameDirector a_GDirector = GameObject.FindObjectOfType<GameDirector>();     // GameDirector타입의 오브젝트를 Hieracchy에서 위에서 아래로 찾아보면서 제일 처음 만나 오브젝트를 가져온다?
                if (a_GDirector != null)
                    a_GDirector.RecordLength();

                this.transform.position = new Vector3(-7.0f, -3.6f, 0);
            }
           

        }
 
    }
}
