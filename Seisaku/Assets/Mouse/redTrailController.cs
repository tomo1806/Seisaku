using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redTrailController : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 mousePos;
    void Start()
    {
        //マウスポインター非表示
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        mousePos.z = 10.0f;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        this.transform.position = new Vector3(mousePos.x, mousePos.y, mousePos.z);
    }
}
