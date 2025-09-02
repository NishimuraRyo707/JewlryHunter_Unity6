using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbody; //Player�ɕt���Ă���Rigidbody�������ϐ�

    float axisH; //���������̓��͂��i�[����ϐ�
    float speed = 3.0f; //���x�ݒ�

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

        }

            //��b�Ԃ�50fps�J��Ԃ��悤�ɐ��䂵�Ȃ���J��Ԃ����\�b�h
            private void FixedUpdate()
    {
            //Verocity�ɑ��
            rbody.linearVelocity = new Vector2(axisH*speed,rbody.linearVelocity.y);
        }

    }
