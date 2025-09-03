using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbody; //Player�ɕt���Ă���Rigidbody�������ϐ�

    float axisH; //���������̓��͂��i�[����ϐ�
    float speed = 3.0f; //���x�ݒ�

    public float jumpPower = 9.0f; //�W�����v�͐ݒ�
    bool gojump = false; //�W�����v���邩�ǂ����̃t���O
    bool onGround = false; //�n�ʂɐڒn���Ă��邩�ǂ����̃t���O

    public LayerMask groundLayer; //�n�ʂ̃��C���[��ݒ肷�邽�߂̕ϐ�
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>(); //Player�ɂ��Ă���R���|�[�l���g�����擾
    }

    // Update is called once per frame
    void Update()
    {
        //Velocity�̌��ƂȂ�l�̎擾(�E1.0f�A��-1.0f�A�����Ȃ����0)

        axisH = Input.GetAxisRaw("Horizontal");

        //�E��������E�������A���������獶������
        if (axisH > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (axisH < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //�W�����v�̓��͂��擾
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

    }

    //��b�Ԃ�50fps�J��Ԃ��悤�ɐ��䂵�Ȃ���J��Ԃ����\�b�h
    private void FixedUpdate()
    {
        //�n�ʔ�����T�[�N���L���X�g�ōs���A���̌��ʂ�ϐ�onGround�Ɋi�[����
        onGround = Physics2D.CircleCast(
            transform.position, //���ˈʒu
            0.3f, //�T�[�N���̔��a
            new Vector2(0,1.0F), //���˕���
            groundLayer //�ΏۂƂȂ郌�C���[
            );


        //Verocity�ɑ��
        rbody.linearVelocity = new Vector2(axisH * speed, rbody.linearVelocity.y);

        if (gojump == true)
        {
            //�W�����v������
            rbody.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            gojump = false;
        }
    }

    void Jump()
    {
        gojump = true;
    }
}
