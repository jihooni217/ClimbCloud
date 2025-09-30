using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 씬을 불러올 때 필요한 네임스페이스

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;

    float jumpForce = 680.0f; //점프에 가해지는 힘 초기값
    
    float walkForce = 30.0f;
    float maxWalkSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        //Rigid2D
        this.rigid2D = GetComponent<Rigidbody2D>();

        // Animator
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //점프
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        //좌우 이동
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        //속도
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);  //Mathf.Abs 절댓값

        //스피드 제한 및 이동 (max 2.0f)
        if (speedx < maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * walkForce);
        }

        // 이미지 반전
        if(key !=0) // 왼쪽키, 오른쪽키가 눌려졌을 때
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        // 플레이어 속도에 따른 애니메이션 제어
        this.animator.speed = speedx / 2.0f;

    }

    void OnTriggerEnter2D(Collider2D other)  // 깃발과 고양이가 충돌하였을 때
    {
        Debug.Log("깃발도착");

        //게임오버가 되는 ClearScene으로 전환
        SceneManager.LoadScene("GameSence");
    }
}
