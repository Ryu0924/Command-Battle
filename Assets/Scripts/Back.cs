using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour
{
    [SerializeField]
    GameObject childObject; // �q�I�u�W�F�N�g�̎Q��
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
