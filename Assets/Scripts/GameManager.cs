using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //変数の作成//
    
    

    Spawner spawner;//スポナー
    Block activeBlock;//生成されたブロック格納

    //スポナーオブジェクトをスポナー変数に格納するコードの記述

    private void Start()
    {
        spawner = GameObject.FindObjectOfType<Spawner>();

        //スポナークラスからブロック生成関数を読んで変数に格納する

        if (!activeBlock)
        {
            activeBlock = spawner.SpawnBlock();
        }



    }

    

}
