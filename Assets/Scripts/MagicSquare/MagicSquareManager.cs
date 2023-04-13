using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSquareManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] magicSquares; //���@�w�i�[�p�̔z��
    private int currentMagicSquare; //���݂̖��@�w�̎��ʗp�ϐ�

    private void Start()
    {
        DeactivateAllMagicSquares();
    }

    void DeactivateAllMagicSquares()//�S�����̖��@�w���\���ɂ���
    {
        for (int i = 0; i < magicSquares.Length; i++)
        {
            magicSquares[i].SetActive(false);
        }
    }

    public void ActivateMagicSquare(int newMagicSquare)
    {
        magicSquares[currentMagicSquare].SetActive(false);//�������񍡂̖��@�w���\���ɂ���

        currentMagicSquare = newMagicSquare;

        magicSquares[currentMagicSquare].SetActive(true);//�ēx���@�w��\������
    }
}
