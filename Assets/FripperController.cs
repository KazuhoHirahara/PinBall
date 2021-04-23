using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;


    // Use this for initialization
    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);


    }

    // Update is called once per frame
    void Update()
    {
        //



        //左矢印キー、A、Sキー、画面左側を押した時左フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag" ||
            Input.GetKeyDown(KeyCode.DownArrow) && tag == "LeftFripperTag" ||
            Input.GetKeyDown(KeyCode.A) && tag == "LeftFripperTag" ||
            Input.GetKeyDown(KeyCode.S) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //右矢印キー、D、Sキー、画面右側を押した時右フリッパーを動かす

        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag" ||
            Input.GetKeyDown(KeyCode.DownArrow) && tag == "RightFripperTag" ||
            Input.GetKeyDown(KeyCode.D) && tag == "RightFripperTag" ||
            Input.GetKeyDown(KeyCode.S) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //キーが離された時フリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag" ||
            Input.GetKeyUp(KeyCode.DownArrow) && tag == "LeftFripperTag" ||
            Input.GetKeyUp(KeyCode.A) && tag == "LeftFripperTag" ||
            Input.GetKeyUp(KeyCode.S) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }


        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag" ||
            Input.GetKeyUp(KeyCode.DownArrow) && tag == "RightFripperTag" ||
            Input.GetKeyUp(KeyCode.D) && tag == "RightFripperTag" ||
            Input.GetKeyUp(KeyCode.S) && tag == "RightFripperTag")

        {
            SetAngle(this.defaultAngle);
        }





        foreach (Touch touch in Input.touches)
       {
 

            //画面左側を押した時左フリッパーを動かす
            if (touch.phase == TouchPhase.Stationary && touch.position.x < Screen.width / 2.0f && tag == "LeftFripperTag")
            {
                SetAngle(this.flickAngle);
            }



            if(touch.phase == TouchPhase.Stationary && touch.position.x > Screen.width / 2.0f && tag == "RightFripperTag")
            {
                SetAngle(this.flickAngle);
            }

            if(touch.phase == TouchPhase.Ended && touch.position.x < Screen.width / 2.0f && tag == "LeftFripperTag")
            {
                SetAngle(this.defaultAngle);
            }


            if(touch.phase == TouchPhase.Ended && touch.position.x > Screen.width / 2.0f && tag == "RightFripperTag")
                  {
                SetAngle(this.defaultAngle);
            }


        }

    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}