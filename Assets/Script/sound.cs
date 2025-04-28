using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragWithSound : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public AudioClip dragSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        UnityEngine.Debug.Log("a");
        if (dragSound != null)
        {
            audioSource.PlayOneShot(dragSound); // ドラッグ開始時に効果音を鳴らす
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        // ドラッグ中の動き（位置変更など）はここに書く
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // ドラッグ終了後の処理（必要なら）
    }
}
