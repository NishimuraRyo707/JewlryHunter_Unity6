using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbody; //Playerに付いているRigidbodyを扱う変数

    float axisH: //水平方向の入力を格納する変数

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>(); //Playerについているコンポーネント情報を取得
    }

    // Update is called once per frame
    void Update()
    {  {
            //Velocityの元となる値の取得(右1.0f、左-1.0f、何もなければ0)

            axisH = Input.GetAxisRaw("Horizontal");

            //Verocityに代入
            rbody.linearVelocity = new Vector2(axisH,0);
        }

    }
}
