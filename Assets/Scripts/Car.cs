using UnityEngine;

public class Car : MonoBehaviour
{
    public float speed = 25f;
    public float turnSpeed = 45f;
    private float horizontalInput;
    private float forwardInput;
    public GameObject mainCamera, PovCamera;

    void Start()
    {
        mainCamera.SetActive(true);
        PovCamera.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * speed * Time.deltaTime * forwardInput);
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);

        ChangeCamera();
    }

    private void ChangeCamera()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (mainCamera.activeSelf)
            {
                mainCamera.SetActive(false);
                PovCamera.SetActive(true);
            }
            else
            {
                mainCamera.SetActive(true);
                PovCamera.SetActive(false);
            }
        }
    }
}
