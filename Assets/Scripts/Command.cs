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
        _windowText.text = "敵に" + _playerDamage +"のダメージ";
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
        _windowText.text = "勇者はリフレクションを発動した。";
        _number = Random.Range(1, 100);
        if (_number <= 20)//失敗
        {
            Invoke("FailureMagic", 2.0f);
        }
        else//成功
        {
            Invoke("SuccessMagic", 2.0f);
        }
    }

    void UseItem()
    {
        Status statusComponent = GetComponent<Status>();
        _usePanel.SetActive(true);
        _useText.text = "薬草を使いますか？" + "残り" +　statusComponent._herbCount + "個";
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
            _windowText.text = "勇者のHPが" + _hill + "回復した。";
            statusComponent._herbCount--;
        }
        else
        {
            _windowText.text = "しかし、何も起こらなかった。";
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
            _windowText.text = "魔法の壁が攻撃を跳ね返した。";
            Invoke("Nextturn", 2.0f);
        }
        else
        {
            _windowText.text = "勇者は" + _enemyDamage + "のダメージをくらった";
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

    void SuccessMagic()//魔法成功
    {
        _windowText.text = "勇者の前に魔法の壁が現れた。";
        Status statusComponent = GetComponent<Status>();
        statusComponent._skillReboundCounts = 3;
        Invoke("EnemyCommand", 2.0f);
    }

    void FailureMagic()//魔法失敗
    {
        _windowText.text = "しかし、何も起こらなかった。";
        Invoke("EnemyCommand", 2.0f);
    }

    void Nextturn()
    {
        _commandPanel.SetActive(true);
        _windowPanel.SetActive(false);
    }

    void GameOver()
    {
        _windowText.text = "勇者は死んでしまった。";
    }
}
