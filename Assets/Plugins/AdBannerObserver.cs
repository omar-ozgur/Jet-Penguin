using UnityEngine;
using System.Collections;

public class AdvertisementHandler : MonoBehaviour
{
    public enum AdvSize
    {
        BANNER,
        IAB_MRECT,
        IAB_BANNER,
        IAB_LEADERBOARD,
        SMART_BANNER,
        DEVICE_WILL_DECIDE
    };

    public enum AdvOrientation
    {
        VERTICAL,
        HORIZONTAL
    };

    public enum Position
    {
        NO_GRAVITY = 0,
        CENTER_HORIZONTAL = 1,
        LEFT = 3,
        RIGHT = 5,
        FILL_HORIZONTAL = 7,
        CENTER_VERTICAL = 16,
        CENTER = 17,
        TOP = 48,
        BOTTOM = 80,
        FILL_VERTICAL = 112
    };

    public enum AnimationInType
    {
        SLIDE_IN_LEFT, 
        FADE_IN,
        NO_ANIMATION
    };

    public enum AnimationOutType
    {
        SLIDE_OUT_RIGHT,
        FADE_OUT,
        NO_ANIMATION
    };

    public enum Activity
    {
        INSTANTIATE,
        DISABLE,
        ENABLE,
        HIDE,
        SHOW,
        REPOSITION
    }
    public enum LevelOfDebug
    {
        NONE,
        LOW,
        HIGH,
        FLOOD
    }

    static AndroidJavaClass admobPluginClass;
    static AndroidJavaClass unityPlayer;
    static AndroidJavaObject currActivity;

    /// <summary>
    /// Initializing Plugin with values
    /// </summary>
    /// <param name="pubID">Admob App ID</param>
    /// <param name="advSize">Advertisement Size</param>
    /// <param name="advOrient">Advertisement Orientation</param>
    /// <param name="position_1">Advertisement First Position</param>
    /// <param name="position_2">Advertisement Second Position</param>
    /// <param name="isTesting">Flag for testing game/app</param>
    /// <param name="testDeviceId">Test Device Id</param>
    /// <param name="animIn">Animation IN Type</param>
    /// <param name="animOut">Animation OUT Type</param>
    /// <param name="levelOfDebug">Debug Level</param>
    public static void Instantiate(string pubID, AdvSize advSize, AdvOrientation advOrient, Position position_1, Position position_2, bool isTesting, string testDeviceId, AnimationInType animIn, AnimationOutType animOut, LevelOfDebug levelOfDebug)
    {
        Debug.Log("Instantiate Called");
        admobPluginClass = new AndroidJavaClass("com.microeyes.admob.AdmobActivity");
        unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        currActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        admobPluginClass.CallStatic("AdvHandler", (int)Activity.INSTANTIATE, currActivity, pubID, (int)advSize, (int)advOrient, (int)position_1, (int)position_2, isTesting, testDeviceId, (int)animIn, (int)animOut, (int)levelOfDebug);
        Debug.Log("Instantiate FINISHED");
    }

    /// <summary>
    /// Enable Advertisements, work if not yet called / after calling DisableAdvs();
    /// </summary>
    public static void EnableAds()
    {
        Debug.Log("ENABLED Called");
        admobPluginClass.CallStatic("AdvHandler", (int)Activity.ENABLE, currActivity, "", -1, -1, -1, -1, false, "", -1, -1, -1);
        Debug.Log("ENABLED FINISHED");        
    }


    /// <summary>
    /// Disable Advertisements, Call EnableAds() to start again
    /// ShowAds() won't work here.
    /// </summary>
    public static void DisableAds()
    {
        Debug.Log("DISABLED Called");
        admobPluginClass.CallStatic("AdvHandler", (int)Activity.DISABLE, currActivity, "", -1, -1, -1, -1, false, "", -1, -1, -1);
        Debug.Log("DISABLED FINISHED");
    }

    /// <summary>
    /// Temp Hide Advertisements, Call Show() to show again
    /// EnableAds() won't work here
    /// </summary>
    public static void HideAds()
    {
        Debug.Log("HIDE ADV Called");
        admobPluginClass.CallStatic("AdvHandler", (int)Activity.HIDE, currActivity, "", -1, -1, -1, -1, false, "", -1, -1, -1);
        Debug.Log("HIDE ADV FINISHED");
    }

    /// <summary>
    /// Show Advertisements, work after EnableAds() already called
    /// </summary>
    public static void ShowAds()
    {
        Debug.Log("SHOW ADV Called");
        admobPluginClass.CallStatic("AdvHandler", (int)Activity.SHOW, currActivity, "", -1, -1, -1, -1, false, "", -1, -1, -1);
        Debug.Log("SHOW ADV FINISHED");
    }
}
