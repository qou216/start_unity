using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Weapon : MonoBehaviour
{
    [SerializeField] //piblic 일때는 안써도 되나 private 인데, 화면에 나타나게 할때는 필요. 
    private float moveSpeed = 10f;
    public float damage = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,1f);// 유니티 제공함수 1초있다가 사라지게,
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
    }
}
