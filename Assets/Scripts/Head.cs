using System.Collections;
using UnityEngine;

public class Head : MonoBehaviour
{
    [Header("Player Speed")]
    [SerializeField] private float speed = 2.5f;
    [SerializeField] private float rotationSpeed  = 250f;

    [Header("Power-Ups")]
    [SerializeField] private float timePill = 5;
    [SerializeField] private float timeShield = 5;
    [SerializeField] private float timeStar = 10;

    [SerializeField] private string inputAxis = "Horizontal";
    float horizontal = 0f;

    SpriteRenderer spriteRenderer;
    AudioSource audioSource;

    [HideInInspector] public bool isDead = false;
    private bool invulnerable = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw(inputAxis);
    }


    private void FixedUpdate()
    {
        transform.Translate(Vector2.up * speed * Time.fixedDeltaTime, Space.Self);
        transform.Rotate(Vector3.forward * -horizontal * rotationSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Tod")
        {
            Destroy(gameObject);
            isDead = true;
        }

        if (collision.tag == "Pill")
        {
            StartCoroutine(Pill(timePill));
        }

        if (collision.tag == "Shield")
        {
            StartCoroutine(Shield(timeShield));
        }

        if (collision.tag == "Star")
        {
            StartCoroutine(Star(timeStar));
        }

        if (collision.tag == "Ignoreable")
        {
            if (invulnerable == false)
            {
                Destroy(gameObject);
                isDead = true;
            }
        }
    }


    private IEnumerator Pill(float timePill)
    {
        speed = 1.25f;
        spriteRenderer.color = Color.magenta;

        yield return new WaitForSeconds(timePill);

        spriteRenderer.color = Color.white;
        speed = 2.5f;
    }

    private IEnumerator Shield(float timeShield)
    {  
        invulnerable = true;
        spriteRenderer.color = Color.yellow;

        yield return new WaitForSeconds(timeShield);

        spriteRenderer.color = Color.white;
        invulnerable = false;
    }

    private IEnumerator Star(float timeStar)
    {
        speed = 5f;
        invulnerable = true;
        spriteRenderer.color = Color.yellow;
        audioSource.Play();

        yield return new WaitForSeconds(timeStar);

        audioSource.Pause();
        spriteRenderer.color = Color.white;
        invulnerable = false;
        speed = 2.5f;
    }
}
