using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Practice : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Toggle toggle;

    private void Awake()
    {
        toggle.onValueChanged.AddListener(OnToggleValueChangedEvent01);
    }
    public void OnToggleValueChangedEvent01(bool boolean)
    {
        player.SetActive(boolean);
        Debug.Log($"Toggle Key {boolean}");

    }

    public void OnToggleValueChangedEvent02(bool boolean)
    {

    }

    [SerializeField]
    private TextMeshProUGUI text;
    public void OnSliderEvent(float value)
    {
        text.text = $"Volume {value * 100:F1}%";
    }

    [SerializeField]
    private SpriteRenderer playerRenderer;
    [SerializeField]
    private TextMeshProUGUI textHP;
    [SerializeField]
    private Slider sliderHP;
    [SerializeField]
    private Button buttonAttack;
    private float maxHP = 100;
    private float currentHP;
    private float damage = 12;

    public void OnClickEventAttack()
    {
        if(currentHP > 0)
        {
            currentHP -= damage;
            currentHP = Mathf.Max(currentHP, 0);
            sliderHP.value = currentHP / maxHP;

        }
    }
}


