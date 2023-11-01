using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;//속도 조절위한 변수 값
    
    [SerializeField]
    private GameObject[] weapons;
    private int weaponIndex = 0;

    [SerializeField]
    private Transform shootTransform; // 위치 , 회전 값 같은거 받음

    [SerializeField]
    private float shootInterval = 0.05f; // 미사일 쏘는 간격 
    private float lastShotTime = 0f; // 마지막으로 미사일 쏜 시간 

    // Update is called once per frame
    void Update()
    {   // 상하좌우 키보드로 
         float horizontalInput = Input.GetAxisRaw("Horizontal"); //수평 입력값 <- ->
         float verticalInput = Input.GetAxisRaw("Vertical");// 상하 
         Vector3 moveTo = new Vector3(horizontalInput, verticalInput, 0f); //x,y z 값 / 어디로 이동할지
         transform.position += moveTo * moveSpeed * Time.deltaTime;

        //좌우만 키보드로
        // Vector3 moveTo = new Vector3(moveSpeed * Time.deltaTime,0,0);
        // if (Input.GetKey(KeyCode.LeftArrow)){//왼쪽 방향키
        //     transform.position -= moveTo;
        // }else if(Input.GetKey(KeyCode.RightArrow)){//오른쪽 방향키
        //     transform.position += moveTo;
        // }
        
        //마우스로
        // Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // float toX = Mathf.Clamp(mousePos.x, -2.35f, 2.35f);
        // transform.position = new Vector3(toX, transform.position.y,transform.position.z);

        if(GameManager.instance.isGameOver ==false){
            Shoot();
        }
        

    }
    void Shoot(){//void 는 반환값이 없는 메소드 
        if(Time.time - lastShotTime > shootInterval) {// 게임 시작 후 현재까지 흐른 시간 - 마지막 시간 > 인터벌 시간보다 크면 
            Instantiate(weapons[weaponIndex], shootTransform.position, Quaternion.identity);
            lastShotTime = Time.time; // 마지막 미사일 쏜시간을 현재 시간으로 업데이트
        } 
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "Boss"){
            GameManager.instance.SetGameOver();
            Destroy(gameObject);
        }else if(other.gameObject.tag == "Coin"){
            GameManager.instance.increaseCoin();
            Destroy(other.gameObject);
        }
    }

    public void Upgrade(){
        weaponIndex += 1;
        if(weaponIndex >= weapons.Length){
            weaponIndex = weapons.Length - 1;
        }
    }
}
