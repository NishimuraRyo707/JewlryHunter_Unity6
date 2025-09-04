using Unity.Hierarchy;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject Player; //Playerオブジェクトを入れるための変数
    float x, y, z; //カメラのx、y、z座標を決めるための変数

    [Header("カメラの限界値")]
    public float leftLimit;
public float rightLimit;
    public float topLimit;
    public float bottomLimit;

    [Header("カメラのスクロール設定")]
    public bool isScrollX;
    public float scrollSpeedX = 0.5f;
    public bool isScrollY;
    public float scrollSpeedY = 0.5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Playerオブジェクトを用意する。
        Player = GameObject.FindGameObjectWithTag("Player");

        //カメラのz値は固定する。
        z = transform.position.z;

    }

    // Update is called once per frame
    void Update()
    {
        //いったんプレイヤーのx、y座標を変数に取得する。
        x = Player.transform.position.x; //Playerのx座標を取得
        y = Player.transform.position.y; //Playerのy座標を取得

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





        //取り決めた各x、y、zの値をカメラのポジションとする。
        transform.position = new Vector3(x, y, z);
    }
}
