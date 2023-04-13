using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //�ϐ�

    //�e���̈ړ��X�s�[�h
    [SerializeField]
    protected float xSpeed = 1.5f, ySpeed = 1.5f;

    //�ړ���
    private Vector2 moveDelta;


    //�֐�
    protected void CharacterMovement(float x, float y)
    {
        moveDelta = new Vector2(x * xSpeed, y * ySpeed);

        transform.Translate(moveDelta.x * Time.deltaTime, moveDelta.y * Time.deltaTime, 0);

    }
}
