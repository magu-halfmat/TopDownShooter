using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement
{
    //変数

    //入力受け取り用の変数
    private float moveX, moveY;

    //カメラ格納用の変数
    private Camera mainCam;

    //マウスの位置、方向を格納する変数
    private Vector2 mousePos, direction;

    //一時的なスケール格納用の変数
    private Vector3 tempScale;

    //アニメーションを格納する変数
    private Animator animator;

    private void Awake()
    {
        //コンポーネントを取得
        mainCam = Camera.main;
        animator = GetComponent<Animator>();

    }

    private void FixedUpdate()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        PlayerTurning();

        CharacterMovement(moveX, moveY);
    }


    void PlayerTurning()
    {
        //mousePosを、画面内のマウスの位置をゲーム内の位置に変換したものにする
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        //マウス位置からプレイヤーの位置を引いてベクトルを得る。正規化で大きさを1に（つまり方向のみの情報にする）。
        direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y).normalized;

        PlayerAnimation(direction.x, direction.y);

    }

    void PlayerAnimation(float x, float y)
    {
        //方向を小数→整数化
        x = Mathf.RoundToInt(x);
        y = Mathf.RoundToInt(y);

        //PlayerのScaleを取得してtempScaleに入れる
        tempScale = transform.localScale;

        if (x > 0)
        //もしxが0より大きい（マウスポインタがプレイヤーより右にある）ならば、
        {
            tempScale.x = Mathf.Abs(tempScale.x);
            //絶対値（正の数になる）を返す

        }
        else if (x < 0)
        //もしxが0より小さい（マウスポインタがプレイヤーより左にある）なら
        {
            tempScale.x = -Mathf.Abs(tempScale.x);
            //－の絶対値（負の数になる）を返す
        }

        transform.localScale = tempScale;
        //プレイヤーの向きをtempScaleに更新する

        x = Mathf.Abs(x);
        //アニメーションのxの判定は0か1かしかないので－にならないようにするために絶対値化する

        animator.SetFloat("FaceX", x);
        animator.SetFloat("FaceY", y);
    }
}
