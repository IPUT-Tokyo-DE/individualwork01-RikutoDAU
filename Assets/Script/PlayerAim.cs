//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerAim : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = -1f;

        this.transform.position = mousePos;

        //Debug.Log(mousePos);

        //Vector3 mousePosition = Input.mousePosition;

        //this.transform.position(mousePosition);


    }
}
