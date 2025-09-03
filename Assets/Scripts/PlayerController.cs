using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbody; //Playerに付いているRigidbodyを扱う変数

    float axisH; //水平方向の入力を格納する変数
    float speed = 3.0f; //速度設定

    public float jumpPower = 9.0f; //ジャンプ力設定
    bool gojump = false; //ジャンプするかどうかのフラグ
    bool onGround = false; //地面に接地しているかどうかのフラグ

    public LayerMask groundLayer; //地面のレイヤーを設定するための変数
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>(); //Playerについているコンポーネント情報を取得
    }

    // Update is called once per frame
    void Update()
    {
        //Velocityの元となる値の取得(右1.0f、左-1.0f、何もなければ0)

        axisH = Input.GetAxisRaw("Horizontal");

        //右だったら右を向く、左だったら左を向く
        if (axisH > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (axisH < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //ジャンプの入力を取得
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

    }

    //一秒間に50fps繰り返すように制御しながら繰り返すメソッド
    private void FixedUpdate()
    {
        //地面判定をサークルキャストで行い、その結果を変数onGroundに格納する
        onGround = Physics2D.CircleCast(
            transform.position, //発射位置
            0.3f, //サークルの半径
            new Vector2(0,1.0F), //発射方向
            groundLayer //対象となるレイヤー
            );


        //Verocityに代入
        rbody.linearVelocity = new Vector2(axisH * speed, rbody.linearVelocity.y);

        if (gojump == true)
        {
            //ジャンプさせる
            rbody.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            gojump = false;
        }
    }

    void Jump()
    {
        gojump = true;
    }
}
