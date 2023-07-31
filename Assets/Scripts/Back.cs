using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour
{
    [SerializeField]
    GameObject childObject; // 子オブジェクトの参照
    // Start is called before the first frame update
    void Start()
    {

    }

    public void CommandBack()
    {
        GameObject parentObject = childObject.transform.parent.gameObject;
        parentObject.SetActive(false);
    }
}
