using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UiItemInfo : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemDesciption;
    public TextMeshProUGUI itemType;
    public TextMeshProUGUI itemValue;
    public TextMeshProUGUI itemCost;

    private void OnEnable()
    {
        SetEmpty();
    }

    public void SetEmpty()
    {
        icon.sprite = null;
        itemName.text = string.Empty;
        itemDesciption.text = string.Empty;
        itemType.text = string.Empty;
        itemValue.text = string.Empty;
        itemCost.text = string.Empty;
    }

    public void SetItem(SaveItemData data)
    {
        icon.sprite = data.itemData.SpriteIcon;
        itemName.text = data.itemData.StringName;
        itemDesciption.text = data.itemData.StringDesc;
        itemType.text = data.itemData.Type.ToString();
        itemCost.text = data.itemData.Cost.ToString();
    }
}
