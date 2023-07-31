using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{
    [SerializeField]
    Text _playerNameText, _hitPointText, _magicPointText;

    [SerializeField]
    public string _playerNeme;
    [SerializeField]
    public int _playerHitPoint = 100;
    [SerializeField]
    public int _magicPoint = 50;
    [SerializeField]
    public int _skillReboundCounts = 0;
    [SerializeField]
    public int _herbCount = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _playerNameText.text = _playerNeme;
        if(_playerHitPoint > 0)
        {
            _hitPointText.text = "HP:" + _playerHitPoint.ToString();
        }
        else
        {
            _hitPointText.text = "HP:0";
        }
        _magicPointText.text = "MP:" + _magicPoint.ToString();
    }
}
