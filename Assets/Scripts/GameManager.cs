using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //変数の作成//
    

    Spawner spawner;//スポナー
    Block activeBlock;//生成されたブロック格納

    //変数の作成//
    //次にブロックが落ちるまでのインターバル時間
    //次にブロックが落ちるまでの時間

    [SerializeField]
    private float dropInterval = 0.25f;
    float nextdropTimer;
    

    private void Start()
    {
        //スポナーオブジェクトをスポナー変数に格納する
        spawner = GameObject.FindObjectOfType<Spawner>();

        //スポナークラスからブロック生成関数を読んで変数に格納する
        if (!activeBlock)
        {
            activeBlock = spawner.SpawnBlock();
        }


    }

    private void Update()
    {
        //Updateで時間の判定をして判定次第で落下関数を呼ぶ

        if (Time.time > nextdropTimer)
        {
            nextdropTimer = Time.time + dropInterval;


            if (activeBlock)
            {
                activeBlock.MoveDown();
            }
        }




        
    }


}
