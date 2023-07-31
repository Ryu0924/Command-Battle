using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Command : MonoBehaviour
{
    [SerializeField]
    Button _attackButton, _magicButton, _itemButton, _reflectionButton, _herbButton, _itemUseButton;
    [SerializeField]
    GameObject _commandPanel, _magicPanel, _itemPanel, _windowPanel, _usePanel;
    [SerializeField]
    Text _windowText, _useText;
    int _number;
    int _hill;
    int _playerDamage;
    int _enemyDamage;
    // Start is called before the first frame update
    void Start()
    {
        _attackButton.onClick.AddListener(Attack);
        _magicButton.onClick.AddListener(Magic);
        _itemButton.onClick.AddListener(Item);
        _reflectionButton.onClick.AddListener(Reflection);
        _herbButton.onClick.AddListener(UseItem);
        _itemUseButton.onClick.AddListener(UseHerb);
    }

    void Attack()
    {
        _commandPanel.SetActive(false);
        _windowPanel.SetActive(true);
        _playerDamage = Random.Range(20, 35);
        _windowText.text = "�G��" + _playerDamage +"�̃_���[�W";
        Invoke("EnemyCommand", 2.0f); 
    }

    void Magic()
    {
        if(_itemPanel != null)
        {
            _itemPanel.SetActive(false);
        }
        _magicPanel.SetActive(true);
    }

    void Item()
    {
        if(_magicPanel != null)
        {
            _magicPanel.SetActive(false);
        }
        _itemPanel.SetActive(true);
    }

    void Reflection()
    {
        Status statusComponent = GetComponent<Status>();
        statusComponent._magicPoint -= 10;
        _commandPanel.SetActive(false);
        _windowPanel.SetActive(true);
        _windowText.text = "�E�҂̓��t���N�V�����𔭓������B";
        _number = Random.Range(1, 100);
        if (_number <= 20)//���s
        {
            Invoke("FailureMagic", 2.0f);
        }
        else//����
        {
            Invoke("SuccessMagic", 2.0f);
        }
    }

    void UseItem()
    {
        Status statusComponent = GetComponent<Status>();
        _usePanel.SetActive(true);
        _useText.text = "�򑐂��g���܂����H" + "�c��" +�@statusComponent._herbCount + "��";
    }

    void UseHerb()
    {
        Status statusComponent = GetComponent<Status>();
        _commandPanel.SetActive(false);
        _itemPanel.SetActive(false);
        _usePanel.SetActive(false);
        _windowPanel.SetActive(true);
        if(statusComponent._playerHitPoint < 100)
        {
            _hill = 100 - statusComponent._playerHitPoint;
            if(_hill <= 30)
            {
                statusComponent._playerHitPoint += _hill;
            }
            else
            {
                _hill = 30;
                statusComponent._playerHitPoint += _hill;
            }
            _windowText.text = "�E�҂�HP��" + _hill + "�񕜂����B";
            statusComponent._herbCount--;
        }
        else
        {
            _windowText.text = "�������A�����N����Ȃ������B";
        }
        Invoke("EnemyCommand", 2.0f);
    }

    void EnemyCommand()
    {
        Status statusComponent = GetComponent<Status>();
        _enemyDamage = Random.Range(15,30);
        if (statusComponent._skillReboundCounts > 0)
        {
            statusComponent._skillReboundCounts--;
            _windowText.text = "���@�̕ǂ��U���𒵂˕Ԃ����B";
            Invoke("Nextturn", 2.0f);
        }
        else
        {
            _windowText.text = "�E�҂�" + _enemyDamage + "�̃_���[�W���������";
            statusComponent._playerHitPoint -= _enemyDamage;
            if (statusComponent._playerHitPoint > 0)
            {
                Invoke("Nextturn", 2.0f);
            }
            else
            {
                Invoke("GameOver", 2.0f);
            }
        }
    }

    void SuccessMagic()//���@����
    {
        _windowText.text = "�E�҂̑O�ɖ��@�̕ǂ����ꂽ�B";
        Status statusComponent = GetComponent<Status>();
        statusComponent._skillReboundCounts = 3;
        Invoke("EnemyCommand", 2.0f);
    }

    void FailureMagic()//���@���s
    {
        _windowText.text = "�������A�����N����Ȃ������B";
        Invoke("EnemyCommand", 2.0f);
    }

    void Nextturn()
    {
        _commandPanel.SetActive(true);
        _windowPanel.SetActive(false);
    }

    void GameOver()
    {
        _windowText.text = "�E�҂͎���ł��܂����B";
    }
}
