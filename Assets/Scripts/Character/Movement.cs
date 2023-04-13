using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //変数

    //各軸の移動スピード
    [SerializeField]
    protected float xSpeed = 1.5f, ySpeed = 1.5f;

    //移動量
    private Vector2 moveDelta;


    //関数
    protected void CharacterMovement(float x, float y)
    {
        moveDelta = new Vector2(x * xSpeed, y * ySpeed);

        transform.Translate(moveDelta.x * Time.deltaTime, moveDelta.y * Time.deltaTime, 0);

    }
}
