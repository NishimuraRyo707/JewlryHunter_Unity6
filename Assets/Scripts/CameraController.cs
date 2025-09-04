using Unity.Hierarchy;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject Player; //Player�I�u�W�F�N�g�����邽�߂̕ϐ�
    float x, y, z; //�J������x�Ay�Az���W�����߂邽�߂̕ϐ�

    [Header("�J�����̌��E�l")]
    public float leftLimit;
public float rightLimit;
    public float topLimit;
    public float bottomLimit;

    [Header("�J�����̃X�N���[���ݒ�")]
    public bool isScrollX;
    public float scrollSpeedX = 0.5f;
    public bool isScrollY;
    public float scrollSpeedY = 0.5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Player�I�u�W�F�N�g��p�ӂ���B
        Player = GameObject.FindGameObjectWithTag("Player");

        //�J������z�l�͌Œ肷��B
        z = transform.position.z;

    }

    // Update is called once per frame
    void Update()
    {
        //��������v���C���[��x�Ay���W��ϐ��Ɏ擾����B
        x = Player.transform.position.x; //Player��x���W���擾
        y = Player.transform.position.y; //Player��y���W���擾

        if (isScrollX)
        {
            x = transform.position.x + (scrollSpeedX * Time.deltaTime);
        }

        if (x < leftLimit)
        {
            x = leftLimit;
        }
        else if (x > rightLimit)
        {
            x = rightLimit;

            if (isScrollY)
            {
                y = transform.position.y + (scrollSpeedY * Time.deltaTime);
            }
        }

        if (y < bottomLimit)
        {
            y = bottomLimit;
        }
        else if (y > topLimit)
        {
            y = topLimit;
        }





        //��茈�߂��ex�Ay�Az�̒l���J�����̃|�W�V�����Ƃ���B
        transform.position = new Vector3(x, y, z);
    }
}
