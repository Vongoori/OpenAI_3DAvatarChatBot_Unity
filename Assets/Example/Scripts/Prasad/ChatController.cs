using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OpenAI_Unity;
using TMPro;

public class ChatController : MonoBehaviour
{
    public OAICharacter _oaiCharacter;
    public TMP_InputField questionInput;
    // Start is called before the first frame update
    void Start()
    {
        questionInput.onEndEdit.AddListener((string data) =>
        {
            if (!string.IsNullOrEmpty(data))
            {

                _oaiCharacter.AddToStory(data);
            }
            questionInput.text = "";
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            questionInput.Select();
            questionInput.ActivateInputField();
        }
    }
}
