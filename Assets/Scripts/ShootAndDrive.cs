using UnityEngine;

public class ShootAndDrive : MonoBehaviour
{
    public AudioClip shootSound;
    public AudioClip motorSound;
    public GameObject BloomEffect;
    private AudioSource audioSource;

    private float bloomEffectStartTime = -1f;
    private float bloomEffectDuration = 0.5f;

    void Start()
    {
        BloomEffect.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            BloomEffect.SetActive(true);
            audioSource.PlayOneShot(shootSound);
            bloomEffectStartTime = Time.time;
        }

        // ตรวจสอบเวลาครบ 4 วินาทีหรือยัง
        if (BloomEffect.activeSelf && bloomEffectStartTime > 0f)
        {
            if (Time.time - bloomEffectStartTime >= bloomEffectDuration)
            {
                BloomEffect.SetActive(false);
                bloomEffectStartTime = -1f;
            }
        }

        if (Input.GetKeyDown(KeyCode.W) ||
            Input.GetKeyDown(KeyCode.A) ||
            Input.GetKeyDown(KeyCode.S) ||
            Input.GetKeyDown(KeyCode.D))
        {
            if (audioSource.clip != motorSound || !audioSource.isPlaying)
            {
                audioSource.clip = motorSound;
                audioSource.loop = true;
                audioSource.Play();
            }
        }

        if (Input.GetKeyUp(KeyCode.W) ||
            Input.GetKeyUp(KeyCode.A) ||
            Input.GetKeyUp(KeyCode.S) ||
            Input.GetKeyUp(KeyCode.D))
        {
            audioSource.Stop();
            audioSource.clip = null;
        }
    }
}