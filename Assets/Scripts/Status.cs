using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{
    [SerializeField]
    Text _playerNameText, _hitPointText, _magicPointText;

    [SerializeField]
    string _playerNeme;
    [SerializeField]
    int _playerHitPoint = 100;
    [SerializeField]
    int _magicPoint = 50;
    [SerializeField]
    int _skillReboundCounts = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _playerNameText.text = _playerNeme;
        _hitPointText.text = "HP:" + _playerHitPoint.ToString();
        _magicPointText.text = "MP:" + _magicPoint.ToString();
    }
}
