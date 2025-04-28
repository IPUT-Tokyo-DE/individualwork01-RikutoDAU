using TMPro.Examples;
using UnityEngine;

public class PlayerArea : MonoBehaviour
{

    private Camera camera;

    private Vector2 screenArea;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera = Camera.main;

        screenArea = camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, camera.transform.position.z));

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, -screenArea.x, screenArea.x);
        pos.y = Mathf.Clamp(pos.y, -screenArea.y + 12, screenArea.y);

        transform.position = pos;  
    }
}
