using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using ZXing;
using ZXing.QrCode;
using Firebase;
using Firebase.Analytics;
using Firebase.Auth;
using Firebase.Extensions;
using Firebase.Database;
using Firebase.Messaging;

using System;
using System.Threading.Tasks;
using Unity.Notifications.Android;
using Unity.Notifications;


public class Main : MonoBehaviour
{
    [SerializeField]
    private RawImage _rawImageBackgraund;
    [SerializeField]
    private AspectRatioFitter _AspectRatioFitter;
    [SerializeField]
    private GameObject textfromqr;
    [SerializeField]
    private RectTransform _skanZone;
    [SerializeField]
    private RawImage _rawImageReciver;
    [SerializeField]
    private InputField _textInputField;

    private Texture2D _StoreEncodedText;


    private bool _isCamAwaileble;
    private WebCamTexture _camTexture;

    int dotpin = 6;
    uint oldsumintgold;float oldsumfloatgold;bool floatchenged=false;
    public GameObject dotpin1, dotpin2, dotpin3, dotpin4, dotpin5, dotpin6, PinCod;
    public GameObject SilverSum, GoldSum;
    public GameObject KursDollartxtGold, KursGrivnatxtGold, KursEvrotxtGold;
    public GameObject KursDollartxtSilver, KursGrivnatxtSilver, KursEvrotxtSilver;
    public GameObject Pricel, Debuglog;
    public GameObject PanStart1, PanStart2, PhoneNumPanStart2;
    public GameObject NextBTN, MainPan;

    public GameObject InputName, InputPIB, InputMail, InputPin, CreateUserBtn;
    public GameObject RegisterPan;
    public GameObject TxtKursUAHGold, TxtKursUSDGold, TxtKursEURGold;
    public GameObject TxtKursUAHSilver, TxtKursUSDSilver, TxtKursEURSilver;

    public GameObject TxtLog1, TxtLog2, TxtLog3, TxtLog4, TxtLog5, TxtLog6, TxtLog7, TxtLog8;

    public GameObject DecimalGold, DecimalSilver;

    public GameObject NumCardGoldTxt, NumCardSilverTxt;

    public GameObject FindNickNameTxt, FindNumCardTxt, PanFind, PanContact, MainPanContact, NotFaundPan, inputnotise;
    public GameObject SendNickNameTxt, SendNumCardTxt, PanSend, Sendinputnotise, mysumtxt,sendbtn; uint sumintsend;float sumfloatsend;

    public GameObject FindNickNameTxtSilver, FindNumCardTxtSilver, PanFindSilver, PanContactSilver, MainPanContactSilver, NotFaundPanSilver, inputnotiseSilver;

    string sumGoldStr, sumSilverStr;
    float MyGoldSumFloat, MySilverSumFloat; float ContactGoldSumFloat, ContactSilverSumFloat;
    uint MyGoldSumInt, MySilverSumInt; uint ContactGoldSumInt, ContactMySilverSumInt;
    float KursDollar, KursGrivnaGold, KursEvro, KursGrivnaSilver, ServerKursGrivnaGold, ServerKursGrivnaSilver;
    string getingPin, NumCardGold, NumCardSilver;
    string phoneNumber; string ID;
    uint phoneAuthTimeoutMs = 180 * 1000;
    bool isQRscanActive;
    int pinCodServer;
    string NickName, PIB, Email; int PINCod; bool a, b, c, d;
    string FindNickName, FindNumCard;
    private int identifier; int startwas =0;

    void Start()
    {

        initServices();

        



    }
    public void Awake()
    {
        
        initValue();


        NickName = PlayerPrefs.GetString("NickName");
        PIB = PlayerPrefs.GetString("PIB");
        Email = PlayerPrefs.GetString("Email");
        phoneNumber = PlayerPrefs.GetString("UserID");
        

        if (phoneNumber.Length > 2  ) //если есть номер записанный перейти к вводу пинкода

        {


            ToLog(phoneNumber);
            PinCod.SetActive(true);
            NumCardGold = "3333" + phoneNumber.Substring(1);
            NumCardSilver = "7777" + phoneNumber.Substring(1);
            SetServerValueListener();

            

            ToLog(NumCardGold);

        }
        else
        {
            ToLog(phoneNumber);
            PanStart1.SetActive(true);
        }
        
        var channel = new AndroidNotificationChannel()
        {
            Id = "main",
            Name = "Важливі повідомлення",
            Importance = Importance.High,
            Description = "Ці повідомлення не варто вимикати",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);
        
    }

    void initServices()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
        });
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        Firebase.Messaging.FirebaseMessaging.TokenReceived += OnTokenReceived;
        Firebase.Messaging.FirebaseMessaging.MessageReceived += OnMessageReceived;


    }
    
    void initValue()
    {

        _StoreEncodedText = new Texture2D(256, 256);

    }
    void GetServerValue()
    {
        initValue();
       
        FirebaseDatabase.DefaultInstance.GetReference("Bank").Child("KursDolGr").GetValueAsync().ContinueWithOnMainThread(KursDolGrT =>
        {
            if (KursDolGrT.IsFaulted)
            { ToLog("Fail5"); }
            else if (KursDolGrT.IsCompleted)
            {
                DataSnapshot snapshot11 = KursDolGrT.Result;
                KursDollar = (float)Convert.ToDecimal(KursDolGrT.Result.Value);
                ValueToDisplay();
            }
        });
        FirebaseDatabase.DefaultInstance.GetReference("Bank").Child("KursEvrGr").GetValueAsync().ContinueWithOnMainThread(KursEvrGrT =>
        {
            if (KursEvrGrT.IsFaulted)
            { ToLog("Fail6"); }
            else if (KursEvrGrT.IsCompleted)
            {
                DataSnapshot snapshot12 = KursEvrGrT.Result;
                KursEvro = (float)Convert.ToDecimal(KursEvrGrT.Result.Value);
                ValueToDisplay();
            }
        });

        FirebaseDatabase.DefaultInstance.GetReference("Bank").Child("KursGrivnaGold").GetValueAsync().ContinueWithOnMainThread(KursGrivnaGoldT =>
        {
            if (KursGrivnaGoldT.IsFaulted)
            { ToLog("Fail7"); }
            else if (KursGrivnaGoldT.IsCompleted)
            {
                DataSnapshot snapshot12 = KursGrivnaGoldT.Result;
                ServerKursGrivnaGold = (float)Convert.ToDecimal(KursGrivnaGoldT.Result.Value);
                ValueToDisplay();
            }
        });
        FirebaseDatabase.DefaultInstance.GetReference("Bank").Child("KursGrivnaSilver").GetValueAsync().ContinueWithOnMainThread(KursGrivnaSilverT =>
        {

            if (KursGrivnaSilverT.IsFaulted)
            { ToLog("Fail8"); }
            else if (KursGrivnaSilverT.IsCompleted)
            {
                DataSnapshot snapshot12 = KursGrivnaSilverT.Result;
                ServerKursGrivnaSilver = (float)Convert.ToDecimal(KursGrivnaSilverT.Result.Value);
                ValueToDisplay();

            }
        });
        
    }
    void SetServerValueListener()
    {
        FirebaseDatabase.DefaultInstance.GetReference("UsersID").Child(phoneNumber).Child(NumCardGold).Child("MyGoldSumInt").ValueChanged += HandleValueChangedMyGoldSumInt;
        FirebaseDatabase.DefaultInstance.GetReference("UsersID").Child(phoneNumber).Child(NumCardGold).Child("MyGoldSumFloat").ValueChanged += HandleValueChangedMyGoldSumFloat;
        FirebaseDatabase.DefaultInstance.GetReference("UsersID").Child(phoneNumber).Child(NumCardSilver).Child("MySilverSumInt").ValueChanged += HandleValueChangedMySilverSumInt;
        FirebaseDatabase.DefaultInstance.GetReference("UsersID").Child(phoneNumber).Child(NumCardSilver).Child("MySilverSumFloat").ValueChanged += HandleValueChangedMySilverSumFloat;


    }
    void HandleValueChangedMyGoldSumInt(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        oldsumintgold = MyGoldSumInt;
        MyGoldSumInt = Convert.ToUInt32(args.Snapshot.Value); ValueToDisplay();
        if(oldsumintgold!= MyGoldSumInt) SendNotification();




    }
    
    void HandleValueChangedMyGoldSumFloat(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        oldsumfloatgold = MyGoldSumFloat;
        MyGoldSumFloat = (float)Convert.ToDecimal(args.Snapshot.Value); ValueToDisplay();
        if (oldsumfloatgold != MyGoldSumFloat) { floatchenged = true; SendNotification(); }
    }
    void HandleValueChangedMySilverSumInt(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        MySilverSumInt = Convert.ToUInt32(args.Snapshot.Value); ValueToDisplay();
    }
    void HandleValueChangedMySilverSumFloat(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        MySilverSumFloat = (float)Convert.ToDecimal(args.Snapshot.Value); ValueToDisplay();
    }
    void SendNotification()
    {
        if (startwas < 2) {floatchenged = false; oldsumintgold = MyGoldSumInt; }
        if (startwas >=2)
        {
            
            var notification = new AndroidNotification();

            if (oldsumintgold < MyGoldSumInt)
            { 
                notification.Title = "Поповнення рахунку!";
                if (floatchenged == false) { notification.Text = "Ви отримали " + (MyGoldSumInt - oldsumintgold) + " грам золота."; oldsumintgold = MyGoldSumInt; }
                if (floatchenged == true) notification.Text = "Ви отримали " + (MyGoldSumInt - oldsumintgold)+ "." + (string.Format("{0:F5}", MyGoldSumFloat).Substring(2)) + " грам золота.";
            }
            if (oldsumintgold > MyGoldSumInt) 
            {
                notification.Title = "Списання з рахунку!";
                if (floatchenged == false) { notification.Text = "З вашого рахунку знято " + (oldsumintgold - MyGoldSumInt) + " грам золота."; oldsumintgold = MyGoldSumInt; }
                if (floatchenged == true) notification.Text = "З вашого рахунку знято " + (oldsumintgold - MyGoldSumInt) + "." + (string.Format("{0:F5}", MyGoldSumFloat).Substring(2)) + " грам золота.";
            }
            if (oldsumintgold == MyGoldSumInt)
            {
                if (oldsumfloatgold < MyGoldSumFloat)
                {


                    if (floatchenged == true) { notification.Title = "Поповнення рахунку!"; notification.Text = "Ви отримали " + "0." + (string.Format("{0:F5}", MyGoldSumFloat - oldsumfloatgold).Substring(2)) + " грам золота."; }
                }
                if (oldsumfloatgold > MyGoldSumFloat)
                {
                    
                    if (floatchenged == true) { notification.Title = "Списання з рахунку!"; notification.Text = "З вашого рахунку знято " + "0." + (string.Format("{0:F5}", oldsumfloatgold - MyGoldSumFloat).Substring(2)) + " грам золота."; }
                }
            }
            notification.FireTime = System.DateTime.Now.AddMinutes(0);
            notification.SmallIcon = "smoll";
            notification.LargeIcon = "large";
            AndroidNotificationCenter.SendNotification(notification, "main");
            floatchenged = false;
        }
        startwas ++; 
    }
    void ValueToDisplay()
    {
        NumCardGoldTxt.GetComponent<Text>().text = NumCardGold;
        NumCardSilverTxt.GetComponent<Text>().text = NumCardSilver;

        TxtLog1.GetComponent<Text>().text = MyGoldSumInt.ToString();
        TxtLog2.GetComponent<Text>().text = MyGoldSumFloat.ToString();
        TxtLog3.GetComponent<Text>().text = MySilverSumInt + "";
        TxtLog4.GetComponent<Text>().text = MySilverSumFloat.ToString();
        TxtLog5.GetComponent<Text>().text = KursDollar + "";
        TxtLog6.GetComponent<Text>().text = KursEvro + "";
        TxtLog7.GetComponent<Text>().text = ServerKursGrivnaGold + "";
        TxtLog8.GetComponent<Text>().text = ServerKursGrivnaSilver + "";

        KursGrivnaGold = ServerKursGrivnaGold * (MyGoldSumFloat + MyGoldSumInt);
        KursGrivnaSilver = ServerKursGrivnaSilver * 165f * (MySilverSumFloat + MySilverSumInt);



        while (MyGoldSumFloat >= 1.00000f) { MyGoldSumFloat -= 1.00000f; MyGoldSumInt += 1; 
            FirebaseDatabase.DefaultInstance.RootReference.Child("UsersID").Child(phoneNumber).Child(NumCardGold).Child("MyGoldSumInt").SetValueAsync(MyGoldSumInt);
            FirebaseDatabase.DefaultInstance.RootReference.Child("UsersID").Child(phoneNumber).Child(NumCardGold).Child("MyGoldSumFloat").SetValueAsync(MyGoldSumFloat);
        }
        while (MySilverSumFloat >= 1.00000f) { MySilverSumFloat -= 1.00000f; MySilverSumInt += 1;
            FirebaseDatabase.DefaultInstance.RootReference.Child("UsersID").Child(phoneNumber).Child(NumCardGold).Child("MySilverSumInt").SetValueAsync(MySilverSumInt);
            FirebaseDatabase.DefaultInstance.RootReference.Child("UsersID").Child(phoneNumber).Child(NumCardGold).Child("MySilverSumFloat").SetValueAsync(MySilverSumFloat);
        }


        if (MySilverSumInt <= 99)
        {
            sumSilverStr = string.Format("{0:0}", MySilverSumInt) + "." + (string.Format("{0:F5}", MySilverSumFloat).Substring(2));
            SilverSum.GetComponent<Text>().text = sumSilverStr;
            DecimalSilver.SetActive(false);
        }
        if (MyGoldSumInt <= 99)
        {
            sumGoldStr = string.Format("{0:0}", MyGoldSumInt) + "." + (string.Format("{0:F5}", MyGoldSumFloat).Substring(2));
            GoldSum.GetComponent<Text>().text = sumGoldStr;
            DecimalGold.SetActive(false);
        }

        if (MySilverSumInt > 99)
        {
            DecimalSilver.SetActive(true);
            SilverSum.GetComponent<Text>().text = string.Format("{0:0}", MySilverSumInt);
            DecimalSilver.GetComponent<Text>().text = "." + (string.Format("{0:F5}", MySilverSumFloat).Substring(2));
        }
        if (MyGoldSumInt > 99)
        {
            DecimalGold.SetActive(true);
            GoldSum.GetComponent<Text>().text = string.Format("{0:0}", MyGoldSumInt);
            DecimalGold.GetComponent<Text>().text = "." + (string.Format("{0:F5}", MyGoldSumFloat).Substring(2));
        }


        KursDollartxtGold.GetComponent<Text>().text = string.Format("≈{0:F2}", (KursGrivnaGold / KursDollar));
        KursGrivnatxtGold.GetComponent<Text>().text = string.Format("≈{0:F2}", KursGrivnaGold);
        KursEvrotxtGold.GetComponent<Text>().text = string.Format("≈{0:F2}", (KursGrivnaGold / KursEvro));

        KursDollartxtSilver.GetComponent<Text>().text = string.Format("{0:F2}≈", (KursGrivnaSilver / KursDollar));
        KursGrivnatxtSilver.GetComponent<Text>().text = string.Format("{0:F2}≈", KursGrivnaSilver);
        KursEvrotxtSilver.GetComponent<Text>().text = string.Format("{0:F2}≈", (KursGrivnaSilver / KursEvro));

        TxtKursUAHGold.GetComponent<Text>().text = string.Format("{0} UAH/{1} UAH", ServerKursGrivnaGold - (ServerKursGrivnaGold * 0.01), ServerKursGrivnaGold);
        TxtKursUSDGold.GetComponent<Text>().text = string.Format("{0:F2} USD/{1:F2} USD", ServerKursGrivnaGold / KursDollar - ((ServerKursGrivnaGold / KursDollar) * 0.01), ServerKursGrivnaGold / KursDollar);
        TxtKursEURGold.GetComponent<Text>().text = string.Format("{0:F2} EUR/{1:F2} EUR", ServerKursGrivnaGold / KursEvro - ((ServerKursGrivnaGold / KursEvro) * 0.01), ServerKursGrivnaGold / KursEvro);

        TxtKursUAHSilver.GetComponent<Text>().text = string.Format("{0} UAH/{1} UAH", (ServerKursGrivnaSilver - (ServerKursGrivnaSilver * 0.01)) * 165, ServerKursGrivnaSilver * 165);
        TxtKursUSDSilver.GetComponent<Text>().text = string.Format("{0:F2} USD/{1:F2} USD", (ServerKursGrivnaSilver / KursDollar - ((ServerKursGrivnaSilver / KursDollar) * 0.01)) * 165, (ServerKursGrivnaSilver / KursDollar) * 165);
        TxtKursEURSilver.GetComponent<Text>().text = string.Format("{0:F2} EUR/{1:F2} EUR", (ServerKursGrivnaSilver / KursEvro - ((ServerKursGrivnaSilver / KursEvro) * 0.01)) * 165, (ServerKursGrivnaSilver / KursEvro) * 165);

    }
    public void ShowInputPin(string p)
    {
        if (dotpin != 0) dotpin--;

        if (dotpin == 5) { dotpin1.GetComponent<Image>().color = new Color(227 / 255.0f, 66 / 255.0f, 66 / 255.0f); getingPin = getingPin + p; }
        if (dotpin == 4) { dotpin2.GetComponent<Image>().color = new Color(227 / 255.0f, 66 / 255.0f, 66 / 255.0f); getingPin = getingPin + p; }
        if (dotpin == 3) { dotpin3.GetComponent<Image>().color = new Color(227 / 255.0f, 66 / 255.0f, 66 / 255.0f); getingPin = getingPin + p; }
        if (dotpin == 2) { dotpin4.GetComponent<Image>().color = new Color(227 / 255.0f, 66 / 255.0f, 66 / 255.0f); getingPin = getingPin + p; }
        if (dotpin == 1) { dotpin5.GetComponent<Image>().color = new Color(227 / 255.0f, 66 / 255.0f, 66 / 255.0f); getingPin = getingPin + p; }
        if (dotpin == 0)
        {
            dotpin6.GetComponent<Image>().color = new Color(227 / 255.0f, 66 / 255.0f, 66 / 255.0f); getingPin = getingPin + p;
            FirebaseDatabase.DefaultInstance.GetReference("UsersID").Child(phoneNumber).Child("PINCod").GetValueAsync().ContinueWithOnMainThread(task =>
            {
                if (task.IsFaulted)
                {
                    ToLog("fail");
                }
                else if (task.IsCompleted)
                {

                    DataSnapshot snapshot6 = task.Result;
                    if (Convert.ToInt32(getingPin) == Convert.ToInt32(snapshot6.Value))
                    {
                        PinCod.SetActive(false);
                        MainPan.SetActive(true);
                        GetServerValue();
                    }
                    else
                    {
                        dotpin = 6; getingPin = "";
                        dotpin1.GetComponent<Image>().color = new Color(250 / 255.0f, 250 / 255.0f, 250 / 255.0f);
                        dotpin2.GetComponent<Image>().color = new Color(250 / 255.0f, 250 / 255.0f, 250 / 255.0f);
                        dotpin3.GetComponent<Image>().color = new Color(250 / 255.0f, 250 / 255.0f, 250 / 255.0f);
                        dotpin4.GetComponent<Image>().color = new Color(250 / 255.0f, 250 / 255.0f, 250 / 255.0f);
                        dotpin5.GetComponent<Image>().color = new Color(250 / 255.0f, 250 / 255.0f, 250 / 255.0f);
                        dotpin6.GetComponent<Image>().color = new Color(250 / 255.0f, 250 / 255.0f, 250 / 255.0f);
                    }

                }
            });


        }

        ToLog(getingPin);
    }
    public void DeletDotPin()
    {
        if (dotpin == 5) { dotpin1.GetComponent<Image>().color = new Color(250 / 255.0f, 250 / 255.0f, 250 / 255.0f); }
        if (dotpin == 4) { dotpin2.GetComponent<Image>().color = new Color(250 / 255.0f, 250 / 255.0f, 250 / 255.0f); }
        if (dotpin == 3) { dotpin3.GetComponent<Image>().color = new Color(250 / 255.0f, 250 / 255.0f, 250 / 255.0f); }
        if (dotpin == 2) { dotpin4.GetComponent<Image>().color = new Color(250 / 255.0f, 250 / 255.0f, 250 / 255.0f); }
        if (dotpin == 1) { dotpin5.GetComponent<Image>().color = new Color(250 / 255.0f, 250 / 255.0f, 250 / 255.0f); }
        if (dotpin == 0) { dotpin6.GetComponent<Image>().color = new Color(250 / 255.0f, 250 / 255.0f, 250 / 255.0f); }
        if (dotpin != 6) dotpin++;
        int ind = getingPin.Length - 1;
        getingPin = getingPin.Remove(ind);
        ToLog(getingPin);
    }

    void Update()
    {

        if (isQRscanActive == true) { UpdateCameraRender(); Scan(); }


    }


    
    private void SetUpCamera()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        if (devices.Length == 0)
        {
            _isCamAwaileble = false;
            return;
        }
        for (int i = 0; i < devices.Length; i++)
        {
            if (devices[i].isFrontFacing == false)
            {
                _camTexture = new WebCamTexture(devices[i].name, (int)_skanZone.rect.width, (int)_skanZone.rect.height);
            }

        }
        _camTexture.Play();
        _rawImageBackgraund.texture = _camTexture;
        _isCamAwaileble = true;
    }

    public void StartScan()
    {
        isQRscanActive = true;
        SetUpCamera();

    }
    public void StopScan()
    {
        isQRscanActive = false;
        _camTexture.Stop();
        _isCamAwaileble = false;
    }
    private void UpdateCameraRender()
    {
        if (_isCamAwaileble == false) { return; }
        float ratio = (float)_camTexture.width / (float)_camTexture.height;
        _AspectRatioFitter.aspectRatio = ratio;
        int orientation = -_camTexture.videoRotationAngle;
        _rawImageBackgraund.rectTransform.localEulerAngles = new Vector3(0, 0, orientation);
    }
    private void Scan()
    {
        try
        {
            IBarcodeReader barcodeReader = new BarcodeReader();
            Result result = barcodeReader.Decode(_camTexture.GetPixels32(), _camTexture.width, _camTexture.height);
            if (result != null)
            {
                textfromqr.GetComponent<Text>().text = result.Text;
                Pricel.GetComponent<Image>().color = new Color(0 / 255.0f, 250 / 255.0f, 0 / 255.0f);
            }
            else
            {
                textfromqr.GetComponent<Text>().text = "Failed to Read!";
                Pricel.GetComponent<Image>().color = new Color(250 / 255.0f, 0 / 255.0f, 0 / 255.0f);
            }
        }
        catch
        {
            textfromqr.GetComponent<Text>().text = "Failed in try!";

        }
    }
    private Color32[] Encode(string textForEncoding, int widht, int hight)
    {
        BarcodeWriter writer = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                Height = hight,
                Width = widht
            }
        };
        return writer.Write(textForEncoding);
    }
    public void Encode()
    {
        EncodeTextToQRcode();
    }
    private void EncodeTextToQRcode()
    {
        string textWrite = string.IsNullOrEmpty(_textInputField.text) ? "You Suld Write Somesing" : _textInputField.text;
        Color32[] _convertPixelToTexture = Encode(textWrite, _StoreEncodedText.width, _StoreEncodedText.height);
        _StoreEncodedText.SetPixels32(_convertPixelToTexture);
        _StoreEncodedText.Apply();

        _rawImageReciver.texture = _StoreEncodedText;
    }



    public void GetNumber(string i) { phoneNumber = i; }

    public void SignPhone()
    {

        PhoneAuthProvider.GetInstance(FirebaseAuth.DefaultInstance).VerifyPhoneNumber(phoneNumber, phoneAuthTimeoutMs, null,
          verificationCompleted: (credential) =>
          {
              // Auto-sms-retrieval or instant validation has succeeded (Android only).
              // There is no need to input the verification code.
              // `credential` can be used instead of calling GetCredential().

              ToLog(credential.Provider.ToString());
          },
          verificationFailed: (error) =>
          {
              ToLog(error);
              // The verification code was not sent.
              // `error` contains a human readable explanation of the problem.
          },
          codeSent: (id, token) =>
          {
              ID = id;
              ToLog(id + "  " + token);
              // Verification code was successfully sent via SMS.
              // `id` contains the verification id that will need to passed in with
              // the code from the user when calling GetCredential().
              // `token` can be used if the user requests the code be sent again, to
              // tie the two requests together.
          },
          codeAutoRetrievalTimeOut: (id) =>
          {
              // Called when the auto-sms-retrieval has timed out, based on the given
              // timeout parameter.
              // `id` contains the verification id of the request that timed out.
          });
    }

    public void EnterCod(string Cod)
    {

        if (Cod.Length == 6)
        {
            Credential credential = PhoneAuthProvider.GetInstance(FirebaseAuth.DefaultInstance).GetCredential(ID, Cod);

            FirebaseAuth.DefaultInstance.SignInWithCredentialAsync(credential).ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    ToLog("SignInWithCredentialAsync encountered an error: " +
                                   task.Exception);
                    return;
                }
                PanStart1.SetActive(false);
                PanStart2.SetActive(false);
                FirebaseUser newUser = task.Result;
                ToLog("User signed in successfully");
                // This should display the phone number.
                ToLog("Phone number: " + newUser.PhoneNumber);
                // The phone number providerID is 'phone'.
                ToLog("Phone provider ID: " + newUser.ProviderId);
                //проверка есть ли в базе номер
                FirebaseDatabase.DefaultInstance.GetReference("UsersID").Child(phoneNumber).GetValueAsync().ContinueWithOnMainThread(task1 =>
                {
                    if (task1.IsFaulted)
                    {
                        //если неудача перейти к регистрации
                        RegisterPan.SetActive(true);
                    }
                    else if (task1.IsCompleted)
                    {
                        DataSnapshot snapshot2 = task1.Result;
                        if (snapshot2.Value != null)//если что-то есть запросить пинкод
                        {
                            FirebaseDatabase.DefaultInstance.GetReference("UsersID").Child(phoneNumber).Child("PINCod").GetValueAsync().ContinueWithOnMainThread(task3 =>
                            {
                                if (task3.IsFaulted)
                                {
                                    RegisterPan.SetActive(true);//если неудача перейти к регистрации
                                }
                                else if (task3.IsCompleted)
                                {
                                    DataSnapshot snapshot3 = task3.Result; PlayerPrefs.SetString("UserID", phoneNumber);// если получилось записать номер
                                    pinCodServer = Convert.ToInt32(snapshot3.Value); ToLog(pinCodServer + ""); PinCod.SetActive(true);// взять пинкод и перейти в его вводу
                                }
                            });
                        }
                        else RegisterPan.SetActive(true);//если неудача перейти к регистрации

                    }
                });

            });
        }

    }

    public void ToLog(string u)
    {
        Debuglog.GetComponent<Text>().text = u;
    }
    public void PhoneToStartPan2(string u)
    {
        if (u.Length == 13) { NextBTN.GetComponent<Button>().interactable = true; }
        PhoneNumPanStart2.GetComponent<Text>().text = u;
    }


    public void NickNameGET(string p)
    {
        if (p.Length > 0) { InputName.GetComponent<Image>().color = new Color(158 / 255.0f, 209 / 255.0f, 157 / 255.0f); a = true; }
        else { InputName.GetComponent<Image>().color = new Color(212 / 255.0f, 212 / 255.0f, 212 / 255.0f); a = false; }
        NickName = p; a = true;
        if (a == true && b == true && c == true && d == true) { CreateUserBtn.GetComponent<Button>().interactable = true; }
    }
    public void PIBGET(string p)
    {
        if (p.Length > 10) { InputPIB.GetComponent<Image>().color = new Color(158 / 255.0f, 209 / 255.0f, 157 / 255.0f); b = true; }
        else { InputPIB.GetComponent<Image>().color = new Color(212 / 255.0f, 212 / 255.0f, 212 / 255.0f); b = false; }
        PIB = p;
        if (a == true && b == true && c == true && d == true) { CreateUserBtn.GetComponent<Button>().interactable = true; }
    }
    public void EmailGET(string p)
    {

        if (p.Length > 5 && p.IndexOf("@") > -1) { InputMail.GetComponent<Image>().color = new Color(158 / 255.0f, 209 / 255.0f, 157 / 255.0f); c = true; }
        else { InputMail.GetComponent<Image>().color = new Color(212 / 255.0f, 212 / 255.0f, 212 / 255.0f); c = false; }
        Email = p;
        if (a == true && b == true && c == true && d == true) { CreateUserBtn.GetComponent<Button>().interactable = true; }
    }
    public void PINCodGET(string p)
    {
        if (p.Length >= 5) { InputPin.GetComponent<Image>().color = new Color(158 / 255.0f, 209 / 255.0f, 157 / 255.0f); d = true; }
        else { InputPin.GetComponent<Image>().color = new Color(212 / 255.0f, 212 / 255.0f, 212 / 255.0f); d = false; }
        PINCod = Int32.Parse(p);
        if (a == true && b == true && c == true && d == true) { CreateUserBtn.GetComponent<Button>().interactable = true; }
    }

    public void RegisterNewUser()
    {

        FirebaseDatabase.DefaultInstance.RootReference.Child("UsersID").Child(phoneNumber).Child("NickName").SetValueAsync(NickName);
        FirebaseDatabase.DefaultInstance.RootReference.Child("UsersID").Child(phoneNumber).Child("PIB").SetValueAsync(PIB);
        FirebaseDatabase.DefaultInstance.RootReference.Child("UsersID").Child(phoneNumber).Child("Email").SetValueAsync(Email);
        FirebaseDatabase.DefaultInstance.RootReference.Child("UsersID").Child(phoneNumber).Child("PINCod").SetValueAsync(PINCod);
        NumCardGold = "3333" + phoneNumber.Substring(1);
        NumCardSilver = "7777" + phoneNumber.Substring(1);
        FirebaseDatabase.DefaultInstance.RootReference.Child("UsersID").Child(phoneNumber).Child(NumCardGold).Child("MyGoldSumInt").SetValueAsync(0);
        FirebaseDatabase.DefaultInstance.RootReference.Child("UsersID").Child(phoneNumber).Child(NumCardGold).Child("MyGoldSumFloat").SetValueAsync(0.00000);

        FirebaseDatabase.DefaultInstance.RootReference.Child("UsersID").Child(phoneNumber).Child(NumCardSilver).Child("MySilverSumInt").SetValueAsync(0);
        FirebaseDatabase.DefaultInstance.RootReference.Child("UsersID").Child(phoneNumber).Child(NumCardSilver).Child("MySilverSumFloat").SetValueAsync(0.00000);



        PlayerPrefs.SetString("UserID", phoneNumber);
        PlayerPrefs.SetString("NickName", NickName);
        PlayerPrefs.SetString("PIB", PIB);
        PlayerPrefs.SetString("Email", Email);
        PlayerPrefs.SetString("NumCardGold", NumCardGold);
        PlayerPrefs.SetString("NumCardSilver", NumCardSilver);

        PlayerPrefs.SetString("MyGoldSumInt", 0 + "");
        PlayerPrefs.SetString("MyGoldSumFloat", 0.00000f + "");
        PlayerPrefs.SetString("MySilverSumInt", 0 + "");
        PlayerPrefs.SetString("MySilverSumFloat", 0.00000f + "");
        
        /*Firebase.Messaging.FirebaseMessaging.GetTokenAsync().ContinueWithOnMainThread(GetToken =>
        {
            if (GetToken.IsFaulted)
            { }
            else if (GetToken.IsCompleted)
            {
                TxtLog8.GetComponent<Text>().text = GetToken.Result;
                FirebaseDatabase.DefaultInstance.RootReference.Child("UsersID").Child(phoneNumber).Child("MassegeToken").SetValueAsync(GetToken.Result);
                PlayerPrefs.SetString("MassegeToken", GetToken.Result);

            }
        });*/

        RegisterPan.SetActive(false);
        PinCod.SetActive(true);
    }

    public void SerchUsrCard(string FindCard)
    {
        ToLog(FindCard.Length + "");
        TxtLog1.GetComponent<Text>().text = ("+" + FindCard.Substring(4));
        TxtLog2.GetComponent<Text>().text = FindCard;
        if (FindCard.Length > 15)
        {
            if (FindNickName.Length < 1) NotFaundPan.SetActive(true);
            FirebaseDatabase.DefaultInstance.GetReference("UsersID").Child("+" + FindCard.Substring(4)).Child("NickName").GetValueAsync().ContinueWithOnMainThread(FindCardT =>
            {

                if (FindCardT.IsFaulted)
                { ToLog("FailFind"); NotFaundPan.SetActive(true); }
                else if (FindCardT.IsCompleted)
                {

                    FindNickName = FindCardT.Result.Value.ToString();

                    FindNumCard = FindCard;
                    inputnotise.SetActive(false);

                    FindNickNameTxt.GetComponent<Text>().text = FindNickName;
                    FindNumCardTxt.GetComponent<Text>().text = FindNumCard;
                    PanFind.SetActive(true);
                    NotFaundPan.SetActive(false);

                }
                if (FindNickName.Length < 1) NotFaundPan.SetActive(true);

            });
        }



    }
    public void ToContact()
    {
        SendNickNameTxt.GetComponent<Text>().text = FindNickName;
        SendNumCardTxt.GetComponent<Text>().text = FindNumCard;
        mysumtxt.GetComponent<Text>().text= string.Format("Баланс {0:0}", MyGoldSumInt) + "." + (string.Format("{0:F5}", MyGoldSumFloat).Substring(2));
    }
    public void InputIntSumSend(string i) 
    {
        if (i != "") sumintsend = Convert.ToUInt32(i);
        else sumintsend = 0;
        if (MyGoldSumInt >= sumintsend)
        { 
            if (sumintsend != 0 || sumfloatsend != 0f) 
            {
                if (i != "") sendbtn.GetComponent<Button>().interactable = true; 
                else  sendbtn.GetComponent<Button>().interactable = false;
            } 
            else sendbtn.GetComponent<Button>().interactable = false;
        }
        else sendbtn.GetComponent<Button>().interactable = false;
        
    }
    public void InputFloatSumSend(string i) 
    {
        if (i != "") sumfloatsend = 1.00000f*(float)Convert.ToDecimal("0,"+i);
        else sumfloatsend = 0.00000f;
        if (MyGoldSumFloat >= sumfloatsend) 
        {
            if (sumintsend != 0 || sumfloatsend != 0f) 
            {
                if (i != "") sendbtn.GetComponent<Button>().interactable = true;
                else sendbtn.GetComponent<Button>().interactable = false;
            }
            else sendbtn.GetComponent<Button>().interactable = false;

        }
        else sendbtn.GetComponent<Button>().interactable = false;
        
    }
    public void SendSumToContact()
    {
        float J = MyGoldSumFloat - sumfloatsend;
        FirebaseDatabase.DefaultInstance.RootReference.Child("UsersID").Child(phoneNumber).Child(NumCardGold).Child("MyGoldSumFloat").SetValueAsync(string.Format("{0:F0}", J) + "," + (string.Format("{0:F5}", J).Substring(2)));
        FirebaseDatabase.DefaultInstance.RootReference.Child("UsersID").Child(phoneNumber).Child(NumCardGold).Child("MyGoldSumInt").SetValueAsync(MyGoldSumInt - sumintsend);

        FirebaseDatabase.DefaultInstance.RootReference.Child("UsersID").Child("+" + FindNumCard.Substring(4)).Child(FindNumCard).Child("Hist").Child(DateTime.Now.ToShortDateString()).SetValueAsync(Convert.ToUInt32(string.Format("{0:F0}", sumfloatsend))+ sumintsend + "," + (string.Format("{0:F5}", sumfloatsend).Substring(2)));
        FirebaseDatabase.DefaultInstance.RootReference.Child("UsersID").Child("+" + FindNumCard.Substring(4)).Child(FindNumCard).Child("MyGoldSumInt").ValueChanged += HandleValueChangedContactGoldSumInt;
        FirebaseDatabase.DefaultInstance.RootReference.Child("UsersID").Child("+" + FindNumCard.Substring(4)).Child(FindNumCard).Child("MyGoldSumFloat").ValueChanged += HandleValueChangedContactGoldSumFloat;
        ToLog("+" + FindNumCard.Substring(4));

        sendbtn.GetComponent<Button>().interactable = false;
    }
    void HandleValueChangedContactGoldSumInt(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }

        ContactGoldSumInt = Convert.ToUInt32(args.Snapshot.Value); 
        FirebaseDatabase.DefaultInstance.RootReference.Child("UsersID").Child("+" + FindNumCard.Substring(4)).Child(FindNumCard).Child("MyGoldSumInt").SetValueAsync(ContactGoldSumInt+ sumintsend);
        ToLog("+" + FindNumCard.Substring(4)+"int");

    }

    void HandleValueChangedContactGoldSumFloat(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        ContactGoldSumFloat = (float)Convert.ToDecimal(args.Snapshot.Value) + sumfloatsend;

        if(ContactGoldSumFloat>=1f) FirebaseDatabase.DefaultInstance.RootReference.Child("UsersID").Child("+" + FindNumCard.Substring(4)).Child(FindNumCard).Child("MyGoldSumInt").SetValueAsync(Convert.ToUInt32(string.Format("{0:F0}", ContactGoldSumFloat))+ ContactGoldSumInt + sumintsend);
        FirebaseDatabase.DefaultInstance.RootReference.Child("UsersID").Child("+" + FindNumCard.Substring(4)).Child(FindNumCard).Child("MyGoldSumFloat").SetValueAsync("0," + (string.Format("{0:F5}", ContactGoldSumFloat).Substring(2)));
        ToLog("+" + FindNumCard.Substring(4) + "float");
    }
    public void ActivPanFind(string i)
    {

        if (i.Length > 0)
        {
            FindNickName = "";
            PanFind.SetActive(false);
            inputnotise.SetActive(true);
            NotFaundPan.SetActive(false);
            MainPanContact.SetActive(false);
            PanContact.SetActive(true);
        }
        else
        {
            MainPanContact.SetActive(true);
            PanContact.SetActive(false);
        }

    }

    public void SerchUsrCardSilver(string FindCard)
    {
        ToLog(FindCard.Length + "");
        TxtLog1.GetComponent<Text>().text = ("+" + FindCard.Substring(4));
        TxtLog2.GetComponent<Text>().text = FindCard;
        if (FindCard.Length > 15)
        {
            if (FindNickName.Length < 1) NotFaundPanSilver.SetActive(true);
            FirebaseDatabase.DefaultInstance.GetReference("UsersID").Child("+" + FindCard.Substring(4)).Child("NickName").GetValueAsync().ContinueWithOnMainThread(FindCardT =>
            {

                if (FindCardT.IsFaulted)
                { ToLog("FailFind"); NotFaundPanSilver.SetActive(true); }
                else if (FindCardT.IsCompleted)
                {

                    FindNickName = FindCardT.Result.Value.ToString();

                    FindNumCard = FindCard;
                    inputnotiseSilver.SetActive(false);

                    FindNickNameTxtSilver.GetComponent<Text>().text = FindNickName;
                    FindNumCardTxtSilver.GetComponent<Text>().text = FindNumCard;
                    PanFindSilver.SetActive(true);
                    NotFaundPanSilver.SetActive(false);

                }
                if (FindNickName.Length < 1) NotFaundPanSilver.SetActive(true);

            });
        }



    }
    public void ActivPanFindSilver(string i)
    {

        if (i.Length > 0)
        {
            FindNickName = "";
            PanFindSilver.SetActive(false);
            inputnotiseSilver.SetActive(true);
            NotFaundPanSilver.SetActive(false);
            MainPanContactSilver.SetActive(false);
            PanContactSilver.SetActive(true);
        }
        else
        {
            MainPanContactSilver.SetActive(true);
            PanContactSilver.SetActive(false);
        }

    }
    public void OnMessageReceived(object sender, Firebase.Messaging.MessageReceivedEventArgs e)
    {
        
    }
    public virtual void OnTokenReceived(object sender, Firebase.Messaging.TokenReceivedEventArgs token)
    {
        
    }

}