using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Interlocutor
{
    None,
    Character1,
    Character2
}

public class DialogDisplayer : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text descriptionText, characterText, character1Name, character2Name;
    [SerializeField] Image p1Image, p2Image;
    [SerializeField] Button continueButton;

    private Interlocutor interlocutor = (Interlocutor)(-1);

    public event System.Action ContinueClicked;

    private void Start()
    {
        SetInterlocutor(Interlocutor.None);
        SetText("");

        continueButton.onClick.AddListener(OnContinueButtonClick);
    }

    private void OnContinueButtonClick()
    {
        Debug.Log("Continue Clicked");
    }

    public void SetText(string text)
    {
        switch (interlocutor)
        {
            case Interlocutor.None:
                descriptionText.text = text;

                break;
            case Interlocutor.Character1:
            case Interlocutor.Character2:
                characterText.text = text;
                break;
        }
    }

    public void SetName(string name)
    {
        switch (interlocutor)
        {
            case Interlocutor.Character1:
                character1Name.text = name;
                break;

            case Interlocutor.Character2:
                character2Name.text = name;
                break;
        }
    }

    public void SetInterlocutor(Interlocutor i)
    {
        if (interlocutor == i)
            return;

        interlocutor = i;

        switch (i)
        {
            case Interlocutor.None:
                character1Name.enabled = false;
                character2Name.enabled = false;
                p1Image.enabled = false;
                p2Image.enabled = false;
                characterText.enabled = false;
                descriptionText.enabled = true;
                break;

            case Interlocutor.Character1:
                character1Name.enabled = true;
                character2Name.enabled = false;
                p1Image.enabled = true;
                p2Image.enabled = false;
                characterText.enabled = true;
                descriptionText.enabled = false;
                break;

            case Interlocutor.Character2:
                character1Name.enabled = false;
                character2Name.enabled = true;
                p1Image.enabled = false;
                p2Image.enabled = true;
                characterText.enabled = true;
                descriptionText.enabled = false;
                break;
        }
    }
}
