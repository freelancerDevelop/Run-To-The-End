using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdmobManager : MonoBehaviour
{
    public static AdmobManager Instance { get; set; }
    private BannerView banner;
    private InterstitialAd interstitial;
    private RewardBasedVideoAd video;
    private static string outputMessage = "";

    public static string OutputMessage
    {
        set { outputMessage = value; }
    }

    private void Start()
    {
        Instance = this;

#if UNITY_ANDROID
        string appId = "ca-app-pub-3670795233890103~6318560251";
#elif UNITY_IPHONE
        string appId = "ca-app-pub-3670795233890103~9778173553";
#else
        string appId = "unexpected_platform";
#endif

        MobileAds.SetiOSAppPauseOnBackground(true);
        MobileAds.Initialize(appId);

        video = RewardBasedVideoAd.Instance;
        video.OnAdLoaded += HandleRewardBasedVideoLoaded;
        video.OnAdFailedToLoad += this.HandleRewardBasedVideoFailedToLoad;
        video.OnAdOpening += HandleRewardBasedVideoOpened;
        video.OnAdStarted += HandleRewardBasedVideoStarted;
        video.OnAdClosed += HandleRewardBasedVideoClosed;
        video.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;
        RequestBanner();
        RequestInterstitial();
        RequestRewardBasedVideo();
    }

    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder().Build();
    }

    public void RequestBanner()
    {
#if UNTIY_ANDROID
        string adUnitId = "ca-app-pub-3670795233890103/2825752393";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3670795233890103/7311792310";
#else
        string adUnitId = "unexpected_platform";
#endif
        if (banner != null)
            banner.Destroy();
        AdSize size = new AdSize(200, 20);
        banner = new BannerView(adUnitId, size, AdPosition.Bottom);

        
        this.banner.OnAdLoaded += this.HandleAdLoaded;
        this.banner.OnAdFailedToLoad += this.HandleAdFailedToLoad;
        this.banner.OnAdOpening += this.HandleAdOpened;
        this.banner.OnAdClosed += this.HandleAdClosed;
        this.banner.OnAdLeavingApplication += this.HandleAdLeftApplication;

        this.banner.LoadAd(this.CreateAdRequest());
        

    }

    public void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3670795233890103/2719060744";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3670795233890103/9275610674";
#else
        string adUnitId = "unexpected_platform";
#endif

        if (this.interstitial != null)
        {
            this.interstitial.Destroy();
        }

        this.interstitial = new InterstitialAd(adUnitId);

        this.interstitial.OnAdLoaded += this.HandleInterstitialLoaded;
        this.interstitial.OnAdFailedToLoad += this.HandleInterstitialFailedToLoad;
        this.interstitial.OnAdOpening += this.HandleInterstitialOpened;
        this.interstitial.OnAdClosed += this.HandleInterstitialClosed;
        this.interstitial.OnAdLeavingApplication += this.HandleInterstitialLeftApplication;

        this.interstitial.LoadAd(this.CreateAdRequest());
    }

    public void RequestRewardBasedVideo()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3670795233890103/8485273181";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3670795233890103/1177914210";
#else
        string adUnitId = "unexpected_platform";
#endif

        video.LoadAd(CreateAdRequest(), adUnitId);
    }

    private void ShowInterstitial()
    {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
        else
        {
            print("Interstitial is not ready yet");
        }
    }

    public void ShowRewardBasedVideo()
    {
        if (video.IsLoaded())
        {
            video.Show();
        }
        else
        {
            ShowInterstitial();
        }
    }
    
    #region Banner
    private void HandleAdLeftApplication(object sender, EventArgs e)
    {
    }

    private void HandleAdClosed(object sender, EventArgs e)
    {
    }

    private void HandleAdOpened(object sender, EventArgs e)
    {
    }

    private void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs e)
    {
    }

    private void HandleAdLoaded(object sender, EventArgs e)
    {
        banner.Show();
    }
    #endregion

    #region Interstitial
    private void HandleInterstitialLeftApplication(object sender, EventArgs e)
    {
    }

    private void HandleInterstitialClosed(object sender, EventArgs e)
    {
        interstitial.Destroy();
        RequestInterstitial();
    }

    private void HandleInterstitialOpened(object sender, EventArgs e)
    {
    }

    private void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs e)
    {
        RequestInterstitial();
    }

    private void HandleInterstitialLoaded(object sender, EventArgs e)
    {
    }

    #endregion

    #region VideoAd
    private void HandleRewardBasedVideoLeftApplication(object sender, EventArgs e)
    {
    }

    private void HandleRewardBasedVideoClosed(object sender, EventArgs e)
    {
        RequestRewardBasedVideo();
    }

    private void HandleRewardBasedVideoStarted(object sender, EventArgs e)
    {
    }

    private void HandleRewardBasedVideoOpened(object sender, EventArgs e)
    {
    }

    private void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs e)
    {
    }

    private void HandleRewardBasedVideoLoaded(object sender, EventArgs e)
    {
    }
    #endregion
}
