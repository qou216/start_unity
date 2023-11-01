using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]

    private float moveSpeed =10f;
    private float minY = -7f;
    [SerializeField]
    private float hp = 1f;

    [SerializeField]
    private GameObject coin;



    public void SetMoveSpeed (float moveSpeed){
        this.moveSpeed = moveSpeed;//this 는 클래스 내 정의된 변수 / 인자와 변수 이름이 같아서 써줌. 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        if(transform.position.y < minY){ // y가 -7보다  작아지면 
            Destroy(gameObject); //기다리는 시간 없이 바로 삭제 
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {//유니티에서 제공하는 함수/ 충돌감지만할때
        if(other.gameObject.tag == "Weapon" ){
            Weapon weapon = other.gameObject.GetComponent<Weapon>();
            hp -= weapon.damage;
            if(hp <= 0){
                if(gameObject.tag == "Boss"){
                    GameManager.instance.SetGameOver();
                }
                Destroy(gameObject);
                Instantiate(coin, transform.position, Quaternion.identity);
            }
            Destroy(other.gameObject);
        }
    }
    
   
}
