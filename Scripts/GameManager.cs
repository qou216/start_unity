using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null ;

    [SerializeField]//private 라도 나타낼 수 있다. 
    private TextMeshProUGUI text;
    
    private int coin = 0;

    [HideInInspector]//public 이어도 숨길수 있다.
    public bool isGameOver = false;

    [SerializeField]
    private GameObject gameOverPanel;//패널을 담을 변수


    void Awake() {
        if (instance == null){
            instance=this;
        }
    }

    public void increaseCoin(){
        coin += 1;
        text.SetText(coin.ToString());

        if(coin % 2 == 0){//동전 개수 일정하게 먹으면 무기 업그레이드 하도록 
            Player player = FindObjectOfType<Player>();
            if (player != null){
                player.Upgrade();
            }
        }
    }

    public void SetGameOver(){
        isGameOver = true;

        EnemySpawner enemySpawner = FindObjectOfType<EnemySpawner>();
        if(enemySpawner != null){
            enemySpawner.StopEnemyRoutine();
        }
        Invoke("showGameOverPanel",1f);// 메소드 네임 , 적은시간 만큼(1초) 기다린 뒤에 실행
    }

    void showGameOverPanel(){
         gameOverPanel.SetActive(true);//게임 끝났을 때 , 패널 활성화 
    }

    public void PlayeAgain(){
        SceneManager.LoadScene("SampleScene");//어떤신을 로드할건지 적어주기 
    }
}
