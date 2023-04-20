using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{


    //ボード基盤用の四角枠格納用
    //ボードの高さ調整用数値

    [SerializeField]
    private Transform emptySprite;

    [SerializeField]
    private int height = 30, width = 10, header = 8;



    private void Start()
    {
        CreateBoard();
    }


    //関数の作成//
    //ボードを生成する関数の作成
    void CreateBoard()
    {
        if (emptySprite)
        {
            for (int y = 0; y < height - header; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Transform clone = Instantiate(emptySprite,
                        new Vector3(x, y, 0), Quaternion.identity);

                    clone.transform.parent = transform;
                }
            }
        }
    }


    //ブロックが北内にあるのか判定する関数を呼ぶ関数
    public bool CheckPosition(Block block)
    {
        foreach(Transform item in block.transform)
        {
            Vector2 pos = new Vector2(Mathf.Round(item.position.x), Mathf.Round(item.position.y));


            if(!BoardOutCheck((int)pos.x, (int)pos.y))
            {
                return false;
            }
        }

        return true;
    }

    //枠内にあるのか判定する関数

    bool BoardOutCheck(int x, int y)
    {
        //x軸は0以上width未満　y軸は0以上
        return (x >= 0 && x < width && y >= 0);
    }
}
