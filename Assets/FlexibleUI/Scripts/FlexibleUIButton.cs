using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Button))]
public class FlexibleUIButton : FlexibleUI
{

    public enum ButtonType
    {
        Default,
        Confirm,
        Decline,
        Warning,
        Text
    }

    Button button;
    Image image;
    Image icon;

    public Text text;

    public ButtonType buttonType;

    protected override void OnSkinUI()
    {

        base.OnSkinUI();
        image = GetComponent<Image>();
        icon = transform.Find("Icon").GetComponent<Image>();
        button = GetComponent<Button>();

        button.transition = Selectable.Transition.SpriteSwap;
        button.targetGraphic = image;

        image.sprite = skinData.buttonSprite;
        image.type = Image.Type.Sliced;
        button.spriteState = skinData.buttonSpriteState;

        if (text != null)
        {
            text.text = skinData.text;
        }

        switch (buttonType)
        {
            case ButtonType.Default:
                image.color = skinData.defaultColor;
                icon.sprite = skinData.defaultIcon;
                text.gameObject.SetActive(false);
                icon.gameObject.SetActive(true);
                break;
            case ButtonType.Confirm:
                image.color = skinData.confirmColor;
                icon.sprite = skinData.confirmIcon;
                text.gameObject.SetActive(false);
                icon.gameObject.SetActive(true);
                break;
            case ButtonType.Decline:
                image.color = skinData.declineColor;
                icon.sprite = skinData.declineIcon;
                text.gameObject.SetActive(false);
                icon.gameObject.SetActive(true);
                break;
            case ButtonType.Warning:
                image.color = skinData.warningColor;
                icon.sprite = skinData.warningIcon;
                text.gameObject.SetActive(false);
                icon.gameObject.SetActive(true);
                break;
            case ButtonType.Text:
                text.gameObject.SetActive(true);
                icon.gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }
}