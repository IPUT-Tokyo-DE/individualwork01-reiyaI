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
            audioSource.PlayOneShot(dragSound); // �h���b�O�J�n���Ɍ��ʉ���炷
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        // �h���b�O���̓����i�ʒu�ύX�Ȃǁj�͂����ɏ���
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // �h���b�O�I����̏����i�K�v�Ȃ�j
    }
}
