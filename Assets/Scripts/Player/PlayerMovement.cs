using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement
{
    //�ϐ�

    //���͎󂯎��p�̕ϐ�
    private float moveX, moveY;

    //�J�����i�[�p�̕ϐ�
    private Camera mainCam;

    //�}�E�X�̈ʒu�A�������i�[����ϐ�
    private Vector2 mousePos, direction;

    //�ꎞ�I�ȃX�P�[���i�[�p�̕ϐ�
    private Vector3 tempScale;

    //�A�j���[�V�������i�[����ϐ�
    private Animator animator;

    private void Awake()
    {
        //�R���|�[�l���g���擾
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
        //mousePos���A��ʓ��̃}�E�X�̈ʒu���Q�[�����̈ʒu�ɕϊ��������̂ɂ���
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        //�}�E�X�ʒu����v���C���[�̈ʒu�������ăx�N�g���𓾂�B���K���ő傫����1�Ɂi�܂�����݂̂̏��ɂ���j�B
        direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y).normalized;

        PlayerAnimation(direction.x, direction.y);

    }

    void PlayerAnimation(float x, float y)
    {
        //������������������
        x = Mathf.RoundToInt(x);
        y = Mathf.RoundToInt(y);

        //Player��Scale���擾����tempScale�ɓ����
        tempScale = transform.localScale;

        if (x > 0)
        //����x��0���傫���i�}�E�X�|�C���^���v���C���[���E�ɂ���j�Ȃ�΁A
        {
            tempScale.x = Mathf.Abs(tempScale.x);
            //��Βl�i���̐��ɂȂ�j��Ԃ�

        }
        else if (x < 0)
        //����x��0��菬�����i�}�E�X�|�C���^���v���C���[��荶�ɂ���j�Ȃ�
        {
            tempScale.x = -Mathf.Abs(tempScale.x);
            //�|�̐�Βl�i���̐��ɂȂ�j��Ԃ�
        }

        transform.localScale = tempScale;
        //�v���C���[�̌�����tempScale�ɍX�V����

        x = Mathf.Abs(x);
        //�A�j���[�V������x�̔����0��1�������Ȃ��̂Ł|�ɂȂ�Ȃ��悤�ɂ��邽�߂ɐ�Βl������

        animator.SetFloat("FaceX", x);
        animator.SetFloat("FaceY", y);
    }
}
