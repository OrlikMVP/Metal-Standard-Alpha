using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmolFanction : MonoBehaviour
{
    public GameObject Debuglog, CardGold, CreditGold, DepGold, CeshGold, MoreGold;
    public GameObject CardGoldTXT, CreditGoldTXT, DepGoldTXT, CeshGoldTXT, MoreGoldTXT;

    public GameObject CardSilver, CreditSilver, DepSilver, CeshSilver, MoreSilver;
    public GameObject CardSilverTXT, CreditSilverTXT, DepSilverTXT, CeshSilverTXT, MoreSilverTXT;

    
    public GameObject dotslide1, dotslide2, dotslide3, dotslide4;
    public GameObject Card, PanCard, PanHist;
    public GameObject SilverBg, GoldBg;
    public GameObject SilverDown, GoldDown;
    public GameObject SilverSum, GoldSum;
    public GameObject Get, Drag, Other, Getbg, Dragbg, Otherbg;
    public GameObject GetSilver, DragSilver, OtherSilver, GetbgSilver, DragbgSilver, OtherbgSilver;
    public GameObject SilverCard, SilverPanCard, SilverPanHist;
    public GameObject WhatIsGoldgram, WhatIsOldHryvna;
    public GameObject GetMoneyGold, GetMoneySilver;
    public GameObject DragMoneyGold, DragMoneySilver;

    public GameObject ScrolFild;
    float u; bool swap = false; public Scrollbar Scrol,ScrolHistGold, ScrolHistSilver;
    private void Start()
    {
        ScrolHistGold.GetComponent<Scrollbar>().value = 1;
        ScrolHistSilver.GetComponent<Scrollbar>().value = 1;
    }
    public void CardBTN()
    {
        CardGold.GetComponent<Image>().color = new Color(0 / 255.0f, 25 / 255.0f, 87 / 255.0f);
        CreditGold.GetComponent<Image>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        DepGold.GetComponent<Image>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        CeshGold.GetComponent<Image>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        MoreGold.GetComponent<Image>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);

        CardGoldTXT.GetComponent<Text>().color = new Color(0 / 255.0f, 25 / 255.0f, 87 / 255.0f);
        CreditGoldTXT.GetComponent<Text>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        DepGoldTXT.GetComponent<Text>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        CeshGoldTXT.GetComponent<Text>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        MoreGoldTXT.GetComponent<Text>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
    }
    public void CreditBTN()
    {
        CardGold.GetComponent<Image>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        CreditGold.GetComponent<Image>().color = new Color(0 / 255.0f, 25 / 255.0f, 87 / 255.0f);
        DepGold.GetComponent<Image>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        CeshGold.GetComponent<Image>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        MoreGold.GetComponent<Image>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);

        CardGoldTXT.GetComponent<Text>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        CreditGoldTXT.GetComponent<Text>().color = new Color(0 / 255.0f, 25 / 255.0f, 87 / 255.0f);
        DepGoldTXT.GetComponent<Text>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        CeshGoldTXT.GetComponent<Text>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        MoreGoldTXT.GetComponent<Text>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
    }
    public void DepBTN()
    {
        CardGold.GetComponent<Image>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        CreditGold.GetComponent<Image>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        DepGold.GetComponent<Image>().color = new Color(0 / 255.0f, 25 / 255.0f, 87 / 255.0f);
        CeshGold.GetComponent<Image>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        MoreGold.GetComponent<Image>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);

        CardGoldTXT.GetComponent<Text>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        CreditGoldTXT.GetComponent<Text>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        DepGoldTXT.GetComponent<Text>().color = new Color(0 / 255.0f, 25 / 255.0f, 87 / 255.0f);
        CeshGoldTXT.GetComponent<Text>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        MoreGoldTXT.GetComponent<Text>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
    }
    public void CeshBTN()
    {
        CardGold.GetComponent<Image>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        CreditGold.GetComponent<Image>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        DepGold.GetComponent<Image>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        CeshGold.GetComponent<Image>().color = new Color(0 / 255.0f, 25 / 255.0f, 87 / 255.0f);
        MoreGold.GetComponent<Image>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);

        CardGoldTXT.GetComponent<Text>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        CreditGoldTXT.GetComponent<Text>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        DepGoldTXT.GetComponent<Text>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        CeshGoldTXT.GetComponent<Text>().color = new Color(0 / 255.0f, 25 / 255.0f, 87 / 255.0f);
        MoreGoldTXT.GetComponent<Text>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
    }
    public void MoreBTN()
    {
        CardGold.GetComponent<Image>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        CreditGold.GetComponent<Image>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        DepGold.GetComponent<Image>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        CeshGold.GetComponent<Image>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        MoreGold.GetComponent<Image>().color = new Color(0 / 255.0f, 25 / 255.0f, 87 / 255.0f);

        CardGoldTXT.GetComponent<Text>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        CreditGoldTXT.GetComponent<Text>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        DepGoldTXT.GetComponent<Text>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        CeshGoldTXT.GetComponent<Text>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        MoreGoldTXT.GetComponent<Text>().color = new Color(0 / 255.0f, 25 / 255.0f, 87 / 255.0f);
    }

    public void CardBTNSilver()
    {
        CardSilver.GetComponent<Image>().color = new Color(80 / 255.0f, 43 / 255.0f, 80 / 255.0f);
        CreditSilver.GetComponent<Image>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        DepSilver.GetComponent<Image>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        CeshSilver.GetComponent<Image>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        MoreSilver.GetComponent<Image>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);

        CardSilverTXT.GetComponent<Text>().color = new Color(80 / 255.0f, 43 / 255.0f, 80/ 255.0f);
        CreditSilverTXT.GetComponent<Text>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        DepSilverTXT.GetComponent<Text>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        CeshSilverTXT.GetComponent<Text>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        MoreSilverTXT.GetComponent<Text>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
    }
    public void CreditBTNSilver()
    {
        CardSilver.GetComponent<Image>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        CreditSilver.GetComponent<Image>().color = new Color(80 / 255.0f, 43 / 255.0f, 80 / 255.0f);
        DepSilver.GetComponent<Image>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        CeshSilver.GetComponent<Image>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        MoreSilver.GetComponent<Image>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);

        CardSilverTXT.GetComponent<Text>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        CreditSilverTXT.GetComponent<Text>().color = new Color(80 / 255.0f, 43 / 255.0f, 80 / 255.0f);
        DepSilverTXT.GetComponent<Text>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        CeshSilverTXT.GetComponent<Text>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        MoreSilverTXT.GetComponent<Text>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
    }
    public void DepBTNSilver()
    {
        CardSilver.GetComponent<Image>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        CreditSilver.GetComponent<Image>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        DepSilver.GetComponent<Image>().color = new Color(80 / 255.0f, 43 / 255.0f, 80 / 255.0f);
        CeshSilver.GetComponent<Image>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        MoreSilver.GetComponent<Image>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);

        CardSilverTXT.GetComponent<Text>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        CreditSilverTXT.GetComponent<Text>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        DepSilverTXT.GetComponent<Text>().color = new Color(80 / 255.0f, 43 / 255.0f, 80 / 255.0f);
        CeshSilverTXT.GetComponent<Text>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        MoreSilverTXT.GetComponent<Text>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
    }
    public void CeshBTNSilver()
    {
        CardSilver.GetComponent<Image>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        CreditSilver.GetComponent<Image>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        DepSilver.GetComponent<Image>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        CeshSilver.GetComponent<Image>().color = new Color(80 / 255.0f, 43 / 255.0f, 80 / 255.0f);
        MoreSilver.GetComponent<Image>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);

        CardSilverTXT.GetComponent<Text>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        CreditSilverTXT.GetComponent<Text>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        DepSilverTXT.GetComponent<Text>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        CeshSilverTXT.GetComponent<Text>().color = new Color(80 / 255.0f, 43 / 255.0f, 80 / 255.0f);
        MoreSilverTXT.GetComponent<Text>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
    }
    public void MoreBTNSilver()
    {
        CardSilver.GetComponent<Image>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        CreditSilver.GetComponent<Image>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        DepSilver.GetComponent<Image>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        CeshSilver.GetComponent<Image>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        MoreSilver.GetComponent<Image>().color = new Color(80 / 255.0f, 43 / 255.0f, 80 / 255.0f);

        CardSilverTXT.GetComponent<Text>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        CreditSilverTXT.GetComponent<Text>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        DepSilverTXT.GetComponent<Text>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        CeshSilverTXT.GetComponent<Text>().color = new Color(80 / 255.0f, 80 / 255.0f, 80 / 255.0f);
        MoreSilverTXT.GetComponent<Text>().color = new Color(80 / 255.0f, 43 / 255.0f, 80 / 255.0f);
    }

    public InputField InputField;
    public GameObject pan;
    // Start is called before the first frame update
    public void InputFunk(string input)
    {

        if (input.Length == 1)
        {
            InputField.text = input + "  ";
            InputField.caretPosition = 4;
        }
        if (input.Length == 4)
        {
            InputField.text = input + "  ";
            InputField.caretPosition = 7;
        }
        if (input.Length == 7)
        {
            InputField.text = input + "  ";
            InputField.caretPosition = 9;
        }
        if (input.Length == 10)
        {
            pan.SetActive(false);
        }


    }
    float smoothTime = 0.05f;
    float fVelocity = 0.05f, sw3, sw2, sw1, sw4;
    void Update()
    {
        
        if (Input.touchCount==0  && swap == true)
        {
            if (u < 0.16665f)
            {
                u = Mathf.SmoothDamp(u, 0f, ref fVelocity, smoothTime);
                Scrol.GetComponent<Scrollbar>().value = u;
                if (u == 0f) swap = false;
            }
            if (u >= 0.16665f && u < 0.49995f)
            {
                u = Mathf.SmoothDamp(u, 0.3333f, ref fVelocity, smoothTime);
                Scrol.GetComponent<Scrollbar>().value = u;
                if (u == 0.3333f) swap = false;
            }
            if (u >= 0.49995f && u < 0.83325f)
            {
                u = Mathf.SmoothDamp(u, 0.6666f, ref fVelocity, smoothTime);
                Scrol.GetComponent<Scrollbar>().value = u;
                if (u == 0.6666f) swap = false;
            }
            if (u >= 0.83325f)
            {
                u = Mathf.SmoothDamp(u, 1f, ref fVelocity, smoothTime);
                Scrol.GetComponent<Scrollbar>().value = u;
                if (u == 1f) swap = false;
            }


        }
       
    }
    public void Swipe(float i)
    {
        
        sw3 = (i - 0.6666f) * 3;
        //ToLog(i + " "+ sw3);

        Card.GetComponent<RectTransform>().anchoredPosition = new Vector3(transform.position.x + 769 - (sw3 * 769), Card.GetComponent<RectTransform>().anchoredPosition.y);
        PanCard.GetComponent<RectTransform>().anchoredPosition = new Vector3(transform.position.x + 1079f - ((sw3 - 0.005f) * 1083), PanCard.GetComponent<RectTransform>().anchoredPosition.y);
        PanHist.GetComponent<RectTransform>().anchoredPosition = new Vector3(transform.position.x + 0 - (sw3 * 1083), PanHist.GetComponent<RectTransform>().anchoredPosition.y);

        Get.GetComponent<RectTransform>().anchoredPosition = new Vector3(transform.position.x - 361 - (sw3 * 1190), Get.GetComponent<RectTransform>().anchoredPosition.y);
        Drag.GetComponent<RectTransform>().anchoredPosition = new Vector3(transform.position.x - 2 - (sw3 * 1190), Drag.GetComponent<RectTransform>().anchoredPosition.y);
        Other.GetComponent<RectTransform>().anchoredPosition = new Vector3(transform.position.x + 359 - (sw3 * 1190), Other.GetComponent<RectTransform>().anchoredPosition.y);
        Getbg.GetComponent<RectTransform>().anchoredPosition = new Vector3(transform.position.x - 361 - (sw3 * 1190), Getbg.GetComponent<RectTransform>().anchoredPosition.y);
        Dragbg.GetComponent<RectTransform>().anchoredPosition = new Vector3(transform.position.x - 2 - (sw3 * 1190), Dragbg.GetComponent<RectTransform>().anchoredPosition.y);
        Otherbg.GetComponent<RectTransform>().anchoredPosition = new Vector3(transform.position.x + 359 - (sw3 * 1190), Otherbg.GetComponent<RectTransform>().anchoredPosition.y);

        SilverPanCard.GetComponent<RectTransform>().anchoredPosition = new Vector3(transform.position.x - 2165 - (sw3 * 1083), SilverPanCard.GetComponent<RectTransform>().anchoredPosition.y);
        SilverPanHist.GetComponent<RectTransform>().anchoredPosition = new Vector3(transform.position.x - 1083 - (sw3 * 1083), SilverPanHist.GetComponent<RectTransform>().anchoredPosition.y);


        SilverSum.GetComponent<RectTransform>().anchoredPosition = new Vector3(transform.position.x - 910.2008f - (sw3 * 1190), SilverSum.GetComponent<RectTransform>().anchoredPosition.y);
        GoldSum.GetComponent<RectTransform>().anchoredPosition = new Vector3(transform.position.x - 0.104999f - (sw3 * 1190), GoldSum.GetComponent<RectTransform>().anchoredPosition.y);

        GetSilver.GetComponent<RectTransform>().anchoredPosition = new Vector3(transform.position.x - 1445 - (sw3 * 1083), GetSilver.GetComponent<RectTransform>().anchoredPosition.y);
        DragSilver.GetComponent<RectTransform>().anchoredPosition = new Vector3(transform.position.x - 1086 - (sw3 * 1083), DragSilver.GetComponent<RectTransform>().anchoredPosition.y);
        OtherSilver.GetComponent<RectTransform>().anchoredPosition = new Vector3(transform.position.x - 733.93f - (sw3 * 1083), OtherSilver.GetComponent<RectTransform>().anchoredPosition.y);
        GetbgSilver.GetComponent<RectTransform>().anchoredPosition = new Vector3(transform.position.x - 1445 - (sw3 * 1083), GetbgSilver.GetComponent<RectTransform>().anchoredPosition.y);
        DragbgSilver.GetComponent<RectTransform>().anchoredPosition = new Vector3(transform.position.x - 1086 - (sw3 * 1083), DragbgSilver.GetComponent<RectTransform>().anchoredPosition.y);
        OtherbgSilver.GetComponent<RectTransform>().anchoredPosition = new Vector3(transform.position.x - 733.93f - (sw3 * 1083), OtherbgSilver.GetComponent<RectTransform>().anchoredPosition.y);

        if (sw3 < 0.0018 && sw3 > -1.010)
        {
            SilverBg.GetComponent<RectTransform>().anchoredPosition = new Vector3(transform.position.x - 1083.875f - (sw3 * 1083.875f), SilverBg.GetComponent<RectTransform>().anchoredPosition.y);
            SilverDown.GetComponent<RectTransform>().anchoredPosition = new Vector3(transform.position.x - 1082.7f - (sw3 * 1083), SilverDown.GetComponent<RectTransform>().anchoredPosition.y);

        }
        if (sw3 < 0.0018)
        {
            GoldBg.GetComponent<RectTransform>().anchoredPosition = new Vector3(transform.position.x - 1.5f - (sw3 * 1084.5f), GoldBg.GetComponent<RectTransform>().anchoredPosition.y);
            GoldDown.GetComponent<RectTransform>().anchoredPosition = new Vector3(transform.position.x - 0 - (sw3 * 1083), GoldDown.GetComponent<RectTransform>().anchoredPosition.y);

        }
        if (sw3 <= -1.010)
        {
            SilverBg.GetComponent<RectTransform>().anchoredPosition = new Vector3(transform.position.x - 1.297363f, SilverBg.GetComponent<RectTransform>().anchoredPosition.y);
            SilverDown.GetComponent<RectTransform>().anchoredPosition = new Vector3(transform.position.x - 1082.7f + 1083f, SilverDown.GetComponent<RectTransform>().anchoredPosition.y);

        }
        if (sw3 > 0.0018)
        {
            GoldBg.GetComponent<RectTransform>().anchoredPosition = new Vector3(transform.position.x - 1.5f, GoldBg.GetComponent<RectTransform>().anchoredPosition.y);
            GoldDown.GetComponent<RectTransform>().anchoredPosition = new Vector3(transform.position.x - 0, GoldDown.GetComponent<RectTransform>().anchoredPosition.y);
        }
        if (sw3 > 0.5)
        {
            SilverBg.GetComponent<RectTransform>().anchoredPosition = new Vector3(transform.position.x - 1084.741f, SilverBg.GetComponent<RectTransform>().anchoredPosition.y);
            SilverDown.GetComponent<RectTransform>().anchoredPosition = new Vector3(transform.position.x - 1082.7f, SilverDown.GetComponent<RectTransform>().anchoredPosition.y);
        }
        if (sw3 < 0.5 && sw3 > 0.0018)
        {
            SilverBg.GetComponent<RectTransform>().anchoredPosition = new Vector3(transform.position.x - 1084.741f, SilverBg.GetComponent<RectTransform>().anchoredPosition.y);
            SilverDown.GetComponent<RectTransform>().anchoredPosition = new Vector3(transform.position.x - 1082.7f, SilverDown.GetComponent<RectTransform>().anchoredPosition.y);
        }

        SilverPanCard.GetComponent<RectTransform>().anchoredPosition = new Vector3(transform.position.x - 2165 - (sw3 * 1083), SilverPanCard.GetComponent<RectTransform>().anchoredPosition.y);
        SilverPanHist.GetComponent<RectTransform>().anchoredPosition = new Vector3(transform.position.x - 1083 - (sw3 * 1083), SilverPanHist.GetComponent<RectTransform>().anchoredPosition.y);




        if (sw3 > -1.707f) SilverCard.GetComponent<RectTransform>().anchoredPosition = new Vector3(transform.position.x - 1871 - (sw3 * 1100), SilverCard.GetComponent<RectTransform>().anchoredPosition.y);
        if (sw3 < -1.707f) SilverCard.GetComponent<RectTransform>().anchoredPosition = new Vector3(transform.position.x, SilverCard.GetComponent<RectTransform>().anchoredPosition.y);

        //Debug.Log(i);
        if (i < 0.165f)
        {
            dotslide1.GetComponent<Image>().color = new Color(255 / 255.0f, 255 / 255.0f, 255 / 255.0f, 1);
            dotslide2.GetComponent<Image>().color = new Color(255 / 255.0f, 255 / 255.0f, 255 / 255.0f, 0.5f);
            dotslide3.GetComponent<Image>().color = new Color(255 / 255.0f, 255 / 255.0f, 255 / 255.0f, 0.5f);
            dotslide4.GetComponent<Image>().color = new Color(255 / 255.0f, 255 / 255.0f, 255 / 255.0f, 0.5f);
        }
        if (u >= 0.165f && u < 0.495)
        {

            dotslide1.GetComponent<Image>().color = new Color(255 / 255.0f, 255 / 255.0f, 255 / 255.0f, 0.5f);
            dotslide2.GetComponent<Image>().color = new Color(255 / 255.0f, 255 / 255.0f, 255 / 255.0f, 1);
            dotslide3.GetComponent<Image>().color = new Color(255 / 255.0f, 255 / 255.0f, 255 / 255.0f, 0.5f);
            dotslide4.GetComponent<Image>().color = new Color(255 / 255.0f, 255 / 255.0f, 255 / 255.0f, 0.5f);
        }
        if (u >= 0.495f && u < 0.825f)
        {
            dotslide1.GetComponent<Image>().color = new Color(255 / 255.0f, 255 / 255.0f, 255 / 255.0f, 0.5f);
            dotslide2.GetComponent<Image>().color = new Color(255 / 255.0f, 255 / 255.0f, 255 / 255.0f, 0.5f);
            dotslide3.GetComponent<Image>().color = new Color(255 / 255.0f, 255 / 255.0f, 255 / 255.0f, 1);
            dotslide4.GetComponent<Image>().color = new Color(255 / 255.0f, 255 / 255.0f, 255 / 255.0f, 0.5f);
        }
        if (u >= 0.825f)
        {
            dotslide1.GetComponent<Image>().color = new Color(255 / 255.0f, 255 / 255.0f, 255 / 255.0f, 0.5f);
            dotslide2.GetComponent<Image>().color = new Color(255 / 255.0f, 255 / 255.0f, 255 / 255.0f, 0.5f);
            dotslide3.GetComponent<Image>().color = new Color(255 / 255.0f, 255 / 255.0f, 255 / 255.0f, 0.5f);
            dotslide4.GetComponent<Image>().color = new Color(255 / 255.0f, 255 / 255.0f, 255 / 255.0f, 1);
        }
        u = i;
        swap = true;
    }
    public void ToLog(string u)
    {
        Debuglog.GetComponent<Text>().text = u;
    }
    public void ShowWhatIsGoldgram()
    {
        WhatIsGoldgram.SetActive(true);
    }
    public void HideWhatIsGoldgram()
    {
        WhatIsGoldgram.SetActive(false);
    }
    public void ShowWhatIsWhatIsOldHryvna()
    {
        WhatIsOldHryvna.SetActive(true);
    }
    public void HideWhatIsWhatIsOldHryvna()
    {
        WhatIsOldHryvna.SetActive(false);
    }

    public void ShowGetMoneyGold()
    {
        GetMoneyGold.SetActive(true);
    }
    public void HideGetMoneyGold()
    {
        GetMoneyGold.SetActive(false);
    }
    public void ShowGetMoneySilver()
    {
        GetMoneySilver.SetActive(true);
    }
    public void HideGetMoneySilver()
    {
        GetMoneySilver.SetActive(false);
    }

    public void ShowDragMoneyGold()
    {
        DragMoneyGold.SetActive(true);
    }
    public void HideDragMoneyGold()
    {
        DragMoneyGold.SetActive(false);
    }
    public void ShowDragMoneySilver()
    {
        DragMoneySilver.SetActive(true);
    }
    public void HideDragMoneySilver()
    {
        DragMoneySilver.SetActive(false);
    }
    public void ShowMoreGoldHistory()
    {
        PanHist.GetComponent<RectTransform>().anchoredPosition = new Vector3(PanHist.GetComponent<RectTransform>().anchoredPosition.x, transform.position.y + 4.776611f + 475.7545f);
        GoldSum.GetComponent<RectTransform>().anchoredPosition = new Vector3(transform.position.x, transform.position.y + 200f);

    }
    public void ShowMoreSilverHistory()
    {
        SilverPanHist.GetComponent<RectTransform>().anchoredPosition = new Vector3(SilverPanHist.GetComponent<RectTransform>().anchoredPosition.x, transform.position.y + 4.776611f + 475.7545f);
        SilverSum.GetComponent<RectTransform>().anchoredPosition = new Vector3(SilverSum.GetComponent<RectTransform>().anchoredPosition.x, SilverSum.GetComponent<RectTransform>().anchoredPosition.y + 200f);
    }
    public void ShowMoreGoldCard()
    {
        PanCard.GetComponent<RectTransform>().anchoredPosition = new Vector3(PanCard.GetComponent<RectTransform>().anchoredPosition.x, transform.position.y + 4.776611f + 599.5778055f);
    }
    public void ShowMoreSilverCard()
    {
        SilverPanCard.GetComponent<RectTransform>().anchoredPosition = new Vector3(SilverPanCard.GetComponent<RectTransform>().anchoredPosition.x, transform.position.y + 4.776611f + 599.5778055f);
    }
    public void HideMoreGoldHistory()
    {
        PanHist.GetComponent<RectTransform>().anchoredPosition = new Vector3(PanHist.GetComponent<RectTransform>().anchoredPosition.x, transform.position.y - 13f - 475.7545f);
        GoldSum.GetComponent<RectTransform>().anchoredPosition = new Vector3(transform.position.x, transform.position.y);
    }
    public void HideMoreSilverHistory()
    {
        SilverPanHist.GetComponent<RectTransform>().anchoredPosition = new Vector3(SilverPanHist.GetComponent<RectTransform>().anchoredPosition.x, transform.position.y - 13f - 475.7545f);
        SilverSum.GetComponent<RectTransform>().anchoredPosition = new Vector3(SilverSum.GetComponent<RectTransform>().anchoredPosition.x, SilverSum.GetComponent<RectTransform>().anchoredPosition.y - 200);
    }
    public void HideMoreGoldCard()
    {
        PanCard.GetComponent<RectTransform>().anchoredPosition = new Vector3(PanCard.GetComponent<RectTransform>().anchoredPosition.x, transform.position.y - 13f - 475.7545f);
    }
    public void HideMoreSilverCard()
    {
        SilverPanCard.GetComponent<RectTransform>().anchoredPosition = new Vector3(SilverPanCard.GetComponent<RectTransform>().anchoredPosition.x, transform.position.y - 13f - 475.7545f);
    }
}
