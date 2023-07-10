using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Command : MonoBehaviour
{
    [SerializeField]
    Button _attackButton, _magicButton, _itemButton, _backButton;
    [SerializeField]
    GameObject _commandPanel, _itemPanel, _windowPanel;
    [SerializeField]
    Text _windowText;
    // Start is called before the first frame update
    void Start()
    {
        _attackButton.onClick.AddListener(Attack);
        _magicButton.onClick.AddListener(Magic);
        _itemButton.onClick.AddListener(Item);
        _backButton.onClick.AddListener(Back);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void Attack()
    {
        _commandPanel.SetActive(false);
        _windowPanel.SetActive(true);
        _windowText.text = "ìGÇ…" + "20ÇÃÉ_ÉÅÅ[ÉW";
    }

    void Magic()
    {
        _commandPanel.SetActive(false);
    }

    void Item()
    {
        _itemPanel.SetActive(true);
    }

    void Back()
    {
        _itemPanel.SetActive(false);
    }
}
