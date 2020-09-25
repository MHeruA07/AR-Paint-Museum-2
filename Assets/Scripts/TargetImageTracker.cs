using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

/// <summary>
/// A custom handler that implements the ITrackableEventHandler interface.
///
/// Changes made to this file could be overwritten when upgrading the Vuforia version.
/// When implementing custom event handler behavior, consider inheriting from this class instead.
/// </summary>
public class TargetImageTracker : MonoBehaviour, ITrackableEventHandler
{
    #region PROTECTED_MEMBER_VARIABLES

    protected TrackableBehaviour mTrackableBehaviour;
    protected TrackableBehaviour.Status m_PreviousStatus;
    protected TrackableBehaviour.Status m_NewStatus;

    #endregion // PROTECTED_MEMBER_VARIABLES

    // public string type;
    public int id;
    public int artId = 0;
    public int artCount;
    public Sprite bioPhoto;
    [TextArea]
    public string bioText;
    public Sprite[] buttonIcon;
    public Sprite[] paintList;

    #region UNITY_MONOBEHAVIOUR_METHODS

    protected virtual void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
    }

    protected virtual void OnDestroy()
    {
        if (mTrackableBehaviour)
            mTrackableBehaviour.UnregisterTrackableEventHandler(this);
    }

    #endregion // UNITY_MONOBEHAVIOUR_METHODS

    #region PUBLIC_METHODS

    /// <summary>
    ///     Implementation of the ITrackableEventHandler function called when the
    ///     tracking state changes.
    /// </summary>
    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        m_PreviousStatus = previousStatus;
        m_NewStatus = newStatus;
        
        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + 
                  " " + mTrackableBehaviour.CurrentStatus +
                  " -- " + mTrackableBehaviour.CurrentStatusInfo);

        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            OnTrackingFound();
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            OnTrackingLost();
        }
        else
        {
            // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
            // Vuforia is starting, but tracking has not been lost or found yet
            // Call OnTrackingLost() to hide the augmentations
            OnTrackingLost();
        }
    }

    #endregion // PUBLIC_METHODS

    #region PRIVATE_METHODS

    private void OnTrackingFound()
    {
        ArtPreviewHandler.instance.idMarker = id;
        this.gameObject.transform.Find("3d frame").gameObject.SetActive(true);
        this.gameObject.transform.Find("3d frame").transform.localPosition = new Vector3(0,0,0);
        this.gameObject.transform.Find("3d frame").transform.localRotation = Quaternion.Euler(0,-90,-90);
        this.gameObject.transform.Find("3d frame").transform.localScale = new Vector3(0.4f,0.4f,0.4f);
        ArtPreviewHandler.instance.ChangeArtPreview(artId);
        ArtPreviewHandler.instance.ShowArtPreviewPanel();
        ArtPreviewHandler.instance.SetArtListPreview(artCount, buttonIcon);
        ArtPreviewHandler.instance.ShowBioButton();
        ArtPreviewHandler.instance.bioPhoto.sprite = bioPhoto;
        ArtPreviewHandler.instance.bioText.text = bioText;
    }


    private void OnTrackingLost()
    {
        ArtPreviewHandler.instance.HideFrame();
        ArtPreviewHandler.instance.HideArtPreviewPanel();
        ArtPreviewHandler.instance.HideBioButton();
        ArtPreviewHandler.instance.idMarker = 0;
    }

    #endregion // PROTECTED_METHODS
}

