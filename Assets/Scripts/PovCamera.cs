using UnityEngine;

public class PovCamera : MonoBehaviour
{
    GameObject player;
    Vector3 offset;
    Vector3 onset;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        offset = transform.position - player.transform.position;
        onset = transform.rotation.eulerAngles - player.transform.rotation.eulerAngles;
    }

    void Update()
    {
        transform.position = player.transform.position + offset;
        transform.rotation = Quaternion.Euler(player.transform.rotation.eulerAngles + onset);
    }
}