using OpenAI_API;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SimpleCharacter : MonoBehaviour
{
    public GameObject item;
    public Scrollbar verticalScrollbar;
    public ScrollRect scrollRect;
    public TMP_Text chatText;
    public TextBubble ResponseTextPrefab;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void Think (string text)
    {
        //string chat = chatText.text;
        //chat = chat + "/n"+text;
        chatText.text = text;
        anim.SetTrigger("Think");
    }

    public void Talk(List<Choice> choices)
    {
        string chat = chatText.text;
        chatText.text = "";
        Debug.Log("////////////////////// :  "+chat);
        chat = chat + "/n" + choices[0].ToString();
        Debug.Log("////////////////////// :  " + chat);
        chatText.text = chat;
       
        //chatText.text = choices[0].ToString();
        //Instantiate(ResponseTextPrefab).Init(this.gameObject, choices[0].Text);
        anim.SetTrigger("Talk");
        if (Mathf.Approximately(verticalScrollbar.value, 0f))
        {
            StartCoroutine("ScrollToBottom");
        }
    }

    public void Talk(string text)
    {
        string chat = chatText.text;
        chat = chat + "/n" + text;
        chatText.text = chat;

        chatText.text = text;
        //Instantiate(ResponseTextPrefab).Init(this.gameObject, choices[0].Text);
        anim.SetTrigger("Talk");
    }

    IEnumerator ScrollToBottom()
    {
        yield return new WaitForEndOfFrame();
        Canvas.ForceUpdateCanvases();

        item.GetComponent<VerticalLayoutGroup>().CalculateLayoutInputVertical();
        item.GetComponent<ContentSizeFitter>().SetLayoutVertical();

        scrollRect.content.GetComponent<VerticalLayoutGroup>().CalculateLayoutInputVertical();
        scrollRect.content.GetComponent<ContentSizeFitter>().SetLayoutVertical();

        scrollRect.verticalNormalizedPosition = 0;
    }
}
