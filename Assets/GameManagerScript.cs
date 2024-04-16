using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    int[] map;

    void PrintArray()
    {
        // 文字列の宣言と初期化
        string debugText = "";

        for (int i = 0; i < map.Length; i++)
        {
            // 文字列に結合していく
            debugText += map[i].ToString() + ",";
        }

        // 結合した文字列を出力
        Debug.Log(debugText);
    }

    int GetPlayerIndex()
    {
        for(int i=0;i<map.Length;i++)
        {
            if (map[i]==1)
            {
                return i;
            }
        }
        return -1;
    }

    bool MoveNumber(int number,int moveFrom,int moveTo)
    {
        // 移動先が範囲外なら移動可
        if(moveTo < 0 || moveTo >= map.Length)
        {
            return false;
        }

        // 移動先に2(箱)がいたら
        if (map[moveTo]==2)
        {
            // どの方向へ移動するかを算出
            int velocity = moveTo - moveFrom;

            // プレイヤーの移動先から、さらに先へ2(箱)を移動させる
            bool success = MoveNumber(2, moveTo, moveTo + velocity);

            // もし箱が移動失敗したら、プレイヤーの移動も失敗
            if(!success)
            {
                return false;
            }
        }

        map[moveTo] = number;
        map[moveFrom] = 0;
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        // 配列の実態の作成と初期化
        map = new int[] { 0, 0, 2, 1, 2, 0, 0, 0, 0 };

        PrintArray();

        // デバッグログの出力
        //Debug.Log("Hello World");
    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {

            int playerIndex = GetPlayerIndex();

            MoveNumber(1, playerIndex, playerIndex + 1);

            PrintArray();
            
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            int playerIndex = GetPlayerIndex();

            MoveNumber(1, playerIndex, playerIndex - 1);

            PrintArray();
        }
    }


}
