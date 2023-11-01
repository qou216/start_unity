using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private float moveSpeed = 3f; //움직임 스피드 변수 (실수 값 f)
    //private 으로 접근 할수 없도록
    // Update is called once per frame
    void Update()
    {
        //업데이트함수는 게임 시작하고 계속 자동으로 호출
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        //포지션 값 = 배경화면이미지 이동하도록 * 속도값 // Time.deltaTime는 성능마다 프레임 달라지는거 상관 없이. 똑같은 이동
        if (transform.position.y < -10){//-10위치까지 내려가면
            transform.position += new Vector3(0,20f,0);//위쪽으로 이동. 
        }
    }
}
