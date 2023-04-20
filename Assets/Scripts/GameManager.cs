using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    Spawner spawner;//スポナー
    Block activeBlock;//生成されたブロック格納

    [SerializeField]
    private float dropInterval = 0.25f;//次にブロックが落ちるまでのインターバル時間
    float nextdropTimer;//次にブロックが落ちるまでの時間

    //変数の作成//
    //ボードのスクリプトを格納
    Board board;

    

    

    private void Start()
    {
        //スポナーオブジェクトをスポナー変数に格納する
        spawner = GameObject.FindObjectOfType<Spawner>();

        //ボードを変数に格納する
        board = GameObject.FindObjectOfType<Board>();

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

                //UpdateでBoardクラスの関数を呼び出してボードから出ていないか確認
                if (!board.CheckPosition(activeBlock))
                {
                    activeBlock.MoveUp();

                    activeBlock = spawner.SpawnBlock();
                }

            }

        }




        
    }


}
