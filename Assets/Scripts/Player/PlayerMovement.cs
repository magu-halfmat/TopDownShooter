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

    //プレイヤーの魔法陣管理スクリプト格納用の変数
    private PlayerMagicSquareManager playerMagicSquareManager;

    private void Awake()
    {
        //コンポーネントを取得
        mainCam = Camera.main;
        animator = GetComponent<Animator>();

        playerMagicSquareManager = GetComponent<PlayerMagicSquareManager>();

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

        DirectionMagicSquare(x, y);
    }

    void DirectionMagicSquare(float x, float y)//魔法陣の方向決め
    {
        if (x == 1f && y == 0)//side向きなら
        {
            playerMagicSquareManager.Activate(0);//0番の魔法陣を表示
        }

        if (x == 0 && y == 1f)//up向きなら
        {
            playerMagicSquareManager.Activate(1);//1番の魔法陣を表示
        }

        if (x == 0 && y == -1f)//front向きなら
        {
            playerMagicSquareManager.Activate(2);//2番の魔法陣を表示
        }

        if (x == 1f && y == 1f)//side-up向きなら
        {
            playerMagicSquareManager.Activate(3);//3番の魔法陣を表示
        }

        if (x == 1f && y == -1f)//side-down向きなら
        {
            playerMagicSquareManager.Activate(4);//4番の魔法陣を表示
        }
    }
}
