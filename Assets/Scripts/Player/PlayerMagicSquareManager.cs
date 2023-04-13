using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagicSquareManager : MonoBehaviour
{
    [SerializeField]
    private MagicSquareManager[] playerMagicSquares; //���@�w�i�[�p�̕ϐ�
    private int magicSquareIndex; //���@�w���ʗp�̔ԍ��i�[�p�̕ϐ�

    private void Awake()
    {
        magicSquareIndex = 0; //�ŏ��ɑ������閂�@�w��0�Ԃ���
        playerMagicSquares[magicSquareIndex].gameObject.SetActive(true); //0�Ԗڂ̖��@�w��\�������

    }

    private void Update()
    {
        ChangeMagic();
    }

    private void ChangeMagic() //���@�w��؂�ւ���֐�
    {
        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0f) //�}�E�X�z�C�[��������Ă�����
        {
            playerMagicSquares[magicSquareIndex].gameObject.SetActive(false);//��������\������Ă��閂�@�w�������āA

            magicSquareIndex++;//���@�w�ԍ����{���āA

            if (magicSquareIndex >= playerMagicSquares.Length)//���@�w�ԍ������@�w�̎�ސ����z������A
            {
                magicSquareIndex = 0;//���@�w�ԍ���0�ɖ߂��B
            }

            playerMagicSquares[magicSquareIndex].gameObject.SetActive(true);//���߂Ė��@�w��\��
        }

        else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0f)//�}�E�X�z�C�[�������Ε����ɉ������A
        {
            playerMagicSquares[magicSquareIndex].gameObject.SetActive(false);//��������\������Ă��閂�@�w�������āA

            magicSquareIndex--;//���@�w�ԍ����|���āA

            if (magicSquareIndex < 0)//���@�w�ԍ����Ȃ�����A
            {
                magicSquareIndex = playerMagicSquares.Length - 1;//���@�w�ԍ��𖂖@�w�̎�ސ�-1�i�z��0����n�܂邩��j�ɂ���
            }

            playerMagicSquares[magicSquareIndex].gameObject.SetActive(true);//���߂Ė��@�w��\��

        }

        for (int i = 0; i < playerMagicSquares.Length; i++)//�����L�[�Ŗ��@�w��؂�ւ��邽�߂�for��
        {
            if (Input.GetKeyDown((i+1).ToString()))//i+1�̌v�Z�����āA���̌�ɕ����񉻂��Ă���
            {
                playerMagicSquares[magicSquareIndex].gameObject.SetActive(false);//��������\������Ă��閂�@�w�������āA

                magicSquareIndex = i;//���@�w�ԍ���i�ɂ��āA

                playerMagicSquares[magicSquareIndex].gameObject.SetActive(true);//���߂Ė��@�w��\��

                break;
            }
        }
    }
}
