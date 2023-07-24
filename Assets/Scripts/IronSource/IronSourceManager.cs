using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IronSourceManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        IronSource.Agent.init ("1ad5e65b5");
        IronSource.Agent.validateIntegration();
    }
    private void OnEnable() {
        IronSourceEvents.onSdkInitializationCompletedEvent += SdkInitializationCompletedEvent;
        
        IronSourceInterstitialEvents.onAdReadyEvent += InterstitialOnAdReadyEvent;
        IronSourceInterstitialEvents.onAdLoadFailedEvent += InterstitialOnAdLoadFailed;
        IronSourceInterstitialEvents.onAdOpenedEvent += InterstitialOnAdOpenedEvent;
        IronSourceInterstitialEvents.onAdClickedEvent += InterstitialOnAdClickedEvent;
        IronSourceInterstitialEvents.onAdShowSucceededEvent += InterstitialOnAdShowSucceededEvent;
        IronSourceInterstitialEvents.onAdShowFailedEvent += InterstitialOnAdShowFailedEvent;
        IronSourceInterstitialEvents.onAdClosedEvent += InterstitialOnAdClosedEvent;

        IronSourceBannerEvents.onAdLoadedEvent += BannerOnAdLoadedEvent;
        IronSourceBannerEvents.onAdLoadFailedEvent += BannerOnAdLoadFailedEvent;
        IronSourceBannerEvents.onAdClickedEvent += BannerOnAdClickedEvent;
        IronSourceBannerEvents.onAdScreenPresentedEvent += BannerOnAdScreenPresentedEvent;
        IronSourceBannerEvents.onAdScreenDismissedEvent += BannerOnAdScreenDismissedEvent;
        IronSourceBannerEvents.onAdLeftApplicationEvent += BannerOnAdLeftApplicationEvent;

    }
    void OnApplicationPause(bool isPaused) {                 
      IronSource.Agent.onApplicationPause(isPaused);
    }
    private void SdkInitializationCompletedEvent(){}

    public void LoadBanner()
    {
        IronSource.Agent.loadBanner(IronSourceBannerSize.BANNER, IronSourceBannerPosition.BOTTOM);
    }
    public void DestroyBanner()
    {
        IronSource.Agent.destroyBanner();
    }
    public void LoadFullScreen()
    {
        IronSource.Agent.loadInterstitial();
    }
    public void ShowFullScreen()
    {
        if(IronSource.Agent.isInterstitialReady())
            IronSource.Agent.showInterstitial();
    }
    void BannerOnAdLoadedEvent(IronSourceAdInfo adInfo) 
    {
    }
    void BannerOnAdLoadFailedEvent(IronSourceError ironSourceError) 
    {
    }
    void BannerOnAdClickedEvent(IronSourceAdInfo adInfo) 
    {
    }
    void BannerOnAdScreenPresentedEvent(IronSourceAdInfo adInfo) 
    {
    }
    void BannerOnAdScreenDismissedEvent(IronSourceAdInfo adInfo) 
    {
    }
    void BannerOnAdLeftApplicationEvent(IronSourceAdInfo adInfo) 
    {
    }
    void InterstitialOnAdReadyEvent(IronSourceAdInfo adInfo) {
    }
    void InterstitialOnAdLoadFailed(IronSourceError ironSourceError) {
    }
    void InterstitialOnAdOpenedEvent(IronSourceAdInfo adInfo) {
    }
    void InterstitialOnAdClickedEvent(IronSourceAdInfo adInfo) {
    }
    void InterstitialOnAdShowFailedEvent(IronSourceError ironSourceError, IronSourceAdInfo adInfo) {
    }
    void InterstitialOnAdClosedEvent(IronSourceAdInfo adInfo) {
    }
    void InterstitialOnAdShowSucceededEvent(IronSourceAdInfo adInfo) {
    }


}
