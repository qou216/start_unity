using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private float minY = -7f;
    // Start is called before the first frame update
    void Start()
    {
        Jump();
    }

    void Jump(){//동전이 위로 갔다가 내려오게 하는 함수 
        Rigidbody2D rigidBody= GetComponent<Rigidbody2D>();

        float randomJumpForce = Random.Range(4f, 8f);
        Vector2 jumpVelocity =Vector2.up * randomJumpForce;
        jumpVelocity.x=Random.Range(-2f,2f);
        rigidBody.AddForce(jumpVelocity, ForceMode2D.Impulse);
    }
    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < minY){ // y가 -7보다  작아지면 
            Destroy(gameObject); //기다리는 시간 없이 바로 삭제 
        }
    }
}
