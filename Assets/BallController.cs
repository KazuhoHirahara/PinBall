using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    //ゲームスコアを表示するテキスト
    private GameObject scoreText;
    //ゲームスコアを格納する変数
    private int game_socre = 0;


    private void OnCollisionEnter(Collision collision)
    {
        //衝突したオブジェクトが星か雲だった場合に点数を加算
        if (collision.gameObject.tag == "SmallStarTag")
        {
            this.game_socre += 10;
        }

        if (collision.gameObject.tag == "SmallCloudTag")
        {
            this.game_socre += 30;

        }
        if (collision.gameObject.tag == "LargeStarTag")
        {
            this.game_socre += 50;

        }
        if (collision.gameObject.tag == "LargeCloudTag")
        {
            this.game_socre += 10000;

        }

    }

    // Use this for initialization
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
        this.scoreText = GameObject.Find("ScoreText");

        //ScoreTextにゲームスコアを表示
        this.scoreText.GetComponent<Text>().text = "SCORE : " + game_socre;

    }

    // Update is called once per frame
    void Update()
    {

        //ScoreTextにゲームスコアを表示
        this.scoreText.GetComponent<Text>().text = "SCORE : " + game_socre;


        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";

        }




    }
}