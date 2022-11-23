using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour//Tour
{
	private Rigidbody playerRigidbody;
	public float speed = 8f;//�ۺ����� �ӵ� ���� ����
    // Start is called before the first frame update
    void Start()
    {
		//���� ������Ʈ���� ������ٵ� ������Ʈ�� ã�� playerRigidbody�� �Ҵ�
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
		float xInput = Input.GetAxis("Horizontal");//���� ���� xInput
		float zInput = Input.GetAxis("Vertical");//���� ���� zInput

		float xSpeed = xInput * speed;//xSpeed�� xInput(1) X speed����
		float zSpeed = zInput * speed;//zSpeed�� zInput(1) X speed����

		//Vector3 �ӵ��� (xSpeed, 0, zSpeed)�� ����
		Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
		playerRigidbody.velocity = newVelocity;//������ٵ��� �ӵ��� Vector3 ���� newVelocity �Ҵ�
    }
	
	public void Die(){//Die�޼ҵ� ȣ��ÿ�
		gameObject.SetActive(false);//�ڽ��� ���� ������Ʈ ��Ȱ��ȭ

		GameManager gameManager = FindObjectOfType<GameManager>();
		gameManager.EndGame();
	}
}
