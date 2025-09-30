using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // ���� �ҷ��� �� �ʿ��� ���ӽ����̽�

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;

    float jumpForce = 680.0f; //������ �������� �� �ʱⰪ
    
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

        //����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        //�¿� �̵�
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        //�ӵ�
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);  //Mathf.Abs ����

        //���ǵ� ���� �� �̵� (max 2.0f)
        if (speedx < maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * walkForce);
        }

        // �̹��� ����
        if(key !=0) // ����Ű, ������Ű�� �������� ��
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        // �÷��̾� �ӵ��� ���� �ִϸ��̼� ����
        this.animator.speed = speedx / 2.0f;

    }

    void OnTriggerEnter2D(Collider2D other)  // ��߰� ����̰� �浹�Ͽ��� ��
    {
        Debug.Log("��ߵ���");

        //���ӿ����� �Ǵ� ClearScene���� ��ȯ
        SceneManager.LoadScene("GameSence");
    }
}
