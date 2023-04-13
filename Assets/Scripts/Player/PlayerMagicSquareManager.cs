using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagicSquareManager : MonoBehaviour
{
    [SerializeField]
    private MagicSquareManager[] playerMagicSquares; //魔法陣格納用の変数
    private int magicSquareIndex; //魔法陣識別用の番号格納用の変数

    private void Awake()
    {
        magicSquareIndex = 0; //最初に装備する魔法陣は0番だよ
        playerMagicSquares[magicSquareIndex].gameObject.SetActive(true); //0番目の魔法陣を表示するよ

    }

    private void Update()
    {
        ChangeMagic();
    }

    private void ChangeMagic() //魔法陣を切り替える関数
    {
        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0f) //マウスホイールが回っていたら
        {
            playerMagicSquares[magicSquareIndex].gameObject.SetActive(false);//いったん表示されている魔法陣を消して、

            magicSquareIndex++;//魔法陣番号を＋して、

            if (magicSquareIndex >= playerMagicSquares.Length)//魔法陣番号が魔法陣の種類数を越えたら、
            {
                magicSquareIndex = 0;//魔法陣番号を0に戻す。
            }

            playerMagicSquares[magicSquareIndex].gameObject.SetActive(true);//改めて魔法陣を表示
        }

        else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0f)//マウスホイールが反対方向に回ったら、
        {
            playerMagicSquares[magicSquareIndex].gameObject.SetActive(false);//いったん表示されている魔法陣を消して、

            magicSquareIndex--;//魔法陣番号を－して、

            if (magicSquareIndex < 0)//魔法陣番号がなったら、
            {
                magicSquareIndex = playerMagicSquares.Length - 1;//魔法陣番号を魔法陣の種類数-1（配列が0から始まるから）にする
            }

            playerMagicSquares[magicSquareIndex].gameObject.SetActive(true);//改めて魔法陣を表示

        }

        for (int i = 0; i < playerMagicSquares.Length; i++)//数字キーで魔法陣を切り替えるためのfor文
        {
            if (Input.GetKeyDown((i+1).ToString()))//i+1の計算をして、その後に文字列化している
            {
                playerMagicSquares[magicSquareIndex].gameObject.SetActive(false);//いったん表示されている魔法陣を消して、

                magicSquareIndex = i;//魔法陣番号をiにして、

                playerMagicSquares[magicSquareIndex].gameObject.SetActive(true);//改めて魔法陣を表示

                break;
            }
        }
    }
}
