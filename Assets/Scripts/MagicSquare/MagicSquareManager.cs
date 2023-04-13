using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSquareManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] magicSquares; //魔法陣格納用の配列
    private int currentMagicSquare; //現在の魔法陣の識別用変数

    private void Start()
    {
        DeactivateAllMagicSquares();
    }

    void DeactivateAllMagicSquares()//全方向の魔法陣を非表示にする
    {
        for (int i = 0; i < magicSquares.Length; i++)
        {
            magicSquares[i].SetActive(false);
        }
    }

    public void ActivateMagicSquare(int newMagicSquare)
    {
        magicSquares[currentMagicSquare].SetActive(false);//いったん今の魔法陣を非表示にして

        currentMagicSquare = newMagicSquare;

        magicSquares[currentMagicSquare].SetActive(true);//再度魔法陣を表示する
    }
}
