using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 3f;
    public float runSpeed = 6f;
    private bool isRunning = false;

    public Camera playerCamera;

    public int maxHealth = 100;
    public int currentHealth;

    public GameObject GameOverPanel;

    public PlayerHpBar hpBar;

    private Animator playerAnimator;

    AudioSource audioSource;
    public AudioSource backGroundMusic;
    public AudioSource walkingMusic;

    private void Start()
    {
        currentHealth = maxHealth;
        hpBar = FindObjectOfType<PlayerHpBar>();
        hpBar.UpdateHealthBar(currentHealth, maxHealth);

        playerAnimator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        hpBar.UpdateHealthBar(currentHealth, maxHealth);

        if (GameOverPanel.activeSelf)
        {
            backGroundMusic.Stop();
            walkingMusic.Stop();
        }

        // Shift Ű�� ������ �޸��� ���� ��ȯ
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            isRunning = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            isRunning = false;
        }

        // wasd Ű�� ����Ͽ� �̵�
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        float speed;

        if (isRunning)
        {
            playerAnimator.SetBool("Run", true);
            speed = runSpeed;
        }
        else
        {
            playerAnimator.SetBool("Run", false);
            playerAnimator.SetBool("Walk", true);
            speed = walkSpeed;
        }

        Vector3 movement = new Vector3(inputX * speed * Time.deltaTime, 0f, inputZ * speed * Time.deltaTime);
        transform.Translate(movement);
        Vector3 position = transform.position;

        bool isMoving = (Mathf.Abs(inputX) > 0.1f || Mathf.Abs(inputZ) > 0.1f);
        playerAnimator.SetBool("Walk", isMoving);

        if (isMoving)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }

        // ī�޶� ��ġ ����
        playerCamera.transform.position = transform.position + new Vector3(0f, 1.2f, 0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // �浹�� ��ü�� �������� Ȯ��
        EnemyAI monster = collision.gameObject.GetComponent<EnemyAI>();
        if (monster != null || collision.gameObject.CompareTag("Obstacle"))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            // �÷��̾� ��� ó�� ���� ����
            GameOverPanel.SetActive(true);
        }

        hpBar.UpdateHealthBar(currentHealth, maxHealth);
    }
}