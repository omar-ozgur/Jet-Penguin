using UnityEngine;
using System.Collections;

public class AdvertisementManager : MonoBehaviour {

//    Rect rect = new Rect();
//    void OnGUI()
//    {
//        rect.x = 20;
//        rect.y = 40;
//
//        rect.width = Screen.width * 0.3f;
//        rect.height = Screen.height * 0.1f;
//        // Make the Enable Button
//        if (GUI.Button(rect, "Enable"))   {
//            AdvertisementHandler.EnableAds();
//        }
//
//        rect.y = rect.y + rect.height;
//        if (GUI.Button(rect, "Disable")) {           
//            AdvertisementHandler.DisableAds();
//        }
//
//        rect.y = rect.y + rect.height;
//        // Make the Hide Button
//        if (GUI.Button(rect, "Hide"))   {
//            AdvertisementHandler.HideAds();
//        }
//
//        rect.y = rect.y + rect.height;
//        // Make the Show button.
//        if (GUI.Button(rect, "Show"))   {
//            AdvertisementHandler.ShowAds();
//        }
//
//    }

    /// <summary>
    /// Admob publisher App Id
    /// </summary>
    [SerializeField]
    private string m_publisherId = "pubId";
    public string PublisherId
    {
        get { return m_publisherId; }
        set { m_publisherId = value; }
    }

    /// <summary>
    /// Advertisement Size
    /// </summary>
    [SerializeField]
    private AdvertisementHandler.AdvSize m_advSize = AdvertisementHandler.AdvSize.SMART_BANNER;
    public AdvertisementHandler.AdvSize AdvSize
    {
        get { return m_advSize; }
        set { m_advSize = value; }
    }

    /// <summary>
    /// Advertisement Orientation
    /// </summary>
    [SerializeField]
    private AdvertisementHandler.AdvOrientation m_orientation = AdvertisementHandler.AdvOrientation.HORIZONTAL;
    public AdvertisementHandler.AdvOrientation Orientation
    {
        get { return m_orientation; }
        set { m_orientation = value; }
    }

    /// <summary>
    /// Advertisement First Position
    /// </summary>
    [SerializeField]
    private AdvertisementHandler.Position m_positionOne = AdvertisementHandler.Position.BOTTOM;
    public AdvertisementHandler.Position PositionOne
    {
        get { return m_positionOne; }
        set { m_positionOne = value; }
    }


    /// <summary>
    /// Advertisement Second Position
    /// </summary>
    [SerializeField]
    private AdvertisementHandler.Position m_positionTwo = AdvertisementHandler.Position.CENTER_HORIZONTAL;
    public AdvertisementHandler.Position PositionTwo
    {
        get { return m_positionTwo; }
        set { m_positionTwo = value; }
    }

    /// <summary>
    /// Set True, if testing game/app
    /// </summary>
    [SerializeField]
    private bool m_isTesting = false;
    public bool IsTesting
    {
        get { return m_isTesting; }
        set { m_isTesting = value; }
    }
    
    /// <summary>
    /// Test Device Id, if you know
    /// </summary>
    [SerializeField]
    private string m_testDeviceId = "testId";
    public string TestDeviceId
    {
        get { return m_testDeviceId; }
        set { m_testDeviceId = value; }
    }

    /// <summary>
    /// Animation Type when loading new Advertisement
    /// </summary>
    [SerializeField]
    private AdvertisementHandler.AnimationInType m_animationInType = AdvertisementHandler.AnimationInType.SLIDE_IN_LEFT;
    public AdvertisementHandler.AnimationInType AnimationInType
    {
        get { return m_animationInType; }
        set { m_animationInType = value; }
    }

    /// <summary>
    /// Animation Type when unloading current/old Advertisement
    /// </summary>
    [SerializeField]
    private AdvertisementHandler.AnimationOutType m_animationOutType = AdvertisementHandler.AnimationOutType.FADE_OUT;
    public AdvertisementHandler.AnimationOutType AnimationOutType
    {
        get { return m_animationOutType; }
        set { m_animationOutType = value; }
    }
    
    /// <summary>
    /// Level of debug logs
    /// </summary>
    [SerializeField]
    private AdvertisementHandler.LevelOfDebug m_levelOfDebug = AdvertisementHandler.LevelOfDebug.LOW;
    public AdvertisementHandler.LevelOfDebug LevelOfDebug
    {
        get { return m_levelOfDebug; }
        set { m_levelOfDebug = value; }
    }


	// Use this for initialization
	void Start () {
        Debug.Log("Unity Calling Start");
        Debug.Log("Initializing with " + 
            "  Pub ID: " + m_publisherId +
            "  Adv Size: " + m_advSize +
            "  Orientation: " + m_orientation +
            "  Position 1: " + m_positionOne +
            "  Position 2: " + m_positionTwo +
            "  IsTesting: " + m_isTesting +
            "  DeviceID: " + m_testDeviceId + 
            "  AnimIn: " + m_animationInType +
            "  AnimOut: " + m_animationOutType +
            "  LevelOfDebug: " + m_levelOfDebug
            );

        //Initializing Plugin with values
        AdvertisementHandler.Instantiate(m_publisherId, m_advSize, m_orientation, m_positionOne, m_positionTwo, m_isTesting, m_testDeviceId, m_animationInType, m_animationOutType, m_levelOfDebug);

        //Shoot request to enable advertisements
        AdvertisementHandler.EnableAds();
	}
	
}
