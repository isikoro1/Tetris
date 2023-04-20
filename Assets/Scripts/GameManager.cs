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

    //ボードのスクリプトを格納
    Board board;

    //入力受付タイマー(3種類)
    float nextKeyDownTimer, nextKeyLeftRightTimer, nextKeyRotateTimer;

    //入力インターバル（３種類）
    [SerializeField]
    private float nextKeyDownInterval, nextKeyLeftRightInterval, nextKeyRotateInterval;

    private void Start()
    {
        //スポナーオブジェクトをスポナー変数に格納する
        spawner = GameObject.FindObjectOfType<Spawner>();

        //ボードを変数に格納する
        board = GameObject.FindObjectOfType<Board>();

        spawner.transform.position = Rounding.Round(spawner.transform.position);

        //タイマーの初期設定
        nextKeyDownTimer = Time.time + nextKeyDownInterval;
        nextKeyLeftRightTimer = Time.time + nextKeyLeftRightInterval;
        nextKeyRotateTimer = Time.time + nextKeyRotateInterval;

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

                    board.SaveBlockInGrid(activeBlock);

                    activeBlock = spawner.SpawnBlock();
                }

            }

        }
    
    }

    //関数の作成//

    //キーの入力を検知してブロックを動かす関数

    //ボードの底についた時に次のブロックを生成する関数
    void PlayerInput()
    {
        if (Input.GetKey(KeyCode.D) && (Time.time > nextKeyLeftRightTimer) || Input.GetKeyDown(KeyCode.D))
        {
            activeBlock.MoveRight();

            nextKeyLeftRightTimer = Time.time + nextKeyLeftRightInterval;

            if (!board.CheckPosition(activeBlock))
            {
                activeBlock.MoveLeft();
            }
        }
        else if(Input.GetKey(KeyCode.A) && (Time.time > nextKeyLeftRightTimer) || Input.GetKeyDown(KeyCode.A))
        {
            activeBlock.MoveLeft();

            nextKeyLeftRightTimer = Time.time + nextKeyLeftRightInterval;

            if (!board.CheckPosition(activeBlock))
            {
                activeBlock.MoveRight();
            }
        }//途中まで
        //回転
    }
}
