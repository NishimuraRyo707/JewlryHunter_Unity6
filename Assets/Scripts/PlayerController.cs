using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbody; //Player�ɕt���Ă���Rigidbody�������ϐ�

    float axisH: //���������̓��͂��i�[����ϐ�

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>(); //Player�ɂ��Ă���R���|�[�l���g�����擾
    }

    // Update is called once per frame
    void Update()
    {  {
            //Velocity�̌��ƂȂ�l�̎擾(�E1.0f�A��-1.0f�A�����Ȃ����0)

            axisH = Input.GetAxisRaw("Horizontal");

            //Verocity�ɑ��
            rbody.linearVelocity = new Vector2(axisH,0);
        }

    }
}
