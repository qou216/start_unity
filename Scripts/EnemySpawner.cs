using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;

    [SerializeField]
    private GameObject boss;
    private float[] arrPosX = { -3.8f , -1.8f , 0f , 1.8f , 3.8f };  //x값

    [SerializeField]
    private float spawnInterval = 1.5f;//
    // Start is called before the first frame update
    void Start()
    {
       StartEnemyRoutine();
    }
    public void StopEnemyRoutine(){
        StopCoroutine("EnemyRoutine");
    }
    //코루틴 : 메소드인데, 원하는 만큼 시간을 정해서 몇초 기다렸다가 동작하게 
    
    void StartEnemyRoutine(){
        StartCoroutine("EnemyRoutine");
    }
    IEnumerator EnemyRoutine () {//보통은 기다리는 동안 동작 못해/ 코루틴은 몇초 기다려도 동작 가능. 
        yield return new WaitForSeconds(3f);

        float moveSpeed = 5f;
        int spawnCount = 0;
        int enemyIndex = 0;

        while(true){
            foreach(float posX in arrPosX){
                SpawnEnemy(posX,enemyIndex,moveSpeed);
            }

            spawnCount++;
            if(spawnCount % 10 == 0){//10 증가할때마다. +1
                enemyIndex += 1;
                moveSpeed += 2;
            }

            if(enemyIndex>=enemies.Length){
                SpawnBoss();
                enemyIndex = 0;
                moveSpeed = 5f;
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy(float posX, int index, float moveSpeed){
        Vector3 spawnPos = new Vector3(posX, transform.position.y, transform.position.z);

        if(Random.Range(0,5) == 0){
            index += 1;
        }
        if(index >= enemies.Length) { //index 값 7까지만 되고 더이상 증가하지 않게, 
            index = enemies.Length - 1; 
        }

        GameObject enemyObject = Instantiate(enemies[index],spawnPos, Quaternion.identity);
        Enemy enemy = enemyObject.GetComponent<Enemy>();
        enemy.SetMoveSpeed(moveSpeed);
    }
    void SpawnBoss(){
        Instantiate(boss, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
