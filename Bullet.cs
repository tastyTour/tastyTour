using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour//Tour
{
	public float speed = 8f;//�ۺ����� ź���� �ӵ� ���� ����(�ۺ����� ����� ����Ƽ���� �� ���� ����)
	private Rigidbody bulletRigidbody;//��������Ʈ�� bullet�� ������ٵ� �� �Ҵ�
    // Start is called before the first frame update
    void Start()
    {
		//���� ������Ʈ���� ������ٵ� ������Ʈ�� ã�� bulletRigidbody�� �Ҵ�
        bulletRigidbody = GetComponent<Rigidbody>();

		//������ٵ��� �ӵ�(���ϴ� ��) = ���ʹ��� * �̵��ӷ�
		bulletRigidbody.velocity = transform.forward * speed;

		//3�ʵڿ� �ڽ��� ���� ������Ʈ �ı�
		Destroy(gameObject, 3f);
    }
	//Ʈ���� �浹�ÿ� �ڵ����� ������ �Ǵ� �޼���
	void OnTriggerEnter(Collider other)
	{
		//�浹�� ���� ���� ������Ʈ �̸��� Player���
		if(other.tag == "Player")
		{
			//���� ���� ������Ʈ���� PlayerController ������Ʈ�� �����´�
			PlayerController playerController = other.GetComponent<PlayerController>();
			//PlayerController ������Ʈ�� �������� �� ����������
			if(playerController != null)
			{
				//playerController.Die �޼ҵ� ����
				playerController.Die();
			}
		}
	}
    // Update is called once per frame
    void Update()
    {
        
    }
}
