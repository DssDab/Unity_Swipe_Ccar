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

        // �������� ���̸� ���Ѵ�.
        if (Input.GetMouseButtonDown(0)&&GameDirector.m_State ==GameState.gameReady)
        {
            // ���콺 ���߸� Ŭ���� ��ǥ
            this.StartPos = Input.mousePosition;
           
        }
        else if(Input.GetMouseButtonUp(0) && GameDirector.m_State == GameState.gameReady)
        {
            Vector2 EndPos = Input.mousePosition; ;
            float SwipeLength = EndPos.x - this.StartPos.x;
            // �������� ���̸� ó�� �ӵ��� �����Ѵ�.

            if(SwipeLength <= 0)  // ���� SwipeLength���� 0���� �۴ٸ� �÷��̾ �ڷ� ���콺�� ���´ٴ� ��
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
